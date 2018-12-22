using System;
using System.Collections.Generic;

namespace CRMone.Models
{
    public class Employee
    {
        public int Emp_ID { get; set; }
        public string Emp_lname { get; set; }
        public string Emp_fname { get; set; }
        public string Emp_phone { get; set; }
        public string Emp_email { get; set; }


        public int Cus_ID { get; set; }
        public Customer Customer { get; set; }
    }
}
