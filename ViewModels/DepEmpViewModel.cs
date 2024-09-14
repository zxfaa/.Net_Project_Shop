﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using final.Models;
using final.Services;

namespace final.ViewModels
{
    public class DepEmpViewModel
    {
        public int SrhId { get; set; }
        public string SrhName { get; set; }
        public List<Department> depList { get; set; }
        public List<Employee> empList { get; set; }
    }
}