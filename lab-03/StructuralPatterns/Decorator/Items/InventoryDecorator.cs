using Decorator.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Items;
public abstract class InventoryDecorator : ICharacter
{
    protected readonly ICharacter Character;

    public InventoryDecorator(ICharacter character)
    {
        this.Character = character;
    }

    public virtual void TakeDamage(int damage)
    {
        this.Character.TakeDamage(damage);
    }

    public void Attack(ICharacter character)
    {
        character.TakeDamage(this.GetDamage());
    }

    public virtual int GetDamage()
    {
        return this.Character.GetDamage();
    }

    public virtual string GetDatails()
    {
        return this.Character.GetDatails();
    }
}
