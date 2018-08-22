using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingAcademy.ConsumeAPI.Models
{
    public class DTOJson
    {
        [JsonProperty("CourseID")]
        public int CourseID { get; set; }
        [JsonProperty("CourseCode")]
        public string CourseCode { get; set; }
        [JsonProperty("CourseName")]
        public string CourseName { get; set; }
        [JsonProperty("CourseDescription")]
        public string CourseDescription { get; set; }
        [JsonProperty("DateCreated")]
        public System.DateTime DateCreated { get; set; }
        [JsonProperty("DasteModified")]
        public System.DateTime DateModified { get; set; }
    }
}