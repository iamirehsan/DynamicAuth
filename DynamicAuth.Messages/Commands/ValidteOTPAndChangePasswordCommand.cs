﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicAuth.Messages.Commands
{
    public class ValidteOTPCommand
    {
        public string OTP { get; set; }
        public string OTPKey { get; set; }
  
    }
}
