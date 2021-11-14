using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants.User
{
    public class Permission : Claim
    {
        public Permission(string key, string name, string category, string info = "") 
            :base(key, key)
        {
            Name = name;
            Category = category;
            Info = info;
        }

        public string Name { get; set; }
        public string Category { get; set; }
        public string Info { get; set; }
    }
}
