using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Builders.Interfaces;
public interface IEnemyBuilder : ICharacterBuilder<IEnemyBuilder>
{
    IEnemyBuilder AddLootItems(List<string> loot);
    IEnemyBuilder ResetLoot();
    Enemy Build();
}
