using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brodilka.Snags;

namespace Brodilka
{
    internal class Stone : Snag
    {
        private readonly int stoneSignCode = 19;

        public Stone()
        {

        }

        public Stone(Point currPos, Map currMap) : base(currPos, currMap)
        {
            this.SignCode = stoneSignCode;
        }
    }
}
