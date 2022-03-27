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
    public class PostInCategoryProfile : Profile
    {
        public PostInCategoryProfile()
        {
            CreateMap<PostInCategory, ObjItem>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(x => x.CategoryId))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(x => x.Category.CategoryName));
            CreateMap<ObjItem, PostInCategory>();
        }
    }
}