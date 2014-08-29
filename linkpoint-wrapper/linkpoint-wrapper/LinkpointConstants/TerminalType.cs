using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkpoint_wrapper.LinkpointConstants
{
    public sealed class TerminalType
    {
        private readonly string value;

        public static readonly TerminalType StandalonePointOfSale = new TerminalType("STANDALONE");
        public static readonly TerminalType ElectronicPointOfSale = new TerminalType("POS");
        public static readonly TerminalType SelfServiceStation = new TerminalType("UNATTENDED");
        public static readonly TerminalType OnlineOther = new TerminalType("UNSPECIFIED");

        private TerminalType(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }
}
