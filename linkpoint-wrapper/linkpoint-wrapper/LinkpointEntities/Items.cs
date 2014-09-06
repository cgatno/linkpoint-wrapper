using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace linkpoint_wrapper.LinkpointEntities
{
    class Items : ILinkpointEntity
    {
        private const string ITEMS_ENTITY_TAG = "items";
        private const string ITEM_TAG = "item";
        private const string ITEM_ID_TAG = "id";
        private const string ITEM_DESCRIPTION_TAG = "description";
        private const string ITEM_PRICE_TAG = "price";
        private const string ITEM_QUANTITY_TAG = "quantity";
        private const string OPTIONS_TAG = "options";
        private const string OPTION_SINGLE_TAG = "option";
        private const string OPTION_NAME_TAG = "name";
        private const string OPTION_VALUE_TAG = "value";

        public class LinkpointItem
        {
            public string ID { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            private int mQuantity = 0;
            public int Quantity
            {
                get
                {
                    // The quantity must be greater than 0
                    if (mQuantity == 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return mQuantity;
                    }
                }
                set
                {
                    mQuantity = value;
                }
            }
            public Dictionary<string, string> Options { get; set; }
        }

        public ICollection<LinkpointItem> ItemList { get; set; }

        public string EntityXML()
        {
            StringBuilder outputBuilder = new StringBuilder();

            using (XmlWriter writer = XmlWriter.Create(outputBuilder))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(ITEMS_ENTITY_TAG);

                foreach (LinkpointItem it in ItemList)
                {
                    writer.WriteStartElement(ITEM_TAG);

                    if (!string.IsNullOrWhiteSpace(it.ID)) writer.WriteElementString(ITEM_ID_TAG, it.ID);
                    if (!string.IsNullOrWhiteSpace(it.Description)) writer.WriteElementString(ITEM_DESCRIPTION_TAG, it.Description);
                    writer.WriteElementString(ITEM_PRICE_TAG, LinkpointWrapperHelper.LinkpointMoneyFormat(it.Price));
                    writer.WriteElementString(ITEM_QUANTITY_TAG, it.Quantity.ToString());
                    if (it.Options.Count != 0)
                    {
                        writer.WriteStartElement(OPTIONS_TAG);

                        foreach (KeyValuePair<string, string> pair in it.Options)
                        {
                            writer.WriteStartElement(OPTION_SINGLE_TAG);
                            writer.WriteElementString(OPTION_NAME_TAG, pair.Key);
                            writer.WriteElementString(OPTION_VALUE_TAG, pair.Value);
                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            return outputBuilder.ToString();
        }
    }
}
