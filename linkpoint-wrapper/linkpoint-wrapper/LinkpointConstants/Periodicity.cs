using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkpoint_wrapper.LinkpointConstants
{
    public sealed class Periodicity
    {
        private readonly string value;

        public Periodicity Daily = new Periodicity("d");
        public Periodicity Monthly = new Periodicity("m");
        public Periodicity Yearly = new Periodicity("y");

        private Periodicity(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }
}
