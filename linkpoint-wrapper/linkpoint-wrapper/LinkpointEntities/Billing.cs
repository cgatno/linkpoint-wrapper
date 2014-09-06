using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace linkpoint_wrapper.LinkpointEntities
{
    public class Billing : ILinkpointEntity
    {
        private const string NAME_TAG = "name";
        public string Name { get; set; }

        private const string COMPANY_TAG = "company";
        public string Company { get; set; }

        private const string ADDRESS_1_TAG = "address1";
        public string Address1 { get; set; }

        private const string ADDRESS_2_TAG = "address2";
        public string Address2 { get; set; }

        private const string CITY_TAG = "city";
        public string City { get; set; }

        // TODO: add some way of normalizing this to be Linkpoint-compliant - needs to be 2 chars
        private const string STATE_PROVINCE_TAG = "state";
        public string StateProvince { get; set; }

        private const string ZIP_CODE_TAG = "zip";
        public string ZipCode { get; set; }

        // TODO: add some way of normalizing this to be Linkpoint-compliant - needs to be 2 chars
        private const string COUNTRY_TAG = "country";
        public string Country { get; set; }

        private const string PHONE_NUMBER_TAG = "phone";
        public string PhoneNumber { get; set; }

        private const string FAX_NUMBER_TAG = "fax";
        public string FaxNumber { get; set; }

        private const string EMAIL_TAG = "email";
        public string Email { get; set; }

        private const string ADDRESS_NUMBER_TAG = "addrnum";
        public string AddressNumber {
            get
            {
                try
                {
                    return Regex.Match(Address1, @"\d+").Value;
                }
                catch
                {
                    return "";
                }
            }
        }

        private const string USER_ID_TAG = "userid";
        private string mUserId = string.Empty;
        public string UserID
        {
            get
            {
                if (mUserId == string.Empty)
                {
                    Random r = new Random();
                    // if the user hasn't specified a unique user ID, we will generate one for them
                    mUserId = DateTime.Now.ToString("MMddyyHHmmssFFFFFFF") + r.Next(10000, 99999).ToString();
                }
                return mUserId;
            }
            set
            {
                mUserId = value;
            }
        }

        private const string BILLING_TAG = "billing";

        public string EntityXML()
        {
            StringBuilder outputBuilder = new StringBuilder();

            using (XmlWriter writer = XmlWriter.Create(outputBuilder))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(BILLING_TAG);

                if (!string.IsNullOrWhiteSpace(Name)) writer.WriteElementString(NAME_TAG, Name);
                if (!string.IsNullOrWhiteSpace(Company)) writer.WriteElementString(COMPANY_TAG, Company);
                if (!string.IsNullOrWhiteSpace(Address1)) writer.WriteElementString(ADDRESS_1_TAG, Address1);
                if (!string.IsNullOrWhiteSpace(Address2)) writer.WriteElementString(ADDRESS_2_TAG, Address2);
                if (!string.IsNullOrWhiteSpace(City)) writer.WriteElementString(CITY_TAG, City);
                if (!string.IsNullOrWhiteSpace(StateProvince)) writer.WriteElementString(STATE_PROVINCE_TAG, StateProvince);
                if (!string.IsNullOrWhiteSpace(ZipCode)) writer.WriteElementString(ZIP_CODE_TAG, ZipCode);
                if (!string.IsNullOrWhiteSpace(Country)) writer.WriteElementString(COUNTRY_TAG, Country);
                if (!string.IsNullOrWhiteSpace(PhoneNumber)) writer.WriteElementString(PHONE_NUMBER_TAG, PhoneNumber);
                if (!string.IsNullOrWhiteSpace(FaxNumber)) writer.WriteElementString(FAX_NUMBER_TAG, FaxNumber);
                if (!string.IsNullOrWhiteSpace(Email)) writer.WriteElementString(EMAIL_TAG, Email);
                if (!string.IsNullOrWhiteSpace(AddressNumber)) writer.WriteElementString(ADDRESS_NUMBER_TAG, AddressNumber);
                if (!string.IsNullOrWhiteSpace(UserID)) writer.WriteElementString(USER_ID_TAG, UserID);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            return outputBuilder.ToString();
        }
    }
}
