using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Common
{
    public interface IResponse<T>  : IResponse
    {
        T Data { get; set; }
        List<CustomValidationError> ValiationErrors { get; set; }
    }
}
