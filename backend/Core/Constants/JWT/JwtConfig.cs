using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants.JWT
{
    public class JwtConfig
    {
        public string SecretKey { get; set; }
        public int ExpireDays { get; set; }
    }
}
