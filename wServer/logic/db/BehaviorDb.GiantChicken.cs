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
        static _ Egg = Behav()
            .Init(0x0e18, Behaves("Test Egg",
            new RunBehaviors(
                 HpLesser.Instance(630000,
                     SetAltTexture.Instance(1)),
                     HpLesser.Instance(610000,
                     SetAltTexture.Instance(2)),
                     HpLesser.Instance(590000,
                     SetAltTexture.Instance(3)),
                     HpLesser.Instance(570000,
                     SetAltTexture.Instance(4))
                     ),
                         new QueuedBehavior(
                         HpLesser.Instance(569999,
                       Once.Instance(SpawnMinionImmediate.Instance(0x0e17, 1, 1, 1))
                       ))
                     ))
                     .Init(0x7134, Behaves("Giant Oryx Chicken",
                     new RunBehaviors(
                    Once.Instance(SetSize.Instance(0)),
                    If.Instance(IsEntityPresent.Instance(6, null), Once.Instance(new SetKey(-1, 1))),
                    IfEqual.Instance(-1, 1,
                        new RunBehaviors(
                            new QueuedBehavior(
                                SetAltTexture.Instance(4),
                                CooldownExact.Instance(125),
                                SetSize.Instance(25),
                                CooldownExact.Instance(125),
                                SetSize.Instance(50),
                                CooldownExact.Instance(125),
                                SetSize.Instance(75),
                                CooldownExact.Instance(125),
                                SetSize.Instance(100),
                                new SetKey(-1, 2)
                                ))),
                    IfEqual.Instance(-1, 2,
                        new RunBehaviors(
                            If.Instance(IsEntityNotPresent.Instance(100, 0x0e35),
                                new SetKey(-1, 3)
                                ),
                            If.Instance(IsEntityPresent.Instance(100, 0x0e35),
                                new SetKey(-1, 4)
                                )
                            ))),
                     new RunBehaviors(
                         Once.Instance(new SimpleTaunt("CLUCK!")),
                         SimpleWandering.Instance(4, 2f),
                         OrderAllEntity.Instance(20, 0x0e18, Despawn.Instance),
                         Once.Instance(new SimpleTaunt("Buck buck...")),
                         Cooldown.Instance(400, (MultiAttack.Instance(5, 0, 2, projectileIndex: 1))),
                         Cooldown.Instance(4000, (RingAttack.Instance(4, 0, 2, projectileIndex: 2))),
                         Cooldown.Instance(1000, (PredictiveMultiAttack.Instance(15, 15 * (float)Math.PI / 180, 2, 1, projectileIndex: 3))),
                         Cooldown.Instance(750, PredictiveRingAttack.Instance(5, .5f, 12, 4)),
                         Cooldown.Instance(1250, PredictiveMultiAttack.Instance(12, 10 * (float)Math.PI / 180, 5, 8)),
                         Once.Instance(new SimpleTaunt("CLLLUUUCKKK!!!"))
                         ),
                        loot: new LootBehavior(LootDef.Empty,
                        Tuple.Create(100, new LootDef(0, 5, 2, 8,
                            Tuple.Create(0.01, (ILoot)new TierLoot(5, ItemType.Ability)),
                            Tuple.Create(0.01, (ILoot)new TierLoot(13, ItemType.Armor)),
                            Tuple.Create(0.01, (ILoot)new TierLoot(12, ItemType.Weapon)),

                            Tuple.Create(0.01, (ILoot)new TierLoot(5, ItemType.Ring)),

                            Tuple.Create(0.02, (ILoot)new TierLoot(6, ItemType.Ability)),
                            Tuple.Create(0.02, (ILoot)new TierLoot(11, ItemType.Armor)),
                            Tuple.Create(0.02, (ILoot)new TierLoot(12, ItemType.Weapon)),

                            Tuple.Create(0.2, (ILoot)new StatPotionLoot(StatPotion.Att)),
                            Tuple.Create(0.2, (ILoot)new StatPotionLoot(StatPotion.Def)),

                            Tuple.Create(0.003, (ILoot)new ItemLoot("Chicken Leg of Doom")),
                            Tuple.Create(0.003, (ILoot)new ItemLoot("Anatis Staff"))
                    )))
                        ));
      }
   }