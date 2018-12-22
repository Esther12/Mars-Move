using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CRMone.Models
{
    public class Invoice
    {
        public int Inv_ID { get; set; }
        public string Inv_des { get; set; }
        public string Inv_amount { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Inv_date { get; set; }

        public List<Customer> Customers { get; set; }

        public static explicit operator Invoice(Customer v)
        {
            throw new NotImplementedException();
        }
    }
}
