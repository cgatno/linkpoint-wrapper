using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkpoint_wrapper.LinkpointConstants
{
    public sealed class CardCodeStatus
    {
        private readonly string value;

        public static readonly CardCodeStatus Provided = new CardCodeStatus("provided");
        public static readonly CardCodeStatus NotProvided = new CardCodeStatus("not_provided");
        public static readonly CardCodeStatus Illegible = new CardCodeStatus("illegible");
        public static readonly CardCodeStatus NotPresent = new CardCodeStatus("not_present");
        public static readonly CardCodeStatus NoImprint = new CardCodeStatus("no_imprint");

        private CardCodeStatus(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }
}
