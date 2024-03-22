using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder;
public class Hero
{
    public string Name { get; set; } = null!;
    public string Weapon { get; set; } = null!;
    public ArmorType ArmorType { get; set; } = ArmorType.NoArmor;
    public decimal HitPoints { get; set; }
    public int Damage { get; set; }
    public List<string> Inventory { get; set; } = new List<string>();

    public void TakeDamage(int damage)
    {
        var newHitPoints = this.HitPoints - (damage - damage / 100m * (int)ArmorType);

        SetHitPoints(newHitPoints);
    }

    private void SetHitPoints(decimal hitPoints)
    {
        if (hitPoints < 0) hitPoints = 0;

        this.HitPoints = hitPoints;
    }

    public bool TryDefeatEnemy(Enemy enemy)
    {
        enemy.TakeDamage(this.Damage);

        if(enemy.HitPoints <= 0)
        {
            this.Inventory.AddRange(enemy.Loot);

            enemy.Loot.Clear();

            return true;
        }

        this.TakeDamage(enemy.Damage);

        return false;
    }

    public string GetInventoryList()
    {
        return "Inventory:\n\t" + string.Join("\n\t", Inventory);
    }

    public override string ToString()
    {
        return $"Hero {Name}, Weapon - {Weapon}, Armor - {ArmorType}, HP - {HitPoints}, Damage - {Damage}\n{GetInventoryList()}";
    }
}
