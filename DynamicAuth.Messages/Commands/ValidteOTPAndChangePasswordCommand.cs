using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicAuth.Messages.Commands
{
    public class ValidteOTPAndChangePasswordCommand
    {
        public string OTP { get; set; }
        public string OTPKey { get; set; }
        public string NewPassword { get; set; }
        public string  UserNameOrPassword{ get; set; }
    }
}
