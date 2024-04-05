using Decorator.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Items;
public class Armor : InventoryDecorator
{
    private readonly int ArmorDefence;
    private readonly string Name = default!;
    public Armor(ICharacter character, int armorDefence, string name) : base(character)
    {
        this.ArmorDefence = armorDefence;
        this.Name = name;
    }

    public override void TakeDamage(int damage)
    {
        this.Character.TakeDamage(damage - this.ArmorDefence);
    }

    public override string GetDatails()
    {
        return this.Character.GetDatails() + $", with armor {this.Name} (Defence {this.ArmorDefence})";
    }
}
