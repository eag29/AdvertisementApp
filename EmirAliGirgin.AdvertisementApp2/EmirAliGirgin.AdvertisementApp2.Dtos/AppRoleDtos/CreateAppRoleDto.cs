using EmirAliGirgin.AdvertisementApp2.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Dtos.AppRoleDtos
{
    public class CreateAppRoleDto: IDto
    {
        public string Definition { get; set; }
    }
}
