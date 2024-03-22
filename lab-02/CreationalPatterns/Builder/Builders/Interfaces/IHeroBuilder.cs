using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Builders.Interfaces;
public interface IHeroBuilder : ICharacterBuilder<IHeroBuilder>
{
    IHeroBuilder AddInventoryItems(List<string> loot);
    IHeroBuilder ResetInventory();
    Hero Build();
}