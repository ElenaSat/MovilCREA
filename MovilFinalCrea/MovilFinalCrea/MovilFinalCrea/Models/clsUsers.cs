using System;
using System.Collections.Generic;
using System.Text;

namespace MovilFinalCrea.Models
{
  public class clsUsers
    {
        public int User_Id { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserIdentificationCard { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public bool UserTermConditions { get; set; }
        public bool UserConfirmeEmail { get; set; }
    }
}
