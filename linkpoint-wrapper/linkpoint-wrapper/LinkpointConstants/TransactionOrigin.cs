using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkpoint_wrapper.LinkpointConstants
{
    public sealed class TransactionOrigin
    {
        private readonly String value;

        public static readonly TransactionOrigin EmailInternet = new TransactionOrigin("ECI");
        public static readonly TransactionOrigin MailOrderPhoneOrder = new TransactionOrigin("MOTO");
        public static readonly TransactionOrigin PhoneOrder = new TransactionOrigin("TELEPHONE");
        public static readonly TransactionOrigin RetailFaceToFace = new TransactionOrigin("RETAIL");
        
        private TransactionOrigin(String value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }
}
