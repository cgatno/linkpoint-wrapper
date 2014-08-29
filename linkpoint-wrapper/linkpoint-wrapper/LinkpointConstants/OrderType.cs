using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkpoint_wrapper.LinkpointConstants
{
    public sealed class OrderType
    {
        private readonly string value;

        public static readonly OrderType Sale = new OrderType("SALE");
        public static readonly OrderType AuthorizeOnly = new OrderType("PREAUTH");
        public static readonly OrderType ForcedTicketOnly = new OrderType("POSTAUTH");
        public static readonly OrderType Void = new OrderType("VOID");
        public static readonly OrderType Credit = new OrderType("CREDIT");
        public static readonly OrderType CalculateShippingRequest = new OrderType("CALCSHIPPING");
        public static readonly OrderType CalculateTaxRequest = new OrderType("CALCTAX");

        private OrderType(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }
}
