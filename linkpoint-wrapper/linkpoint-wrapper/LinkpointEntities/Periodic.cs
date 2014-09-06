using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using linkpoint_wrapper.LinkpointConstants;

namespace linkpoint_wrapper.LinkpointEntities
{
    public class Periodic : ILinkpointEntity
    {
        private const string ACTION_TAG = "action";
        public PeriodicAction Action { get; set; }

        private const string NUMBER_OF_INSTALLMENTS_TAG = "installments";
        public int NumberOfInstallments { get; set; }

        private const string FAILED_RETRY_THRESHOLD_TAG = "threshold";
        private int mFailedRetryThreshold = 0;
        public int FailedRetryThreshold
        {
            get
            {
                // The failed retry threshold can't be 0, so if it isn't defined, return 1
                if (mFailedRetryThreshold == 0)
                {
                    return 1;
                }
                else
                {
                    return mFailedRetryThreshold;
                }
            }
            set
            {
                mFailedRetryThreshold = value;
            }
        }

        public Periodicity Periodicity { get; set; }

        private int mInterval = 0;
        public int Interval
        {
            get
            {
                // The interval can't be 0, so if it isn't defined, return 1
                if (mInterval == 0)
                {
                    return 1;
                }
                else
                {
                    return mInterval;
                }
            }
            set
            {
                mInterval = value;
            }
        }

        private const string LINKPOINT_PERIODICITY_TAG = "periodicity";
        public string LinkpointPeriodicity
        {
            get
            {
                if (Periodicity != null)
                {
                    return Periodicity.ToString() + Interval.ToString();
                }
                else
                {
                    throw new NullReferenceException("The Periodicity property must be set before LinkpointPeriodicity can be defined");
                }
            }
        }

        private const string START_DATE_TAG = "startdate";
        public DateTime StartDate { get; set; }

        private const string COMMENTS_TAG = "comments";
        public string Comments { get; set; }

        private const string PERIODIC_TAG = "periodic";
        public string EntityXML()
        {
            StringBuilder outputBuilder = new StringBuilder();

            using (XmlWriter writer = XmlWriter.Create(outputBuilder))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(PERIODIC_TAG);

                if (Action != null) writer.WriteElementString(ACTION_TAG, Action.ToString());
                writer.WriteElementString(NUMBER_OF_INSTALLMENTS_TAG, NumberOfInstallments.ToString());
                writer.WriteElementString(FAILED_RETRY_THRESHOLD_TAG, FailedRetryThreshold.ToString());
                if (Periodicity != null) writer.WriteElementString(LINKPOINT_PERIODICITY_TAG, LinkpointPeriodicity);
                if (StartDate != null) writer.WriteElementString(START_DATE_TAG, StartDate.ToString("yyyyMMdd") == DateTime.Now.ToString("yyyyMMdd") ? "immediate" : StartDate.ToString("yyyyMMdd"));
                if (!string.IsNullOrWhiteSpace(Comments)) writer.WriteElementString(COMMENTS_TAG, Comments);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            return outputBuilder.ToString();
        }
    }
}
