using Builder.Builders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Builder.Builders;
public class EnemyBuilder : IEnemyBuilder
{
    public string Name { get; set; }
    public string Weapon { get; set; }
    public ArmorType ArmorType { get; set; } = ArmorType.NoArmor;
    public decimal HitPoints { get; set; }
    public int Damage { get; set; }
    public List<string> Loot { get; set; } = new List<string>();

    public IEnemyBuilder AddName(string name)
    {
        this.Name = name;

        return this;
    }

    public IEnemyBuilder AddWeapon(string weapon)
    {
        this.Weapon = weapon;

        return this;
    }

    public IEnemyBuilder AddArmor(ArmorType type)
    {
        this.ArmorType = type;

        return this;
    }

    public IEnemyBuilder AddHitPoints(decimal hitPoints)
    {
        if (hitPoints < 0)
            throw new ArgumentOutOfRangeException(nameof(hitPoints), hitPoints, "Hit points cannot be less than 0");

        this.HitPoints = hitPoints;

        return this;
    }

    public IEnemyBuilder AddDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage), damage, "Damage points cannot be less than 0");

        this.Damage = damage;

        return this;
    }

    public IEnemyBuilder AddLootItems(List<string> loot)
    {
        this.Loot.AddRange(loot);

        return this;
    }

    public IEnemyBuilder ResetLoot()
    {
        this.Loot.Clear();

        return this;
    }

    public Enemy Build()
    {
        return new Enemy()
        {
            Name = Name,
            Weapon = Weapon,
            ArmorType = ArmorType,
            HitPoints = HitPoints,
            Damage = Damage,
            Loot = Loot
        };
    }
}
