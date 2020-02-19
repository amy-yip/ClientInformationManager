using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientManagerApplication.Models
{

    [MetadataType(typeof(Person_Validation))]
    public partial class Person
    {

    }

    public class Person_Validation
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter your first name.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First name must be 1-50 characters.")]
        public string first_name { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last name must be 1-50 characters.")]
        public string last_name { get; set; }

        [Display(Name = "Notes")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "Notes must have a maximum length of 50 characters.")]
        public string notes { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please enter a gender.")]
        [RegularExpression(@"^[a-zA-Z -/]+$", ErrorMessage = "Use letters, spaces, dashes(-) and forward slashes(/) for the gender.")]
        [StringLength(50, MinimumLength = 1)]
        public string gender { get; set; }

        [Display(Name = "Picture")]
        public int picture_id { get; set; }
    }




    [MetadataType(typeof(Address_Validation))]
    public partial class Address
    {

    }

    public class Address_Validation
    {
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please enter a description.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Description must be 2-50 characters.")]
        public string description;

        [Display(Name = "Street")]
        [Required(ErrorMessage = "Please enter a street name.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Street name must be 2-50 characters.")]
        public string street;

        [Display(Name = "City")]
        [Required(ErrorMessage = "Please enter a city.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "City name must be 1-50 characters.")]
        public string city;

        [Display(Name = "Province or State")]
        [Required(ErrorMessage = "Please enter a province or state.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Province or state must be 2-50 characters.")]
        public string province_state;

        [Display(Name = "Zip or Postal Code")]
        [Required(ErrorMessage = "Please enter a zip or postal code.")]
        [RegularExpression(@"^\d{5}-\d{4}|\d{5}|[A-Z]\d[A-Z] \d[A-Z]\d$", ErrorMessage = "Please make sure that the postal code follows the following formats. (Examples: 44240, 44240-5555, T2P 3C7)")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Zip or postal code must be 5-10 characters.")]
        public string zip_postal;
    }


    [MetadataType(typeof(Country_Validation))]
    public partial class Country
    {

    }

    public class Country_Validation
    {
        [Display(Name = "Country Name")]
        public string country_name;
    }



    [MetadataType(typeof(Contact_Validation))]
    public partial class Contact
    {

    }

    public class Contact_Validation
    {
        [Display(Name = "Information Type")]
        [Required(ErrorMessage = "Please enter an information type.")]
        [RegularExpression(@"^[a-zA-Z -/]+$", ErrorMessage = "Use letters, spaces, dashes(-) and forward slashes(/) for the information type.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Information type must be 2-50 characters.")]
        public string information_type;

        [Display(Name = "Information")]
        [Required(ErrorMessage = "Please enter some information for the type.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Information must be 2-50 characters.")]
        public string information;
    }


    [MetadataType(typeof(Picture_Validation))]
    public partial class Picture
    {

    }

    public class Picture_Validation
    {
        [Display(Name = "Caption")]
        [Required(ErrorMessage = "Please enter a caption.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Caption must be 2-50 characters.")]
        public string caption;

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Please choose a file.")]
        public string path;

        [Display(Name = "Time")]
        [Required(ErrorMessage = "Please enter a time.")]
        [RegularExpression(@"^([0-1][0-9]|[2][0-3]):([0-5][0-9])$", ErrorMessage = "Use a HH:MM 24-hour format for the time.")]
        public string time;

        [Display(Name = "Location")]
        [Required(ErrorMessage = "Please enter a location.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Location must be 2-50 characters.")]
        public string location;
    }


}