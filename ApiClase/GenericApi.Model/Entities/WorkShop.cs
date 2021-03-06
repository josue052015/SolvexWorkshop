using GenericApi.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GenericApi.Model.Entities
{
    public class WorkShop : BaseEntity
    {
        public WorkShop()
        {
            Days = new HashSet<WorkShopDay>();
        }
      
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ContentSupport { get; set; }
        public virtual ICollection<WorkShopDay> Days { get; set; }

    }
}
