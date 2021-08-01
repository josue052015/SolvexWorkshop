using PapeleriaApi.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PapeleriaApi.Model.Entities
{
  public class StationeryClient : BaseEntity
    {
        public int StationeryId { get; set; }
        public virtual Stationery Stationery { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
