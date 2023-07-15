using CleanArchitecture.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.Customer
{
    public sealed class Customer : BaseEntity
    {
        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Phone]
        public long PrimaryContactNumber{ get; set; }
        [Phone]
        public long SecondaryContactNumber { get; set; }
    }
}
