﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWeb.GraphQlCollection
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string BillingAddress { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
