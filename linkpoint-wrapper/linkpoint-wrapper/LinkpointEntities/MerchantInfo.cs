using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace linkpoint_wrapper.LinkpointEntities
{
    class MerchantInfo : ILinkpointEntity
    {
        private const string STORE_NUMBER_TAG = "configfile";
        public string StoreNumber { get; set; }

        private const string SECURITY_CERTIFICATE_PATH_TAG = "keyfile";
        public string SecurityCertificatePath { get; set; }

        private const string LINKPOINT_HOSTNAME_TAG = "host";
        public string LinkpointHostname { get; set; }

        private const string LINKPOINT_PORT_TAG = "port";
        public int LinkpointPort { get; set; }

        public MerchantInfo()
        {
        }

        public MerchantInfo(LinkpointWrapperHelper WrapperHelper)
        {
            this.StoreNumber = WrapperHelper.StoreNumber;
            this.SecurityCertificatePath = WrapperHelper.SecurityCertificatePath;
            this.LinkpointHostname = WrapperHelper.LinkpointHostname;
            this.LinkpointPort = WrapperHelper.LinkpointPort;
        }

        private const string MERCHANT_INFO_TAG = "merchantinfo";

        public string GetEntityXML()
        {
            StringBuilder outputBuilder = new StringBuilder();

            using (XmlWriter writer = XmlWriter.Create(outputBuilder))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(MERCHANT_INFO_TAG);

                writer.WriteElementString(STORE_NUMBER_TAG, StoreNumber);
                writer.WriteElementString(SECURITY_CERTIFICATE_PATH_TAG, SecurityCertificatePath);
                writer.WriteElementString(LINKPOINT_HOSTNAME_TAG, LinkpointHostname);
                writer.WriteElementString(LINKPOINT_PORT_TAG, LinkpointPort.ToString());

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            return outputBuilder.ToString();
        }
    }
}
