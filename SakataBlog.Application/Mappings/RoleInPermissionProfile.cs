using AutoMapper;
using SakataBlog.Data.Entities;
using SakataBlog.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.Application.Mappings
{
    public class RoleInPermissionProfile : Profile
    {
        public RoleInPermissionProfile()
        {
            CreateMap<RoleInPermission, ObjItem>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(x => x.PermissionId))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(x => x.Permission.Name));
            CreateMap<ObjItem, RoleInPermission>();
        }
    }
}