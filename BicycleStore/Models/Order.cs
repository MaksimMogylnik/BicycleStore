using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Full name is required!")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Phone number is required!")]
        public string CustomerPhoneNumber { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "E-mail is required!")]
        public string CustomerEmail { get; set; }
        public int BicycleId { get; set; }
        public Bicycle OrderedBicycle { get; set; }
    }
}
