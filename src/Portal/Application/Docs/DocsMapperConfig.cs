using AutoMapper;
using Portal.Application.Docs.Models;
using Portal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.Docs
{
    public class DocsMapperConfig : Profile
    {
        public DocsMapperConfig()
        {
            CreateMap<Doc, DocInfo>().ReverseMap();
        }
    }
}
