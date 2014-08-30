using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using linkpoint_wrapper.LinkpointConstants;

namespace linkpoint_wrapper.LinkpointEntities
{
    class CreditCard : ILinkpointEntity
    {
        private const string CARD_NUMBER_TAG = "cardnumber";
        public string CardNumber { get; set; }

        private const string EXPIRATION_MONTH_TAG = "cardexpmonth";
        public string ExpirationMonth { get; set; }

        private const string EXPIRATION_YEAR_TAG = "cardexpyear";
        public string ExpirationYear { get; set; }

        public string ExpirationDate
        {
            get
            {
                return ExpirationMonth + "/" + ExpirationYear;
            }
        }

        private const string SWIPE_TRACK_DATA_TAG = "track";
        public string SwipeTrackData { get; set; }

        private const string CVM_CARD_CODE_TAG = "cvm";
        public string CVMCardCode { get; set; }

        private const string CVM_CARD_CODE_STATUS_TAG = "cvmindicator";
        public CardCodeStatus CVMCardCodeStatus { get; set; }

        private const string CAVV_TAG = "cavv";
        public string CAVV { get; set; }

        private const string ECI_TAG = "eci";
        public string ECI { get; set; }

        private const string XID_TAG = "xid";
        public string XID { get; set; }

        private const string CREDIT_CARD_TAG = "creditcard";

        public string EntityXML()
        {
            StringBuilder outputBuilder = new StringBuilder();

            using (XmlWriter writer = XmlWriter.Create(outputBuilder))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(CREDIT_CARD_TAG);

                if (!string.IsNullOrWhiteSpace(CardNumber)) writer.WriteElementString(CARD_NUMBER_TAG, CardNumber);
                if (!string.IsNullOrWhiteSpace(ExpirationMonth)) writer.WriteElementString(EXPIRATION_MONTH_TAG, ExpirationMonth);
                if (!string.IsNullOrWhiteSpace(ExpirationYear)) writer.WriteElementString(EXPIRATION_YEAR_TAG, ExpirationYear);
                if (!string.IsNullOrWhiteSpace(SwipeTrackData)) writer.WriteElementString(SWIPE_TRACK_DATA_TAG, SwipeTrackData);
                if (!string.IsNullOrWhiteSpace(CVMCardCode)) writer.WriteElementString(CVM_CARD_CODE_TAG, CVMCardCode);
                if (CVMCardCodeStatus != null) writer.WriteElementString(CVM_CARD_CODE_STATUS_TAG, CVMCardCodeStatus.ToString());
                if (!string.IsNullOrWhiteSpace(CAVV)) writer.WriteElementString(CAVV_TAG, CAVV);
                if (!string.IsNullOrWhiteSpace(ECI)) writer.WriteElementString(ECI_TAG, ECI);
                if (!string.IsNullOrWhiteSpace(XID)) writer.WriteElementString(XID_TAG, XID);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            return outputBuilder.ToString();
        }
    }
}
