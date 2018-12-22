using System;
using System.Collections.Generic;
using CRMone.Models;

namespace CRMone.Models
{
    public class Customer
    {
        public int Cus_ID { get; set; }
        public string Cus_lname { get; set; }
        public string Cus_fname { get; set; }
        public string Cus_phone { get; set; }
        public string Cus_email { get; set; }
        public string Cus_street { get; set; }
        public string Cus_city { get; set; }
        public string Cus_pro { get; set; }
        public string Cus_country { get; set; }

        public List <Employee> Employees { get; set; }

        public int Inv_ID { get; set; }
        public Invoice Invoice { get; set; }
    }
}
