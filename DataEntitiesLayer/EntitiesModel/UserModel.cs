﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitiesLayer.EntitiesModel
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public bool IsOwner { get; set; }
        public string? Color { get; set; }
    }
}
