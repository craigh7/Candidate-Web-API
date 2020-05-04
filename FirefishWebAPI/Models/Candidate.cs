using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirefishAPIProject.Models
{
    public class Candidate
    {
        public int candidateID { get; set; }
        public String firstName { get; set; }
        public String surname { get; set; }

        public DateTime DOB { get; set; }

        public String address1 { get; set; }

        public String town { get; set; }

        public String country { get; set; }

        public String postCode { get; set; }

        public String phoneHome { get; set; }

        public String phoneMobile { get; set; }

        public String phoneWork { get; set; }

        public DateTime createdDate { get; set; }

        public DateTime updatedDate { get; set; }
    }
}