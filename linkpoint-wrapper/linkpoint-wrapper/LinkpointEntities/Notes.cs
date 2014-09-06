using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace linkpoint_wrapper.LinkpointEntities
{
    public class Notes : ILinkpointEntity
    {
        private const string COMMENTS_TAG = "comments";
        public string Comments { get; set; }

        private const string REFERER_TAG = "referred";
        public string Referer { get; set; }

        private const string NOTES_TAG = "notes";
        public string EntityXML()
        {
            StringBuilder outputBuilder = new StringBuilder();

            using (XmlWriter writer = XmlWriter.Create(outputBuilder))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(NOTES_TAG);

                if (!string.IsNullOrWhiteSpace(Comments)) writer.WriteElementString(COMMENTS_TAG, Comments);
                if (!string.IsNullOrWhiteSpace(Referer)) writer.WriteElementString(REFERER_TAG, Referer);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            return outputBuilder.ToString();
        }
    }
}
