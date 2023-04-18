using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicAuth.Infrastructure.StaticMethods
{
    public  static class CodeGenerator
    {
        public static  string RandomCode(int codeLength , Random random)
        {
            var code = string.Empty;
            while(code.Length<codeLength)
            {
                code.Append((char)random.Next(0, 9));
            }
            return code;

        }
        
    }
}
