using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GUI.Models
{
    public class AddCrewViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        public string Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(800)]
        public string lastName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(800)]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(800)]
        public string username { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(800)]
        public string role { get; set; }
        public string image_link { get; set; }
        public bool LockoutEnabled { get; set; }
        
        public int team_id { get; set; }


    }

}