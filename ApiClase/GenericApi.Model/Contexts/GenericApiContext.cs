using GenericApi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Model.Contexts
{
    class GenericApiContext: DbContext
    {
        public DbSet<Document> Documents { get; set; }
        public DbSet<WorkShop> WorkShops { get; set; }
        public DbSet<WorkShopDay> WorkShopDays { get; set; }
        public DbSet<WorkShopMember> workShopMembers { get; set; }
    }
}
