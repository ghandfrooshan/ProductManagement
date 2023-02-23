using Framework.Filtering.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Filtering
{
    public class FilterInfo
    {
        public Logical Logical { get; set; }
        public string PropertyName { get; set; }
        public string Value { get; set; }
        public Operator Operator { get; set; } = Operator.Contains;
    }
}
