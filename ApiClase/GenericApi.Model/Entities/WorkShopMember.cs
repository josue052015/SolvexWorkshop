using GenericApi.Core.BaseModel;
using GenericApi.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GenericApi.Model.Entities
{
    public class WorkShopMember : BaseEntity
    {

        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public WorkShopMemberDocumentType DocumentType { get; set; }
        public string DocumentTypeValue { get; set; }
        public Gender Gender { get; set; }
        public DateTime? Dob { get; set; }
        public int? PhotoId { get; set; }
        public virtual Document Photo { get; set; }
    }

}
