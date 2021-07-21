using AutoMapper;
using GenericApi.Bl.Dto;
using GenericApi.Model.Entities;
using GenericApi.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Services.Services
{
    public interface IWorkShopService: IBaseService<WorkShop, WorkShopDto> { }

    class WorkShopService : BaseService<WorkShop,WorkShopDto>,IWorkShopService
    {
        public WorkShopService(IWorkShopRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
