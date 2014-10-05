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
        static _ Random = Behav()
            .Init(0x7127, Behaves("Failed Experiment",
                new RunBehaviors(
                        HpGreaterEqual.Instance(5000,
                            new RunBehaviors(
                                Circling.Instance(10, 100, 5, 0x0d25),
                                Cooldown.Instance(1000, Heal.Instance(6f, 100, 0x0d28)),
                                Cooldown.Instance(1000, Heal.Instance(6f, 100, 0x0d27))
                            )
                        ),
                        HpLesserPercent.Instance(0.99f,
                    new RunBehaviors(

                        Cooldown.Instance(2000, MultiAttack.Instance(10, 10 * (float)Math.PI / 180, 1, 0, projectileIndex: 5)),
                        Cooldown.Instance(5000, MultiAttack.Instance(10, 10 * (float)Math.PI / 180, 1, 0, projectileIndex: 6)),
                        Cooldown.Instance(3000, MultiAttack.Instance(10, 45 * (float)Math.PI / 180, 10, 0, projectileIndex: 1)),
                        Cooldown.Instance(3500, MultiAttack.Instance(10, 45 * (float)Math.PI / 180, 10, 0, projectileIndex: 2)),
                        Cooldown.Instance(3500, MultiAttack.Instance(10, 45 * (float)Math.PI / 180, 10, 0, projectileIndex: 3)),
                        Cooldown.Instance(3500, MultiAttack.Instance(10, 45 * (float)Math.PI / 180, 10, 0, projectileIndex: 4)),
                        Cooldown.Instance(5000, MultiAttack.Instance(10, 45 * (float)Math.PI / 180, 7, 0, projectileIndex: 0))
                    )),
                        HpLesserPercent.Instance(0.0625f,
                            new RunBehaviors(
                                Flashing.Instance(500, 0xffff3333),
                                Chasing.Instance(8, 10, 0, null),
                                Cooldown.Instance(3000, MultiAttack.Instance(25, 45 * (float)Math.PI / 180, 10, 0, projectileIndex: 1)),
                                Cooldown.Instance(3500, MultiAttack.Instance(25, 45 * (float)Math.PI / 180, 10, 0, projectileIndex: 2)),
                                Cooldown.Instance(3500, MultiAttack.Instance(25, 45 * (float)Math.PI / 180, 10, 0, projectileIndex: 3)),
                                Cooldown.Instance(500, MultiAttack.Instance(25, 10 * (float)Math.PI / 180, 5, 0, projectileIndex: 8)),
                                Cooldown.Instance(700, MultiAttack.Instance(25, 10 * (float)Math.PI / 180, 1, 0, projectileIndex: 5)),
                                Cooldown.Instance(4000, MultiAttack.Instance(25, 10 * (float)Math.PI / 180, 2, 0, projectileIndex: 6)),
                                Once.Instance(new SimpleTaunt("This cannot be! You shall not succeed!"))
                            ))

                    ),
                    loot: new LootBehavior(LootDef.Empty,
                            Tuple.Create(100, new LootDef(0, 2, 0, 2,
                            Tuple.Create(0.9, (ILoot)new ItemLoot("Potion of Life")),
                            Tuple.Create(0.005, (ILoot)new ItemLoot("Holy Dagger")),
                            Tuple.Create(0.005, (ILoot)new ItemLoot("Holy Poison")),
                            Tuple.Create(0.005, (ILoot)new ItemLoot("Holy Silk Armor")),
                            Tuple.Create(0.005, (ILoot)new ItemLoot("Holy Cross"))
                           )))))
				.Init(0x0e78, Behaves("Nexus Crier",
					   Cooldown.Instance(60000, new SimpleTaunt("Thanks for playing on this Server!")),
					   Cooldown.Instance(60000, new SimpleTaunt("Look at the Forums to see new updates and share your ideas! http://project-b.forumieren.net/")),
					   Cooldown.Instance(60000, new SimpleTaunt("Healing Pets at /shop pets!"))
					  ))
				.Init(0x023b, Behaves("Exp Chicken",
				new RunBehaviors(
				       SmoothWandering.Instance(3, 2),
				       Cooldown.Instance(5000, new SimpleTaunt("Buck.. BUCK!"))
										)));
    }
}