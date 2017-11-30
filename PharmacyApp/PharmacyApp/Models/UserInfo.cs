using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Models
{
    public class UserInfo
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronomyc { get; set; }
        public string Address { get; set; }
        public string BornDate { get; set; }
        public string Number { get; set; }
        public string Mail { get; set; }

        public override bool Equals(object obj)
        {
            UserInfo user = obj as UserInfo;
            return this.Login == user.Login;
        }
    }
}
