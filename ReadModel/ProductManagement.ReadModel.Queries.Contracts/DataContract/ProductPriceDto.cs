using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.ReadModel.Queries.Contracts.DataContract
{
    public class ProductPriceDto
    {
        public long? Id { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public long? ProductId { get; set; }
        public double? Price { get; set; }
    }
}
