using Framework.Filtering.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Filtering
{
    public class OrderInfo
    {
        public OrderType OrderType { get; set; } = OrderType.ASC;
        public string Property { get; set; }
    }
}
