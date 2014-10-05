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
        static _ Candy = Behav()
            .Init(0x7129, Behaves("Gigacorn",
            attack: new RunBehaviors(
                    new QueuedBehavior(
                        Cooldown.Instance(500, RingAttack.Instance(12, 20, projectileIndex: 1)),
                        Cooldown.Instance(500, RingAttack.Instance(6, 20, offset: 60, projectileIndex: 0))
                    ),
                    Cooldown.Instance(1500, RingAttack.Instance(20, 20, projectileIndex: 1)),
                    new State("idle",
                        CooldownExact.Instance(8000, SetState.Instance("dying"))
                    ),
                    new State("dying",
                        Timed.Instance(4000, False.Instance(Flashing.Instance(200, 0xff00ff00))),
                        CooldownExact.Instance(4000, SetState.Instance("idle"))
                    )
                ),
						loot: new LootBehavior(LootDef.Empty,                                  
                       Tuple.Create(100, new LootDef(0, 5, 0, 10,
					        Tuple.Create(0.9, (ILoot)new StatPotionLoot(StatPotion.Wis)),
							Tuple.Create(0.9, (ILoot)new StatPotionLoot(StatPotion.Att)),
                            Tuple.Create(0.001, (ILoot)new ItemLoot("Candy Sword")),
                            Tuple.Create(0.001, (ILoot)new ItemLoot("Candy Seal")),
                            Tuple.Create(0.01, (ILoot)new ItemLoot("Candy-Coated Armor")),
                            Tuple.Create(0.001, (ILoot)new ItemLoot("Candy Ring"))

                            ))
                        ))

        );
    }
}