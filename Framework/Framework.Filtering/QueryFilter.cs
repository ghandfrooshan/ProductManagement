using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Filtering
{
    public class QueryFilter
    {
        private int count;

        public IList<FilterInfo>? FilterInfos { get; set; }
        public IList<OrderInfo>? OrderInfos { get; set; }

        public IList<string>? Columns { get; set; }

        public int Count
        {
            get => count;
            set => count = value;
        }

        public int Page { get; set; }
    }
}
