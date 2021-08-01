using PapeleriaApi.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PapeleriaApi.Model.Entities
{
  public class Document : BaseEntity
    {
        public string FileName { get; set; } 
        public string OriginalName { get; set; } 
        public string ContentType { get; set; }
    }
}
