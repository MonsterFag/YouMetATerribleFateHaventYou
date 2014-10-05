using System;
using wServer.logic.attack;
using wServer.logic.loot;
using wServer.logic.movement;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private static _ Shaitan = Behav()
            .Init(0x7167, Behaves("Shaitan the Advisor",
                new RunBehaviors(
                     Cooldown.Instance(1500,
                    PredictiveMultiAttack.Instance(25, 10*(float) Math.PI/180, 12, 1, projectileIndex: 0))),
                    Cooldown.Instance(2000, SimpleAttack.Instance(12, 1)),
                    HpLesserPercent.Instance(0.1f,
                    new QueuedBehavior(
                        SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                            Once.Instance(SpawnMinionImmediate.Instance(0x716a, 1, 1, 1)),
                            Timed.Instance(1000, Flashing.Instance(1500, 0xffff0000)),
                            Die.Instance
                  ))
                ));
    }
}
