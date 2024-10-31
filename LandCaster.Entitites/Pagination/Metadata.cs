﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Specfications
{
    public class MetaData
    {
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public int CurrentPage { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }

    }
}