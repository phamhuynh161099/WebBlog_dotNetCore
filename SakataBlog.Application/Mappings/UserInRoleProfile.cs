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
    public class UserInRoleProfile : Profile
    {
        public UserInRoleProfile()
        {
            CreateMap<UserInRole, ObjItem>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(x => x.RoleId))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(x => x.Role.Name));
            CreateMap<ObjItem, UserInRole>();
        }
    }
}