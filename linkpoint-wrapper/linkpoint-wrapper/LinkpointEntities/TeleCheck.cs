using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using linkpoint_wrapper.LinkpointConstants;

namespace linkpoint_wrapper.LinkpointEntities
{
    public class TeleCheck : ILinkpointEntity
    {
        private const string BANK_ACCOUNT_NUMBER_TAG = "account";
        public string BankAccountNumber { get; set; }

        private const string BANK_ROUTING_NUMBER_TAG = "routing";
        public string BankRoutingNumber { get; set; }

        private const string CHECK_NUMBER_TAG = "checknumber";
        public string CheckNumber { get; set; }

        private const string BANK_NAME_TAG = "bankname";
        public string BankName { get; set; }

        private const string BANK_STATE_TAG = "bankstate";
        public string BankState { get; set; }

        private const string DRIVERS_LICENSE_NUMBER_TAG = "dl";
        public string DriversLicenseNumber { get; set; }

        private const string DRIVERS_LICENSE_STATE_TAG = "dlstate";
        public string DriversLicenseState { get; set; }

        private const string VOID_FLAG_TAG = "void";
        public bool VoidFlag { get; set; }

        private const string ACCOUNT_TYPE_FLAG = "accounttype";
        public AccountType AccountType { get; set; }

        private const string SOCIAL_SECURITY_NUMBER_TAG = "ssn";
        public string SocialSecurityNumber { get; set; }

        private const string TELE_CHECK_TAG = "telecheck";
        public string EntityXML()
        {
            StringBuilder outputBuilder = new StringBuilder();

            using (XmlWriter writer = XmlWriter.Create(outputBuilder))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(TELE_CHECK_TAG);

                if (!string.IsNullOrWhiteSpace(BankAccountNumber)) writer.WriteElementString(BANK_ACCOUNT_NUMBER_TAG, BankAccountNumber);
                if (!string.IsNullOrWhiteSpace(BankRoutingNumber)) writer.WriteElementString(BANK_ROUTING_NUMBER_TAG, BankRoutingNumber);
                if (!string.IsNullOrWhiteSpace(CheckNumber)) writer.WriteElementString(CHECK_NUMBER_TAG, CheckNumber);
                if (!string.IsNullOrWhiteSpace(BankName)) writer.WriteElementString(BANK_NAME_TAG, BankName);
                if (!string.IsNullOrWhiteSpace(BankState)) writer.WriteElementString(BANK_STATE_TAG, BankState);
                if (!string.IsNullOrWhiteSpace(DriversLicenseNumber)) writer.WriteElementString(DRIVERS_LICENSE_NUMBER_TAG, DriversLicenseNumber);
                if (!string.IsNullOrWhiteSpace(DriversLicenseState)) writer.WriteElementString(DRIVERS_LICENSE_STATE_TAG, DriversLicenseState);
                if (VoidFlag) writer.WriteElementString(VOID_FLAG_TAG, "1");
                if (AccountType != null) writer.WriteElementString(ACCOUNT_TYPE_FLAG, AccountType.ToString());
                if (!string.IsNullOrWhiteSpace(SocialSecurityNumber)) writer.WriteElementString(SOCIAL_SECURITY_NUMBER_TAG, SocialSecurityNumber);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            return outputBuilder.ToString();
        }
    }
}
