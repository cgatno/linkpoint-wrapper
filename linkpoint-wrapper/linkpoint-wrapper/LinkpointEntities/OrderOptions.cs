using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using linkpoint_wrapper.LinkpointConstants;

namespace linkpoint_wrapper.LinkpointEntities
{
    public class OrderOptions : ILinkpointEntity
    {
        private const string ORDER_TYPE_TAG = "ordertype";
        public OrderType OrderType { get; set; }

        private const string ORDER_MODE_TAG = "result";
        public OrderMode OrderMode { get; set; }

        private const string ORDER_OPTIONS_TAG = "orderoptions";

        public string EntityXML()
        {
            StringBuilder outputBuilder = new StringBuilder();

            using (XmlWriter writer = XmlWriter.Create(outputBuilder))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(ORDER_OPTIONS_TAG);

                if (OrderType != null) writer.WriteElementString(ORDER_TYPE_TAG, OrderType.ToString());
                if (OrderMode != null) writer.WriteElementString(ORDER_MODE_TAG, OrderMode.ToString());

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            return outputBuilder.ToString();
        }
    }
}
