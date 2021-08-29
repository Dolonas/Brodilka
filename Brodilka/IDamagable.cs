using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brodilka
{
    internal interface IDamagable
    {
        void GetDamage(int damage);

        void ToDamage(Unit unit, int hitDamege);
        
    }
}
