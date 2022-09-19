﻿using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product:Entity
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public long Stock { get; set; }
       
    }
}