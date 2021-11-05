using System.Collections.Generic;

namespace Attack
{
    public interface IAttacker
    {
        void Attack(List<Attack> attacks);
    }
}