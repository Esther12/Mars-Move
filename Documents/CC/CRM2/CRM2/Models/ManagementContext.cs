using System;
using Microsoft.EntityFrameworkCore;
using CRMone.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CRMone.Models
{
    public class ManagementContext : DbContext
    {
        public ManagementContext(DbContextOptions<ManagementContext> options): base(options)
        {
        }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
                        .HasKey(b => b.Inv_ID)
                        .HasName("PrimaryKey_InvoiceId");
            modelBuilder.Entity<Customer>()
                        .HasKey(b => b.Cus_ID)
                        .HasName("PrimaryKey_CustomerId");
            modelBuilder.Entity<Employee>()
                       .HasKey(b => b.Emp_ID)
                       .HasName("PrimaryKey_EmployeeId");


            modelBuilder.Entity<Customer>()
                        .HasOne(p => p.Invoice)
                        .WithMany(b => b.Customers)
            .HasForeignKey(p => p.Inv_ID)
            .HasConstraintName("ForeignKey_Customer_Invoice");
            
            modelBuilder.Entity<Employee>()
                        .HasOne(p => p.Customer)
                        .WithMany(b => b.Employees)
                        .HasForeignKey(p => p.Cus_ID)
            .HasConstraintName("ForeignKey_Employee_Customer");
        }
    }

}
