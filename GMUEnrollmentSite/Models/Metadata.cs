using System;
using System.ComponentModel.DataAnnotations;

namespace GMUEnrollmentSite.Models
{
    public class StudentMetadata
    {
        [StringLength(50)]
        [Required]
        [Display(Name = "First Name")]
        public string FirstName;

        [StringLength(50)]
        [Required]
        [Display(Name = "Middle Name")]
        public string MiddleName;

        [StringLength(50)]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName;

        [StringLength(9)]
        [Required]
        [Display(Name = "Social Security Number")]
        public string SSN;

        [StringLength(50)]
        [Required]
        [EmailAddressAttribute]
        [Display(Name = "Email Address")]
        public string EmailAddress;

        [StringLength(10)]
        [Required]
        [Display(Name = "Home Phone Number")]
        public string HomePhone;

        [StringLength(10)]
        [Required]
        [Display(Name = "Cell Phone Number")]
        public string CellPhone;

        [StringLength(50)]
        [Required]
        [Display(Name = "Street Address")]
        public string AddressStreet;

        [StringLength(50)]
        [Required]
        [Display(Name = "City")]
        public string AddressCity;


        [StringLength(2)]
        [Required]
        [Display(Name = "State (Initials)")]
        public string AddressState;

        [StringLength(5)]
        [Required]
        [Display(Name = "Zip Code")]
        public string AddressZip;

        [Required]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> DOB;

        [StringLength(10)]
        [Required]
        [Display(Name = "Gender")]
        public string Gender;

        [StringLength(50)]
        [Required]
        [Display(Name = "High School Name")]
        public string HighSchoolName;

        [StringLength(50)]
        [Required]
        [Display(Name = "High School Location")]
        public string HighSchoolCity;

        [Required]
        [Display(Name = "High School Graduation Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> GraduationDate;

        [Range(0, 4)]
        [Required]
        [Display(Name = "Current GPA (4.00 Scale)")]
        public Nullable<decimal> CurrentGPA;

        [StringLength(3)]
        [Required]
        [Display(Name = "Math SAT Score")]
        public string SATMath;

        [StringLength(3)]
        [Required]
        [Display(Name = "Verbal SAT Score")]
        public string SATVerbal;

        [StringLength(50)]
        [Required]
        [Display(Name = "Primary Major of Interest")]
        public string AreaOfInterest;

        [Required]
        [Display(Name = "Prospective Enrollment Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> EnrollmentDate;
    }

    public class EnrollmentMetadata
    {
        [Display(Name = "Select Student")]
        public int StudentID { get; set; }

        [Display(Name = "Admission Decision")]
        public string AdmissionDecision;

    }
}