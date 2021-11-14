using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.UserManagement.User
{
    public class PermissionViewModel
    {
        public PermissionViewModel()
        {

        }

        public PermissionViewModel(string key, string name, string category, string info)
        {
            Key = key;
            Name = name;
            Category = category;
            Info = info;
        }

        public string Key { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Info { get; set; }
        public bool IsSelected { get; set; }
    }
}
