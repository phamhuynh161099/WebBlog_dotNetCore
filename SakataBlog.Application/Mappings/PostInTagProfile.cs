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
    public class PostInTagProfile : Profile
    {
        public PostInTagProfile()
        {
            CreateMap<PostInTag, ObjItem>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(x => x.TagId))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(x => x.Tag.TagName));
            CreateMap<ObjItem, PostInTag>()
                .ForMember(dst => dst.TagId, opt => opt.MapFrom(x => x.Id));
        }
    }
}