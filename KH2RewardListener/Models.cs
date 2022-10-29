using System;
using System.Collections.Generic;
using System.Text;

namespace KH2RewardListener
{
    public class Authorization
    {
        public string Code { get; }

        public Authorization(string code)
        {
            Code = code;
        }
    }
}