using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkpoint_wrapper.LinkpointConstants
{
    public sealed class OrderMode
    {
        private readonly string value;

        public static readonly OrderMode Live = new OrderMode("LIVE");
        public static readonly OrderMode TestGood = new OrderMode("GOOD");
        public static readonly OrderMode TestDecline = new OrderMode("DECLINE");
        public static readonly OrderMode TestDuplicate = new OrderMode("DUPLICATE");

        private OrderMode(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }
}
