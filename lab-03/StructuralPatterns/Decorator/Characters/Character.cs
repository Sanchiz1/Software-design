using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Characters;
public abstract class Character : ICharacter
{
    public readonly string Name = default!;
    public decimal HitPoints = 100;
    public int Damage = 100;

    public Character(string name, decimal hitPoints, int damage)
    {
        Name = name;
        HitPoints = hitPoints;
        Damage = damage;
    }

    public virtual void TakeDamage(int damage)
    {
        var newHitPoints = this.HitPoints - damage;

        SetHitPoints(newHitPoints);
    }

    public virtual void Attack(ICharacter character)
    {
        character.TakeDamage(this.GetDamage());
    }

    private void SetHitPoints(decimal hitPoints)
    {
        if (hitPoints < 0) hitPoints = 0;

        this.HitPoints = hitPoints;
    }

    public virtual int GetDamage()
    {
        return this.Damage;
    }

    public virtual string GetDatails()
    {
        return $"{this.Name}, HP - {this.HitPoints}, Damage - {this.Damage}";
    }
}
