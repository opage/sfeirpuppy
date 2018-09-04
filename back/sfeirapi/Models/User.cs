using System;
using System.ComponentModel.DataAnnotations;

namespace sfeirapi.Models
{
    public class User
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        public string Adress { get; set; }

        public string City { get; set; }

        public int CP { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime LastModified { get; set; }

        public string Facebook { get; set; }

        public string GitHub { get; set; }

        public string Twitter { get; set; }
    }
}
