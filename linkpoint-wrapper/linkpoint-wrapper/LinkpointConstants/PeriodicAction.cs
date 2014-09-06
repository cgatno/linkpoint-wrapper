using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkpoint_wrapper.LinkpointConstants
{
    public sealed class PeriodicAction
    {
        private readonly string value;

        public PeriodicAction SubmitForProcessing = new PeriodicAction("SUBMIT");
        public PeriodicAction ModifyPrior = new PeriodicAction("MODIFY");
        public PeriodicAction CancelPrior = new PeriodicAction("CANCEL");

        private PeriodicAction(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }
}
