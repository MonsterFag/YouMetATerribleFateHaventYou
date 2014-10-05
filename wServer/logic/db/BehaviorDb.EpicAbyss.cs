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
        static _ MalphasSon = Behav()
            .Init(0x7126, Behaves("Malphas Son",
            new RunBehaviors(
                    new State("idle",
                        SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                        If.Instance(
                            IsEntityPresent.Instance(5, null),
                            new RunBehaviors(
                                SetState.Instance("attack")
                            )
                        )
                    ),
                    new State("attack",
                        Chasing.Instance(2, 8, 4, null),
                        Cooldown.Instance(1000, SimpleAttack.Instance(8)),
                        CooldownExact.Instance(8000, SetSize.Instance(90)),
                        CooldownExact.Instance(8100, SetSize.Instance(80)),
                        CooldownExact.Instance(8200, SetSize.Instance(70)),
                        CooldownExact.Instance(8300, SetSize.Instance(60)),
                        CooldownExact.Instance(8400, SetSize.Instance(50)),
                        CooldownExact.Instance(8500, SetState.Instance("small"))
                    ),
                    new State("small",
                        SimpleWandering.Instance(2),
                        Cooldown.Instance(1000, RingAttack.Instance(4, projectileIndex: 1)),
                        Cooldown.Instance(1000, SimpleAttack.Instance(8)),
                        CooldownExact.Instance(8000, SetSize.Instance(70)),
                        CooldownExact.Instance(8100, SetSize.Instance(90)),
                        CooldownExact.Instance(8200, SetSize.Instance(110)),
                        CooldownExact.Instance(8300, SetSize.Instance(130)),
                        CooldownExact.Instance(8400, SetSize.Instance(150)),
                        CooldownExact.Instance(8500, SetState.Instance("large"))
                    ),
                    new State("large",
                        SimpleWandering.Instance(2),
                        Cooldown.Instance(1000, RingAttack.Instance(4, projectileIndex: 3)),
                        Cooldown.Instance(1000, SimpleAttack.Instance(8, projectileIndex: 2)),
                        CooldownExact.Instance(8000, SetSize.Instance(140)),
                        CooldownExact.Instance(8100, SetSize.Instance(130)),
                        CooldownExact.Instance(8200, SetSize.Instance(120)),
                        CooldownExact.Instance(8300, SetSize.Instance(110)),
                        CooldownExact.Instance(8400, SetSize.Instance(100)),
                        CooldownExact.Instance(8500, SetState.Instance("attack"))
                    )
                ),
                new QueuedBehavior(
                    CooldownExact.Instance(4000, UnsetConditionEffect.Instance(ConditionEffectIndex.Invulnerable)),
                    CooldownExact.Instance(3000, SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable))
                ),
                loot: new LootBehavior(LootDef.Empty,
                        Tuple.Create(100, new LootDef(0, 5, 1, 2,
                            Tuple.Create(0.09, (ILoot)new ItemLoot("Real Demon Blade")),
                            Tuple.Create(0.09, (ILoot)new ItemLoot("Lil' Malphas Son Generator")),
                            Tuple.Create(0.9, (ILoot)new StatPotionLoot(StatPotion.Life)),
                            Tuple.Create(0.1, (ILoot)new TierLoot(17, ItemType.Armor)),
                            Tuple.Create(0.1, (ILoot)new TierLoot(15, ItemType.Weapon)),
							Tuple.Create(0.1, (ILoot)new TierLoot(9, ItemType.Ability))
                           )))
                )
            );
    }
}