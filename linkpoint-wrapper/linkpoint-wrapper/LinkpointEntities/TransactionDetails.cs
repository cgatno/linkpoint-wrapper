using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using linkpoint_wrapper.LinkpointConstants;

namespace linkpoint_wrapper.LinkpointEntities
{
    public class TransactionDetails : ILinkpointEntity
    {
        private const string TRANSACTION_ORIGIN_TAG = "transactionorigin";
        public TransactionOrigin TransactionOrigin { get; set; }

        private const string ORDER_ID_TAG = "oid";
        private string mOrderId = string.Empty;
        public string OrderID
        {
            get
            {
                if (mOrderId == string.Empty)
                {
                    Random r = new Random();
                    // if the user hasn't specified a unique order ID, we will generate one for them
                    // note that this must be the ID of a previous order for void and credit transactions
                    mOrderId = "O-" + DateTime.Now.ToString("MMddyyHHmmssFFFFFFF") + r.Next(10000, 99999).ToString();
                }
                return mOrderId;
            }
            set
            {
                mOrderId = value;
            }
        }

        private const string TAX_EXEMPT_TAG = "taxexempt";
        public bool TaxExempt { get; set; }

        private const string PURCHASE_ORDER_NUMBER_TAG = "ponumber";
        public string PurchaseOrderNumber { get; set; }

        private const string INVOICE_NUMBER_TAG = "invoice_number";
        private string mInvoiceNumber = string.Empty;
        public string InvoiceNumber
        {
            get
            {
                if (mInvoiceNumber == string.Empty)
                {
                    Random r = new Random();
                    // if the user hasn't specified a unique order ID, we will generate one for them
                    // note that this must be the ID of a previous order for void and credit transactions
                    mInvoiceNumber = "I" + DateTime.Now.ToString("MMddyyHHmmssFFFFFFF") + r.Next(10000, 99999).ToString();
                }
                return mInvoiceNumber;
            }
            set
            {
                mInvoiceNumber = value;
            }
        }

        private const string TERMINAL_TYPE_TAG = "terminaltype";
        public TerminalType TerminalType { get; set; }

        private const string IP_ADDRESS_TAG = "ip";
        public IPAddress IPAddress { get; set; }

        private const string REFERENCE_NUMBER_TAG = "reference_number";
        public string ReferenceNumber { get; set; }

        private const string RECURRING_TAG = "recurring";
        public bool Recurring { get; set; }

        private const string TDATE_TAG = "tdate";
        public string tdate { get; set; }

        private const string TRANSACTION_DETAILS_TAG = "transactiondetails";
        public string EntityXML()
        {
            StringBuilder outputBuilder = new StringBuilder();

            using (XmlWriter writer = XmlWriter.Create(outputBuilder))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(TRANSACTION_DETAILS_TAG);

                if (TransactionOrigin != null) writer.WriteElementString(TRANSACTION_ORIGIN_TAG, TransactionOrigin.ToString());
                if (!string.IsNullOrWhiteSpace(OrderID)) writer.WriteElementString(ORDER_ID_TAG, OrderID);
                writer.WriteElementString(TAX_EXEMPT_TAG, TaxExempt ? "y" : "n");
                if (!string.IsNullOrWhiteSpace(PurchaseOrderNumber)) writer.WriteElementString(PURCHASE_ORDER_NUMBER_TAG, PurchaseOrderNumber);
                if (!string.IsNullOrWhiteSpace(InvoiceNumber)) writer.WriteElementString(INVOICE_NUMBER_TAG, InvoiceNumber);
                if (TerminalType != null) writer.WriteElementString(TERMINAL_TYPE_TAG, TerminalType.ToString());
                if (IPAddress != null) writer.WriteElementString(IP_ADDRESS_TAG, IPAddress.ToString());
                if (!string.IsNullOrWhiteSpace(ReferenceNumber)) writer.WriteElementString(REFERENCE_NUMBER_TAG, ReferenceNumber);
                writer.WriteElementString(RECURRING_TAG, Recurring ? "Yes" : "No");
                if (!string.IsNullOrWhiteSpace(tdate)) writer.WriteElementString(TDATE_TAG, tdate);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            return outputBuilder.ToString();
        }
    }
}
