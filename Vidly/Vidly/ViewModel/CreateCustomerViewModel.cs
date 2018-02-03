﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class CustomerViewModel
    {
        public List<MembershipType> MembershipType { get; set; }
        public Customer Customer { get; set; }
    }
}