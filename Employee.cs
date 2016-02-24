using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Class.Chapter_Model.model_associations_one_to_one_csharp_backend
{
    public class Employee
    {
        [JsonProperty(propertyName: "employeeNumber")]
        public int EmployeeNumber { get; set; }
        [JsonProperty(propertyName: "lastName")]
        public string LastName { get; set; }
        [JsonProperty(propertyName: "firstName")]
        public string FirstName { get; set; }
        [JsonProperty(propertyName: "managerNumber")]
        public int ManagerNumber { get; set; }
    }
}