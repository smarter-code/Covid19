﻿using Covid19.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Service
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Patient> Patients { get; set; }
    }
}