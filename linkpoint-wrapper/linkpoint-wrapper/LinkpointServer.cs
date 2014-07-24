using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LPICOM_6_0Lib;

namespace linkpoint_wrapper
{
    class LinkpointServer
    {

        private int mPort = 0;
        private string mCertPath = String.Empty;
        private string mHost = string.Empty;
        LinkPointTxn txn;

        public LinkpointServer(int Port, string CertificatePath, string Host)
        {
            mPort = Port;
            mCertPath = CertificatePath;
            mHost = Host;
            txn = new LinkPointTxn();
        }

        public string SendXML(string XML)
        {
            return txn.send(mCertPath, mHost, mPort, XML);
        }

        public string GetVersion()
        {
            return txn.getVersion() as String;
        }
    }
}
