using EmirAliGirgin.AdvertisementApp2.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Dtos.AppRoleDtos
{
    public class AppRoleUpdateDto: IUpdateDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}
