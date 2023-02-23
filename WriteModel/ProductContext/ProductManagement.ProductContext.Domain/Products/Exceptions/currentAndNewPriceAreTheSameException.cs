using Framework.Domain.Exception;
using ProductManagement.ProductContext.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.ProductContext.Domain.Products.Exceptions
{
    public class currentAndNewPriceAreTheSameException : DomainException
    {

        override public string Message => ExceptionResource.currentAndNewPriceAreTheSame;
}

}
