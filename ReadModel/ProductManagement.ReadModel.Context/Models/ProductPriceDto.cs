using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.ReadModel.Context.Models
{
    public class ViewProductPrice
    {
     
        public long ProductId { get; set; }
        public double? USD { get; set; }
        public double? EUR { get; set; }
        public double? LIRA { get; set; }
    }
}
