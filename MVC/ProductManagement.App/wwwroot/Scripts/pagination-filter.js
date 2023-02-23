$.getScript("/assets/pages/scripts/ui-blockui.min.js");
$.getScript("/Scripts/error.handler.js");

const Logical = {
    And : "And",
    Or : "Or"
}
const Operator ={
    Contains: "Contains",
    GreaterThan: "GreaterThan",
    GreaterThanOrEqualTo: "GreaterThanOrEqualTo",
    LessThan: "LessThan",
    LessThanOrEqualTo: "LessThanOrEqualTo",
    StartsWith: "StartsWith",
    EndsWith: "EndsWith",
    Equals: "Equals",
    NotEqual: "NotEqual"
}

class FilterInfo {
    Logical = Logical.And;
    PropertyName = "";
    Operator = Operator.Equals;
    Value = "";
    constructor(logical, propertyName, operator, value) {
        this.Logical = logical;
        this.PropertyName = propertyName;
        this.Operator = operator;
        this.Value = value;
    }
}

var orders = [];

function changePage(elem) {
    var page = parseInt($(elem).html());
    pagingCall();
}

function nextPage(elem) {
    var page = parseInt($(elem).closest("ul").find(".active").next().find("a").html());
    pagingCall();
}

function previosPage(elem) {
    var page = parseInt($(elem).closest("ul").find(".active").prev().find("a").html());
}

class CreateFilter {
    
    constructor($table, $PageinationContainer, filterUrl, callback = function() {}, additionalData, additionInput) {
        this.table = $table;
        this.filterUrl = filterUrl;
        this.PageinationCountainer = $PageinationContainer;
        var typingTimer;
        var doneTypingInterval = 1000;

        //on keyup, start the countdown
        var $inputs = $table.find("th").find("input");
        var $sorts = $table.find(".selectable").parent();
        var $selects = $table.find("th").find("select");

        
        $inputs.on("keypress",
            function (e) {
                if (additionInput != undefined) {
                    additionalData[additionInput.id] = additionInput.value;
                }
                if (e.which === 13)
                    doneTyping(undefined, additionalData);
            });
        $selects.on("change",
            function () {
                if (additionInput != undefined) {
                    additionalData[additionInput.id] = additionInput.value;
                }
                doneTyping(undefined, additionalData);
            });
        $sorts.on("click",
            function () {
                if (additionInput != undefined) {
                    additionalData[additionInput.id] = additionInput.value;
                }
                var propertyName = $(this).closest("th").find("input,select").prop("id");

                if ($(this).children().first().hasClass("fa-sort")) {
                    orders.push({ 'Property': propertyName, 'OrderType': "ASC" });
                    $(this).children().first().removeClass("fa-sort");
                    $(this).children().first().addClass("fa-sort-down");
                    $(this).children().first().css("color", "blue");
                } else if ($(this).children().first().hasClass("fa-sort-down")) {
                    orders.find(x => x.Property === propertyName).OrderType = "DESC";

                    $(this).children().first().removeClass("fa-sort-down");
                    $(this).children().first().addClass("fa-sort-up");
                } else {
                    $(this).children().first().removeClass("fa-sort-up");
                    $(this).children().first().addClass("fa-sort");
                    $(this).children().first().css("color", "#bdbcec");
                    orders = orders.filter(x => x.Property !== propertyName);
                }
                doneTyping(false, additionalData);
            });

        

        $(document).on("click","#" + $PageinationContainer.prop("id") + " li", liClicked);

        

        $(document).on("click", "#download", downloadClicked);


        function liClicked() {
            if (additionInput != undefined) {
                additionalData[additionInput.id] = additionInput.value;
            }
            var page;
            if ($(this).hasClass("active")) {
                return;
            } else if ($(this).hasClass("disabled")) {
                return;
            } else if ($(this).hasClass("prev")) {
                page = parseInt($(this).closest("ul").find(".active").find("a").html()) - 1;
                changePage(page, additionalData);
            } else if ($(this).hasClass("next")) {
                page = parseInt($(this).closest("ul").find(".active").find("a").html()) + 1;
                changePage(page, additionalData);
            } else {
                page = parseInt($(this).find("a").html());
                changePage(page, additionalData);
            }
        }

        function downloadClicked() {
            if (additionInput != undefined) {
                additionalData[additionInput.id] = additionInput.value;
            }
            var filter = getFilters();
            var ajaxData = { 'filters': filter, 'orders': orders, 'page': 1, 'count': 0 };
            $.each(additionalData,
                function (key, value) {
                    if (value.constructor.name == "Array" && value.length > 0 && value[0].constructor.name == "FilterInfo") {
                        value.forEach(function (item, i) { filter.push(item); });
                    } else {
                        ajaxData[key] = value;
                    }
                });
            ajaxData.download = true;
            $.ajax({
                type: "POST",
                url: filterUrl,
                data: ajaxData,
                dtaType: "json",
                beforeSend: blockPage,
                success: function (data) {
                    window.open("/StaticFile/GetFile/" + data);
                },
                error: function (xhr) {
                    errorHandler(xhr, this);
                },
                complete: function () {
                    unblockPage();
                }
            });
        }

        function doneTyping(status, additionalData) {

            if (status === undefined) {
                $table.find("th").find("i").removeClass("fa-sort-down").removeClass("fa-sort-up").removeClass("fa-sort")
                    .addClass("fa-sort").css("color", "#bdbcec");
            }
            var filter = getFilters();
            var ajaxData = { 'filters': filter, 'orders': orders };
            $.each(additionalData,
                function (key, value) {
                    if (value.constructor.name == "Array" && value.length > 0 && value[0].constructor.name == "FilterInfo") {
                        value.forEach(function (item, i) { filter.push(item); });
                    } else {
                        ajaxData[key] = value;
                    }
                   
                });

            $.ajax({
                type: "POST",
                url: filterUrl,
                data: ajaxData,
                dtaType: "json",
                beforeSend: blockPage,
                success: function(data) {
                    $table.find("tbody").html(data.tableBody);
                    $PageinationContainer.html(data.paginationBody);
                    $("[data-toggle=tooltip]").tooltip();
                    callback();
                },
                error: function(xhr) {
                    errorHandler(xhr, this);
                },
                complete: function() {
                    unblockPage();
                }
            });
        }

        function changePage(page, additionalData) {

            var filter = getFilters();

            var ajaxData = { 'filters': filter, 'orders': orders, 'page': page, 'count': 15 };
            $.each(additionalData,
                function(key, value) {
                    ajaxData[key] = value;
                });
            $.ajax({
                type: "POST",
                url: filterUrl,
                data: ajaxData,
                dtaType: "json",
                beforeSend: blockPage,
                success: function(data) {
                    $table.find("tbody").html(data.tableBody);
                    $PageinationContainer.html(data.paginationBody);
                    $("[data-toggle=tooltip]").tooltip();
                    callback();

                },
                error: function(xhr) {
                    errorHandler(xhr, this);
                },
                complete: function() {
                    unblockPage();
                }
            });
            callback();
        }


        function getFilters(){
            var filter = [];
            $inputs.each(function (i, element) {
                if ($(element).attr("data-type") === "time" ||
                    $(element).prop("type") === "number" ||
                    $.isNumeric($(element).val())) {
                    filter.push(new FilterInfo(Logical.And, $(element).prop("id"), Operator.Equals, $(element).val()));
                } else if ($(element).attr("data-type") === "date") {
                    var startDate = $(element).val().split("/");
                    if (startDate.length <= 1) {
                        georgianStartDate = null;
                    } else {
                        var georgian = toGregorian(parseInt(startDate[0]),
                            parseInt(startDate[1]),
                            parseInt(startDate[2]));
                        var georgianStartDate = georgian.gy + "/" + georgian.gm + "/" + georgian.gd;
                    }
                    filter.push(new FilterInfo(Logical.And, $(element).prop("id"), Operator.Equals, georgianStartDate));
                } else {
                    filter.push(new FilterInfo(Logical.And, $(element).prop("id"), null, $(element).val()));
                }

            });
            $selects.each(function (i, element) {
                filter.push(new FilterInfo(Logical.And, $(element).prop("id"), Operator.Equals, $(element).val()));
            });
            return filter;
        }

    }

    dispose() {
        
        $(document).off("click", "#" + this.PageinationCountainer.prop("id") + " li");
        $(document).off("click", "#download");

    }

}