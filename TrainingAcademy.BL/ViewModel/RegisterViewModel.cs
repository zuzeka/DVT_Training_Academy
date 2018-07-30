using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TrainingAcademy.DAL;

namespace TrainingAcademy.UI.ViewModel
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Nullable<int> PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public int dietaryID { get; set; }
        [ForeignKey("dietaryID")]
        public Dietary dietaries { get; set; }
        public int AddressTypeID { get; set; }
        [ForeignKey("AddressTypeID")]
        public AddressType AddressTypes { get; set; }
        public int ProvinceID { get; set; }
        [ForeignKey("ProvinceID")]
        public Province Province { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int CityID { get; set; }
        [ForeignKey("CityID")]
        public City City { get; set; }
        public int AddressDetailID { get; set; }
        [ForeignKey("AddressDetailID")]
        public AddressDetail AddressDetail { get; set; }
        public int TrainingID { get; set; }
    }
}