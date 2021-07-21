using AutoMapper;
using GenericApi.Bl.Dto;
using GenericApi.Model.Entities;
using GenericApi.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Services.Services
{
    public interface IWorkShopDayService : IBaseService<WorkShopDay, WorkShopDayDto> {}
   public class WorkShopDayService : BaseService<WorkShopDay,WorkShopDayDto>, IWorkShopDayService
    {
        public WorkShopDayService(IWorkShopDayRepository repository, IMapper mapper) : base(repository,mapper)
        {

        }
    }
}
