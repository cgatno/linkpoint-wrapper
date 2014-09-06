using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace linkpoint_wrapper.LinkpointEntities
{
    public class Payment : ILinkpointEntity
    {
        private const string SUBTOTAL_TAG = "subtotal";
        public decimal Subtotal { get; set; }

        private const string TAX_TAG = "tax";
        public decimal Tax { get; set; }

        private const string VAT_TAX_TAG = "vattax";
        public decimal VATTax { get; set; }

        private const string SHIPPING_TAG = "shipping";
        public decimal Shipping { get; set; }

        private const string TOTAL_TAG = "chargetotal";
        public decimal Total
        {
            get
            {
                return Subtotal + Tax + VATTax + Shipping;
            }
        }

        private const string PAYMENT_TAG = "payment";
        public string EntityXML()
        {
            StringBuilder outputBuilder = new StringBuilder();

            using (XmlWriter writer = XmlWriter.Create(outputBuilder))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(PAYMENT_TAG);

                writer.WriteElementString(SUBTOTAL_TAG, LinkpointWrapperHelper.LinkpointMoneyFormat(Subtotal));
                writer.WriteElementString(TAX_TAG, LinkpointWrapperHelper.LinkpointMoneyFormat(Tax));
                writer.WriteElementString(VAT_TAX_TAG, LinkpointWrapperHelper.LinkpointMoneyFormat(VATTax));
                writer.WriteElementString(SHIPPING_TAG, LinkpointWrapperHelper.LinkpointMoneyFormat(Shipping));
                writer.WriteElementString(TOTAL_TAG, LinkpointWrapperHelper.LinkpointMoneyFormat(Total));

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            return outputBuilder.ToString();
        }
    }
}
