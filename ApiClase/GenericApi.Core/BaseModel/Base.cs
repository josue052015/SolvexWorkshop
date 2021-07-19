using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GenericApi.Core.BaseModel
{
    public interface IBase
    {
        int Id { get; set; }
        bool Deleted { get; set; }
    }
    public class Base : IBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        public virtual bool Deleted { get; set; }
    }
}
