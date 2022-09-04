﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RequestParameters
{
    public class Pagination
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 5;
    }
}
