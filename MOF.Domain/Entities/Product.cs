﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOF.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int Price { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
