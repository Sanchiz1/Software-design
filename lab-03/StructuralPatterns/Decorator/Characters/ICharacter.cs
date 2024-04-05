using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Characters;
public interface ICharacter
{
    int GetDamage();

    string GetDatails();
    void TakeDamage(int damage);

    void Attack(ICharacter character);
}
