using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants.OTP
{
    public class PhoneNumberActivationOTP
    {
        public PhoneNumberActivationOTP(string otp, DateTime expireDate, DateTime sendAgainDate)
        {
            OTP = otp;
            ExpireDate = expireDate;
            SendAgainDate = sendAgainDate;
        }

        public string OTP { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime SendAgainDate { get; set; }
    }
}
