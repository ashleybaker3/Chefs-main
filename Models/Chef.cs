using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chefs.Models
{
    public class Chef
    {
        public int ChefID { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Chef's First Name must be at least 2 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Chef's Last Name must be at least 2 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Dish> CreatedDishes { get; set; }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }

        public int CalculateAge( ) 
        { 
            DateTime dob = this.DateOfBirth;
            int age = DateTime.Now.Year - dob.Year;
            if (DateTime.Now.DayOfYear < dob.DayOfYear) 
            {
                age-= 1;
            }

            return age;
        }
    }
}