﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChallengeDomain.Models
{
    public class Client : BaseModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}