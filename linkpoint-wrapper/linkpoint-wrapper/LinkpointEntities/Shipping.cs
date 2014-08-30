using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace linkpoint_wrapper.LinkpointEntities
{
    class Shipping : ILinkpointEntity
    {
        private const string NAME_TAG = "name";
        public string Name { get; set; }

        private const string ADDRESS_1_TAG = "address1";
        public string Address1 { get; set; }

        private const string ADDRESS_2_TAG = "address2";
        public string Address2 { get; set; }

        private const string CITY_TAG = "city";
        public string City { get; set; }

        private const string STATE_PROVINCE_TAG = "state";
        public string StateProvince { get; set; }

        private const string ZIP_CODE_TAG = "zip";
        public string ZipCode { get; set; }

        private const string COUNTRY_TAG = "country";
        public string Country { get; set; }

        private const string PHONE_NUMBER_TAG = "phone";
        public string PhoneNumber { get; set; }

        private const string EMAIL_TAG = "email";
        public string Email { get; set; }

        private const string ITEM_WEIGHT_TAG = "weight";
        public double ItemWeight { get; set; }

        private const string NUMBER_OF_ITEMS_TAG = "items";
        public int NumberOfItems { get; set; }

        private const string CARRIER_ID_TAG = "carrier";
        public int CarrierID { get; set; }

        private const string ORDER_TOTAL_TAG = "total";
        public decimal OrderTotal { get; set; }

        private const string SHIPPING_TAG = "shipping";

        public string EntityXML()
        {
            StringBuilder outputBuilder = new StringBuilder();

            using (XmlWriter writer = XmlWriter.Create(outputBuilder))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(SHIPPING_TAG);

                writer.WriteElementString(NAME_TAG, Name);
                writer.WriteElementString(ADDRESS_1_TAG, Address1);
                writer.WriteElementString(ADDRESS_2_TAG, Address2);
                writer.WriteElementString(CITY_TAG, City);
                writer.WriteElementString(STATE_PROVINCE_TAG, StateProvince);
                writer.WriteElementString(ZIP_CODE_TAG, ZipCode);
                writer.WriteElementString(COUNTRY_TAG, Country);
                writer.WriteElementString(PHONE_NUMBER_TAG, PhoneNumber);
                writer.WriteElementString(EMAIL_TAG, Email);
                writer.WriteElementString(ITEM_WEIGHT_TAG, ItemWeight.ToString());
                writer.WriteElementString(NUMBER_OF_ITEMS_TAG, NumberOfItems.ToString());
                writer.WriteElementString(CARRIER_ID_TAG, CarrierID.ToString());
                writer.WriteElementString(ORDER_TOTAL_TAG, String.Format("{0:C2}", Convert.ToInt32(OrderTotal)).Remove(0,1));

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            return outputBuilder.ToString();
        }
    }
}
