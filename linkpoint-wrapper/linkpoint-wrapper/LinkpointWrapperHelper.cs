using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkpoint_wrapper
{
    class LinkpointWrapperHelper
    {
        public string StoreNumber { get; set; }
        public int LinkpointPort { get; set; }
        public string LinkpointHostname { get; set; }
        public string SecurityCertificatePath { get; set; }

        public LinkpointWrapperHelper(string StoreNumber, int LinkpointPort, string LinkpointHostname, string SecurityCertificatePath)
        {
            this.StoreNumber = StoreNumber;
            this.LinkpointPort = LinkpointPort;
            this.LinkpointHostname = LinkpointHostname;
            this.SecurityCertificatePath = SecurityCertificatePath;
        }
    }
}
