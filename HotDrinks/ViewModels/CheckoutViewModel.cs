using HotDrinks.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotDrinks.ViewModels
{
    public class CheckoutViewModel
    {
        public CartViewModel Cart { get; set; }
        public string DiscountCode { get; set; }
        public decimal Discount { get; set; }
        [Required]
        public IEnumerable<PaymentType> AllowedPayments { get; set; }
        [Required]
        public PaymentType SelectedPaymentType { get; set; }
        
        [Required]
        public string Address { get; set; }
    }
}