using Builder.Builders;
using Builder.Builders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder;
public class CharacterDirector
{
    private readonly IHeroBuilder _heroBuilder;
    private readonly IEnemyBuilder _enemyBuilder;

    public CharacterDirector()
    {
        _heroBuilder = new HeroBuilder();
        _enemyBuilder = new EnemyBuilder();
    }

    public Hero BuildDreamHero()
    {
        return _heroBuilder
            .AddName("Great Paladin")
            .AddArmor(ArmorType.IronArmor)
            .AddWeapon("Hummer")
            .AddInventoryItems(["Healing potion", "Iron skin potion"])
            .AddInventoryItems(["Lucky stone"])
            .AddHitPoints(100)
            .AddDamage(200)
            .Build();
    }

    public Enemy BuildNightmareEnemy()
    {
        return _enemyBuilder
            .AddName("Green Ork")
            .AddArmor(ArmorType.MagicArmor)
            .AddWeapon("Axe")
            .AddDamage(70)
            .AddHitPoints(100)
            .AddLootItems(["Bag of gold", "Iron skin potion"])
            .Build();
    }
}
