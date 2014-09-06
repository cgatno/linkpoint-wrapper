using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkpoint_wrapper
{
    /// <summary>
    /// Stores information necessary to connect to the Linkpoint server using a certain Linkpoint account
    /// </summary>
    public class LinkpointWrapperHelper
    {
        /// <summary>
        /// The Linkpoint store number associated with your store/account
        /// </summary>
        public string StoreNumber { get; set; }
        /// <summary>
        /// The port to use when connecting to the Linkpoint server
        /// </summary>
        public int LinkpointPort { get; set; }
        /// <summary>
        /// The Linkpoint server hostname
        /// </summary>
        public string LinkpointHostname { get; set; }
        /// <summary>
        /// The absolute path to the security certificate you received from Linkpoint
        /// </summary>
        public string SecurityCertificatePath { get; set; }

        /// <summary>
        /// Initiates the helper class with all of its properties
        /// </summary>
        /// <param name="LinkpointPort">The port to use when connecting to the Linkpoint server</param>
        /// <param name="LinkpointHostname">The Linkpoint server hostname</param>
        /// <param name="SecurityCertificatePath">The absolute path to the security certificate you received from Linkpoint</param>
        /// <param name="StoreNumber">The Linkpoint store number associated with your store/account</param>
        public LinkpointWrapperHelper(int LinkpointPort, string LinkpointHostname, string SecurityCertificatePath, string StoreNumber)
        {
            this.LinkpointPort = LinkpointPort;
            this.LinkpointHostname = LinkpointHostname;
            this.SecurityCertificatePath = SecurityCertificatePath;
            this.StoreNumber = StoreNumber;
        }

        /// <summary>
        /// Initiates the helper class with all properties necessary to connect to the Linkpoint servers
        /// </summary>
        /// <param name="LinkpointPort">The port to use when connecting to the Linkpoint server</param>
        /// <param name="LinkpointHostname">The Linkpoint server hostname</param>
        /// <param name="SecurityCertificatePath">The absolute path to the security certificate you received from Linkpoint</param>
        public LinkpointWrapperHelper(int LinkpointPort, string LinkpointHostname, string SecurityCertificatePath)
        {
            this.LinkpointPort = LinkpointPort;
            this.LinkpointHostname = LinkpointHostname;
            this.SecurityCertificatePath = SecurityCertificatePath;
        }

        public static string LinkpointMoneyFormat(decimal MoneyAmount)
        {
            return string.Format("{0:C0}", Convert.ToInt32(MoneyAmount)).Remove(0, 1);
        }
    }
}
