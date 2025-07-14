using EmirAliGirgin.AdvertisementApp2.Dtos.Interfaces;
using EmirAliGirgin.AdvertisementApp2.Dtos.MilitaryStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Dtos.AdvertisementAppUserStatusDtos
{
    public class AdvertisementAppUserStatusListDto: IDto
    {
        public MilitaryStatusListDto MilitaryStatusListDtos { get; set; }
    }
}
