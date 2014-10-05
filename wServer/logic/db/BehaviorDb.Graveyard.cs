using System;
using wServer.logic.attack;
using wServer.logic.loot;
using wServer.logic.movement;
using wServer.logic.taunt;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private static _ Death = Behav()
            .Init(0x7151, Behaves("Death.obj.CustomMob1",
                new RunBehaviors(
                    new State("flash",
                        SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                        Once.Instance(
                    new RunBehaviors(new SimpleTaunt("You killed many Enemys."))),
                        Timed.Instance(24000, False.Instance(Flashing.Instance(250, 0xffffff00))),
                        CooldownExact.Instance(5000, Once.Instance(new SimpleTaunt("You gave me many work."))),
                        CooldownExact.Instance(10000,
                            Once.Instance(new SimpleTaunt("But can you kill the Death?"))),
                        CooldownExact.Instance(15000,
                            Once.Instance(new SimpleTaunt("I gave you a mindfuck, didn't I?"))),
                        CooldownExact.Instance(20000, Once.Instance(new SimpleTaunt("One last wish?"))),
                        CooldownExact.Instance(22000, Once.Instance(new SimpleTaunt("Well, to late!"))),
                        CooldownExact.Instance(24000, UnsetConditionEffect.Instance(ConditionEffectIndex.Invulnerable)),
                        CooldownExact.Instance(24000, SetState.Instance("battle"))
                        ),
                    new State("battle",
                        Chasing.Instance(1, 10, 5, null),
                        Cooldown.Instance(2500, RingAttack.Instance(16, projectileIndex: 0)),
                        Cooldown.Instance(1500, PredictiveMultiAttack.Instance(25, 10 * (float)Math.PI / 180, 3, 1, 1))
                        )),
                        HpLesserPercent.Instance(2000, 
                        SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                        SetState.Instance("respawn")),
                    new State("respawn",
                        Once.Instance(new SimpleTaunt("...")),
                        CooldownExact.Instance(2000, UnsetConditionEffect.Instance(ConditionEffectIndex.Invulnerable)),
                        CooldownExact.Instance(2000, SpawnMinionImmediate.Instance(0x7152, 1, 1, 1))
                           ))
                        )

              .Init(0x7152, Behaves("realDeath.obj.CustomMob1",
                 new RunBehaviors(
                        CooldownExact.Instance(500,new SimpleTaunt("Now you're going to die!")
                             ),
                        Cooldown.Instance(500, RingAttack.Instance(8, projectileIndex: 0)),
                        Cooldown.Instance(1000, MultiAttack.Instance(25, 50 * (float)Math.PI / 180, 3, 0, 1)),
                        Cooldown.Instance(1200, MultiAttack.Instance(25, 50 * (float)Math.PI / 180, 3, 0, 2))
                        ),
                      loot: new LootBehavior(LootDef.Empty,                                  
                          Tuple.Create(100, new LootDef(0, 5, 0, 10,
                            Tuple.Create(0.01, (ILoot)new ItemLoot("Potion of Maxy")),
                            Tuple.Create(0.01, (ILoot)new ItemLoot("Death Shield")),
                            Tuple.Create(0.01, (ILoot)new ItemLoot("Helm of the Deer Captain")),
                            Tuple.Create(0.01, (ILoot)new ItemLoot("The mighty Crown of Onyx")),
                            Tuple.Create(0.01, (ILoot)new ItemLoot("Molten Ice Armor"))
                        ))))
        );
    }
}
