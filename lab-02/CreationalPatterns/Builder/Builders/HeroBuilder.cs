using Builder.Builders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Builders;
public class HeroBuilder : IHeroBuilder
{
    public string Name { get; set; }
    public string Weapon { get; set; }
    public ArmorType ArmorType { get; set; } = ArmorType.NoArmor;
    public decimal HitPoints { get; set; }
    public int Damage { get; set; }
    public List<string> Inventory { get; set; } = new List<string>();

    public IHeroBuilder AddName(string name)
    {
        this.Name = name;

        return this;
    }

    public IHeroBuilder AddWeapon(string weapon)
    {
        this.Weapon = weapon;

        return this;
    }

    public IHeroBuilder AddArmor(ArmorType type)
    {
        this.ArmorType = type;

        return this;
    }

    public IHeroBuilder AddHitPoints(decimal hitPoints)
    {
        this.HitPoints = hitPoints;

        return this;
    }

    public IHeroBuilder AddDamage(int damage)
    {
        this.Damage = damage;

        return this;
    }

    public IHeroBuilder AddInventoryItems(List<string> inventory)
    {
        this.Inventory.AddRange(inventory);

        return this;
    }

    public IHeroBuilder ResetInventory()
    {
        this.Inventory.Clear();

        return this;
    }
    public Hero Build()
    {
        return new Hero()
        {
            Name = Name,
            Weapon = Weapon,
            ArmorType = ArmorType,
            HitPoints = HitPoints,
            Damage = Damage,
            Inventory = Inventory
        };
    }
}
