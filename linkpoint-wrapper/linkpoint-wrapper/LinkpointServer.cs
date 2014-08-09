using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LPICOM_6_0Lib;

namespace linkpoint_wrapper
{
    /// <summary>
    /// A static class for quickly connecting and sending data to Linkpoint servers.
    /// </summary>
    static class LinkpointServer
    {
        /// <summary>
        /// Sends raw XML data to the Linkpoint servers using the parameters specified and gives the raw XML response.
        /// </summary>
        /// <param name="CertificatePath">The local path to the security certificate provided by FirstData.</param>
        /// <param name="Host">The Linkpoint server hostname or address.</param>
        /// <param name="Port">The port through which to connect to Linkpoint servers.</param>
        /// <param name="XML">The XML data to be sent to Linkpoint servers for processing.</param>
        /// <returns>Returns the raw response XML from Linkpoint servers.</returns>
        public static string SendXML(string CertificatePath, string Host, int Port, string XML)
        {
            LinkPointTxn txn = new LinkPointTxn();
            return txn.send(CertificatePath, Host, Port, XML);
        }

        /// <summary>
        /// Sends raw XML to the Linkpoint servers using the parameters stored in the LinkpointWrapperHelper and gives the raw XML response.
        /// </summary>
        /// <param name="WrapperHelper">An initialized LinkpointWrapperHelper class containing your store and server properties.</param>
        /// <param name="XML">The XML data to be sent to Linkpoint servers for processing.</param>
        /// <returns>Returns the raw response XML from Linkpoint servers.</returns>
        public static string SendXML(LinkpointWrapperHelper WrapperHelper, string XML)
        {
            LinkPointTxn txn = new LinkPointTxn();
            return txn.send(WrapperHelper.SecurityCertificatePath, WrapperHelper.LinkpointHostname, WrapperHelper.LinkpointPort, XML);
        }

        /// <summary>
        /// Attempts to obtain a string representation of the current version of the Linkpoint COM object.
        /// </summary>
        /// <returns>A string representation of the current version of the Linkpoint COM object. If the data cannot be converted to a string, a null value is returned.</returns>
        public static string GetVersion()
        {
            LinkPointTxn txn = new LinkPointTxn();
            return txn.getVersion() as string;
        }
    }
}
