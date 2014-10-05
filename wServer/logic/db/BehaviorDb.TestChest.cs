using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wServer.realm;
using wServer.logic.attack;
using wServer.logic.movement;
using wServer.logic.loot;
using wServer.logic.taunt;
using wServer.logic.cond;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        static _ TestChest = Behav()

                 .Init(0x7130, Behaves("Test Chest Guardian",
                 loot: new LootBehavior(LootDef.Empty,
                 Tuple.Create(100, new LootDef(0, 3, 0, 12,
                 Tuple.Create(0.001, (ILoot)new ItemLoot("Bracer of the Guardian")),
				 Tuple.Create(0.0001, (ILoot)new ItemLoot("The Crown of the Forgotten Gemstone Guardian")),
                 Tuple.Create(0.01, (ILoot)new TierLoot(6, ItemType.Ring)),
				 Tuple.Create(0.02, (ILoot)new TierLoot(6, ItemType.Ability)),
				 Tuple.Create(0.02, (ILoot)new TierLoot(13, ItemType.Armor)),
				 Tuple.Create(0.02, (ILoot)new TierLoot(12, ItemType.Weapon)),
				 Tuple.Create(0.5, (ILoot)new StatPotionLoot(StatPotion.Def)),
				 Tuple.Create(0.5, (ILoot)new StatPotionLoot(StatPotion.Att))
                 )))))
				 
				 .Init(0x7131, Behaves("Test Chest Twilight",
                 loot: new LootBehavior(LootDef.Empty,
                 Tuple.Create(100, new LootDef(0, 3, 0, 12,
                 Tuple.Create(0.001, (ILoot)new ItemLoot("Twilight Gemstone")),
				 Tuple.Create(0.002, (ILoot)new ItemLoot("The Crown of the Forgotten Gemstone Guardian")),
                 Tuple.Create(0.01, (ILoot)new TierLoot(6, ItemType.Ring)),
				 Tuple.Create(0.02, (ILoot)new TierLoot(6, ItemType.Ability)),
				 Tuple.Create(0.02, (ILoot)new TierLoot(13, ItemType.Armor)),
				 Tuple.Create(0.02, (ILoot)new TierLoot(12, ItemType.Weapon)),
				 Tuple.Create(0.5, (ILoot)new StatPotionLoot(StatPotion.Mana))
                 )))))
				 
				 .Init(0x7132, Behaves("Test Chest King",
                 loot: new LootBehavior(LootDef.Empty,
                 Tuple.Create(100, new LootDef(0, 3, 0, 12,
                 Tuple.Create(0.02, (ILoot)new ItemLoot("The Forgotten Crown")),
				 Tuple.Create(0.01, (ILoot)new ItemLoot("The Crown of the Forgotten Gemstone Guardian")),
                 Tuple.Create(0.01, (ILoot)new TierLoot(6, ItemType.Ring)),
				 Tuple.Create(0.02, (ILoot)new TierLoot(6, ItemType.Ability)),
				 Tuple.Create(0.02, (ILoot)new TierLoot(13, ItemType.Armor)),
				 Tuple.Create(0.02, (ILoot)new TierLoot(12, ItemType.Weapon)),
				 Tuple.Create(0.5, (ILoot)new StatPotionLoot(StatPotion.Life))
                 )))))

                 .Init(0x716a, Behaves("Test Chest Shaitan",
                 loot: new LootBehavior(LootDef.Empty,
                 Tuple.Create(100, new LootDef(0, 3, 0, 12,
                 Tuple.Create(0.2, (ILoot)new ItemLoot("Tincture of Dexterity")),
                 Tuple.Create(0.2, (ILoot)new ItemLoot("Effusion of Defense")),
				 Tuple.Create(0.2, (ILoot)new StatPotionLoot(StatPotion.Def)),
                 Tuple.Create(0.2, (ILoot)new StatPotionLoot(StatPotion.Att)),
                 Tuple.Create(0.01, (ILoot)new ItemLoot("Skull of Endless Torment")),
                 Tuple.Create(0.01, (ILoot)new ItemLoot("Cpt America Bow")),
                 Tuple.Create(0.01, (ILoot)new ItemLoot("Helm of the Deer Captain"))
                 ))))); 
    }
}