using AutoMapper;
using GenericApi.Bl.Dto;
using GenericApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Mapper
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<Document, DocumentDto>().ReverseMap();

            CreateMap<Member, MemberDto>()
                .ForMember(dto => dto.PhotoFileName, config => config.MapFrom(entity => entity.Photo.FileName));
            
            CreateMap<MemberDto, Member>();


            CreateMap<WorkShop, WorkShopDto>().ReverseMap();

            CreateMap<WorkShopDay, WorkShopDayDto>()
                .ForMember(dto => dto.WorkShopName, config => config.MapFrom(entity => entity.WorkShop.Name));

            CreateMap<WorkShopDayDto, WorkShopDay>();

            CreateMap<WorkShopMember, WorkShopMemberDto>()
                .ForMember(dto => dto.WorkShopName, config => config.MapFrom(entity => entity.WorkShop.Name))
                .ForMember(dto => dto.MemberName, config => config.MapFrom(entity => entity.Member.Name));

            CreateMap<WorkShopMemberDto, WorkShopMember>();
        }
    }
}
