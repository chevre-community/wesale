using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ApiModels.v1.User.User
{
    public class EnterPhoneNumberModalApiModel
    {
        public Dictionary<int, string> PhonePrefixes { get; set; }
        public Dictionary<string, string> Languages { get; set; }
    }
}
