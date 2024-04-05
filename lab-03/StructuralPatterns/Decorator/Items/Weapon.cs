using Decorator.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Items;
public class Weapon : InventoryDecorator
{
    private readonly int WeaponAttack;
    private readonly string Name = default!;
    public Weapon(ICharacter character, int weaponAttack, string name) : base(character)
    {
        this.WeaponAttack = weaponAttack;
        this.Name = name;
    }

    public override int GetDamage()
    {
        return this.Character.GetDamage() + this.WeaponAttack;
    }

    public override string GetDatails()
    {
        return this.Character.GetDatails() + $", with weapon {this.Name} (Damage {this.WeaponAttack})";
    }
}
