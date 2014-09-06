using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using linkpoint_wrapper.LinkpointEntities;

namespace linkpoint_wrapper
{
    public class LinkpointOrder
    {
        private const string ORDER_TAG = "order";

        public ICollection<ILinkpointEntity> LinkpointEntities { get; set; }

        public string OrderXML()
        {
            StringBuilder outputBuilder = new StringBuilder();
            // we're using simple XML syntax, so we don't need to waste the resources of creating a XML writer
            outputBuilder.Append("<" + ORDER_TAG + ">");
            foreach (ILinkpointEntity entity in LinkpointEntities)
            {
                outputBuilder.Append(entity.EntityXML());
            }
            outputBuilder.Append("</" + ORDER_TAG + ">");

            return outputBuilder.ToString();
        }
    }
}
