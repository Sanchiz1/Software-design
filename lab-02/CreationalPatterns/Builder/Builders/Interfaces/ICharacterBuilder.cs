using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Builders.Interfaces;

public interface ICharacterBuilder<T> where T : ICharacterBuilder<T>
{
    T AddName(string name);
    T AddWeapon(string weapon);
    T AddArmor(ArmorType type);
    T AddHitPoints(decimal hitPoints);
    T AddDamage(int damage);
}
