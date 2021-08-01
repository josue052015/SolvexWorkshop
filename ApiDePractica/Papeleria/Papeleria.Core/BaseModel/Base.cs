﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PapeleriaApi.Core.BaseModel
{
    public interface IBase
    {
        int Id { get; set; }
        bool Deleted { get; set; }
    }
    public  class Base : IBase
    {
        public virtual int Id { get; set; }
        public virtual bool Deleted { get; set; }
    }
}
