﻿using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Basket:Entity
    {
        public Guid UserId { get; set; }
        public int TotalProduct { get; set; }
        public float TotalPrice { get; set; }
        public bool IsActive { get; set; }
        //Todo aynı ürün sepete eklendiğinde quantity artmalı

        public virtual User User { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }
    }
}
