//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarInsurance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Insuree
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        [Required]
        public string EmailAddress { get; set; }
        [Display(Name = "Date of Birth")]
        [Required]
        public System.DateTime DateOfBirth { get; set; }
        [Display(Name = "Year")]
        [Required]
        public int CarYear { get; set; }
        [Display(Name = "Make")]
        [Required]
        public string CarMake { get; set; }
        [Display(Name = "Model")]
        [Required]
        public string CarModel { get; set; }
        [Display(Name = "DUI")]
        public bool DUI { get; set; }
        [Display(Name = "Number of Speeding Tickets")]
        [Required]
        public int SpeedingTickets { get; set; }
        [Display(Name = "Add Collision")]
        public bool CoverageType { get; set; }
        public decimal? Quote
        {
            get
            {
                Insuree insuree = new Insuree();
                insuree.DateOfBirth = DateOfBirth;
                insuree.CarYear = CarYear;
                insuree.CarMake = CarMake.ToLower();
                insuree.CarModel = CarModel.ToLower();
                insuree.DUI = DUI;
                insuree.SpeedingTickets = SpeedingTickets;
                insuree.CoverageType = CoverageType;

                float quote = 0f;
                int monthlyQuote = 50;
                int extras = 0;
                int age = Convert.ToInt32(DateTime.Now.Year - insuree.DateOfBirth.Year);
                if (age <= 18)
                {
                    monthlyQuote += 100;
                }
                else if (age >= 19 && age <= 25)
                {
                    monthlyQuote += 50;
                }
                else
                {
                    monthlyQuote += 25;
                }

                if (insuree.CarYear >= 2000 && insuree.CarYear <= 2015)
                {
                    monthlyQuote += 0;
                }
                else
                {
                    monthlyQuote += 25;
                }

                if (insuree.CarMake == "Porsche")
                {
                    extras += 25;
                }
                else if (insuree.CarMake == "porsche" && insuree.CarModel == "911 carrera")
                {
                    extras += 50;
                }

                monthlyQuote += insuree.SpeedingTickets * 10;

                quote = (monthlyQuote * 12) + extras;

                if (insuree.DUI)
                {
                    quote = (float)(quote * 1.25);
                }

                if (insuree.CoverageType)
                {
                    quote = (float)(quote * 1.5);
                }
                return (decimal)quote;
            }
            set
            {
                 // A dynamically computed field needs an empty set to fulfill prop requirements
            }
        }
    }
}