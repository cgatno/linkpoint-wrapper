using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LPICOM_6_0Lib;

namespace linkpoint_wrapper
{
    static class LinkpointServer
    {
        public static string SendXML(string CertificatePath, string Host, int Port, string XML)
        {
            LinkPointTxn txn = new LinkPointTxn();
            return txn.send(CertificatePath, Host, Port, XML);
        }
    }
}
