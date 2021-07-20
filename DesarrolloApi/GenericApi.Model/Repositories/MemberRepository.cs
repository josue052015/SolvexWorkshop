using GenericApi.Model.Contexts;
using GenericApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Model.Repositories
{
    public interface IMemberRepository : IBaseRepository<Member> { }
    class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        public MemberRepository(WorkShopContext context): base(context)
        {

        }
    }
}
