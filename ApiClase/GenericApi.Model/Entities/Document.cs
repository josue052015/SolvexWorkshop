using GenericApi.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GenericApi.Model.Entities
{
    public class Document
    {
        [Key]
        public string FileName { get; set; } //file-store name
        public string OriginalName { get; set; } //selected file
        public string ContentType { get; set; }
    }

}
