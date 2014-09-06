using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkpoint_wrapper.LinkpointConstants
{
    public sealed class AccountType
    {
        private readonly string value;

        public AccountType PersonalChecking = new AccountType("PC");
        public AccountType PersonalSavings = new AccountType("PS");
        public AccountType BusinessChecking = new AccountType("BC");
        public AccountType BusinessSavings = new AccountType("BS");

        private AccountType(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }
}
