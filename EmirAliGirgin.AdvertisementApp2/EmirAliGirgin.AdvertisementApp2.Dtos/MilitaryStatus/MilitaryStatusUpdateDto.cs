using EmirAliGirgin.AdvertisementApp2.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Dtos.MilitaryStatus
{
    public class MilitaryStatusUpdateDto: IUpdateDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}
