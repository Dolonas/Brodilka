using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brodilka.Snags;

namespace Brodilka
{
    internal class Tree : Snag
    {
        private readonly int treeSigncode = 14;

        public Tree() 
        {          

        }

        public Tree(Point currPos, Map currMap) : base (currPos, currMap)
        {
            this.SignCode = treeSigncode;
        }
    }
}
