using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.ComponentModel;
using Bini_Project.Helper;

namespace Bini_Project.Models
{
    public class User
    {
        
        [Required]  
        [DisplayName("User Name")]
        public string userName { get; set; }

        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public string token { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }


        
       
    }

    public class Rootobject
    {
        public patient[] patients { get; set; }
        public int Count { get; set; }
    }
    

    public class patient
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime LastVisitDate { get; set; }
        public int ID { get; set; }
    }


    [Bini_Project.Helper.CustomValidations.AtLeastOneProperty("firstname","lastname","patientID",ErrorMessage="You must supply at least one value for search criteria")]
    public class patientSearchCriteria
    {
        [DisplayName("First Name")]
        [MaxLength(50)]
        public string firstname { get; set; }
        [DisplayName("Last Name")]
        [MaxLength(50)]
        public string lastname { get; set; }
        [DisplayName("Patient ID")]        
        public string patientID { get; set; }
        public string token { get; set; }
    }

}