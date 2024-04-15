﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Student
    {
        private static int _id;
        public int Id { get;set; }
        public string Name { get; set; }
        public string Surname { get; set; } 

        public Student(string name, string surname)
        {
            _id++;
            Id = _id;
            Name = name;
            Surname = surname;
        }
    }
}
