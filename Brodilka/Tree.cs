using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brodilka
{
    internal class Tree : Snag
    {
        private readonly int treeSigncode = 14;

        public Tree() 
        {          

        }

        public Tree(Pos currPos, Map currMap) : base (currPos, currMap)
        {
            this.SignCode = treeSigncode;
        }
    }
}
