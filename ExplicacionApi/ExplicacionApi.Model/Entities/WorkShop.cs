using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicacionApi.Model.Entities
{
    class WorkShop
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
