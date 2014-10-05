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
        static _ EpicUndeadLair = Behav()
            .Init(0x712c, Behaves("Gender the Ghost Goddness",
                new RunBehaviors(
                  SmoothWandering.Instance(0.5f, 0.5f)
                ),
                Once.Instance(IsEntityPresent.Instance(1, null)),
                new QueuedBehavior(
        #region Circle Attack 1

                    Cooldown.Instance(150),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 0 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 18 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 36 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 54 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 72 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 90 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 108 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 126 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 144 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 162 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 180 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 198 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 216 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 234 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 252 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 270 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 288 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 306 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 324 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 342 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(250),
                      new RunBehaviors(
                          UnsetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                          RingAttack.Instance(3, offset: 360 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(100),
        #endregion

        #region Circle Attack 2
 Cooldown.Instance(150),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 0 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 18 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 36 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 54 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 72 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 90 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 108 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 126 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 144 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 162 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 180 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 198 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 216 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 234 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 252 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 270 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          UnsetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                          RingAttack.Instance(3, offset: 288 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 306 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 324 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 342 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(250),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 360 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(100),
        #endregion
            //not used
        #region Circle Attack 3
            /*Cooldown.Instance(150),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 0 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 18 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 36 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 54 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 72 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 90 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 108 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 126 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 144 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 162 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 180 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 198 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 216 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 234 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 252 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 270 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 288 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 306 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 324 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 342 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(250),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 360 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(100),*/
        #endregion

        #region Circle Attack 4
            /*Cooldown.Instance(150),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 0 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 18 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 36 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 54 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 72 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 90 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 108 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 126 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 144 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 162 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 180 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 198 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 216 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 234 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 252 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 270 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 288 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 306 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 324 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 342 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(250),
                      new RunBehaviors(
                          SimpleAttack.Instance(5, projectileIndex: 3),
                          RingAttack.Instance(3, offset: 360 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(100),*/
        #endregion
            //end

        #region RingAttack + Flashing 1

                    new QueuedBehavior(
                        SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                        Flashing.Instance(500, 0x0000FF0C),
                        Flashing.Instance(500, 0x0000FF0C),
                        Flashing.Instance(500, 0x0000FF0C),
                        Flashing.Instance(500, 0x0000FF0C),
                        Cooldown.Instance(500, RingAttack.Instance(12, 10, 12, projectileIndex: 3)),
                        Cooldown.Instance(500, RingAttack.Instance(12, 10, 12, projectileIndex: 3)),
                        Cooldown.Instance(500, RingAttack.Instance(12, 10, 12, projectileIndex: 3)),
                        Cooldown.Instance(500, RingAttack.Instance(12, 10, 12, projectileIndex: 3)),
                        Cooldown.Instance(500, RingAttack.Instance(12, 10, 12, projectileIndex: 3)),
                        Cooldown.Instance(500, RingAttack.Instance(12, 10, 12, projectileIndex: 3)),

        #endregion

        #region Flashing 2

 Flashing.Instance(200, 0x0000FF0C),
                        Flashing.Instance(200, 0x0000FF0C),
                        Flashing.Instance(200, 0x0000FF0C),
                        Flashing.Instance(200, 0x0000FF0C),
                        Flashing.Instance(200, 0x0000FF0C),
                        Flashing.Instance(200, 0x0000FF0C),
                        Flashing.Instance(200, 0x0000FF0C),
                        Flashing.Instance(200, 0x0000FF0C),
                        UnsetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),

        #endregion

        #region Quite + Confuse
            //confuse
                        MultiAttack.Instance(10, 1 * (float)Math.PI / 30, 3, 0, projectileIndex: 2),
            //end confuse
            //quite
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 0 * (float)Math.PI / 180, projectileIndex: 1)),
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 90 * (float)Math.PI / 180, projectileIndex: 1)),
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 180 * (float)Math.PI / 180, projectileIndex: 1)),
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 270 * (float)Math.PI / 180, projectileIndex: 1)),
            //end quite
            //confuse
                        MultiAttack.Instance(10, 1 * (float)Math.PI / 30, 3, 0, projectileIndex: 2),
            //end confuse
            //quite
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 360 * (float)Math.PI / 180, projectileIndex: 1)),
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 0 * (float)Math.PI / 180, projectileIndex: 1)),
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 90 * (float)Math.PI / 180, projectileIndex: 1)),
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 180 * (float)Math.PI / 180, projectileIndex: 1)),
            //end quite
            //confuse
                        SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                        MultiAttack.Instance(10, 1 * (float)Math.PI / 30, 3, 0, projectileIndex: 2),
            //end confuse
            //quite
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 270 * (float)Math.PI / 180, projectileIndex: 1)),
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 360 * (float)Math.PI / 180, projectileIndex: 1)),
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 0 * (float)Math.PI / 180, projectileIndex: 1)),
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 90 * (float)Math.PI / 180, projectileIndex: 1)),
            //end quite
            //confuse
                        MultiAttack.Instance(10, 1 * (float)Math.PI / 30, 3, 0, projectileIndex: 2),
            //end confuse
            //quite
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 180 * (float)Math.PI / 180, projectileIndex: 1)),
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 270 * (float)Math.PI / 180, projectileIndex: 1)),
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 360 * (float)Math.PI / 180, projectileIndex: 1)),
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 0 * (float)Math.PI / 180, projectileIndex: 1)),
            //end quite
            //confuse
                        MultiAttack.Instance(10, 1 * (float)Math.PI / 30, 3, 0, projectileIndex: 2),
                        UnsetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
            //end confuse
            //quite
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 90 * (float)Math.PI / 180, projectileIndex: 1)),
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 180 * (float)Math.PI / 180, projectileIndex: 1)),
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 270 * (float)Math.PI / 180, projectileIndex: 1)),
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 360 * (float)Math.PI / 180, projectileIndex: 1)),
            //end quite
            //confuse
                        MultiAttack.Instance(10, 1 * (float)Math.PI / 30, 3, 0, projectileIndex: 2),
            //end confuse
            //quite
                        SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 0 * (float)Math.PI / 180, projectileIndex: 1)),
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 90 * (float)Math.PI / 180, projectileIndex: 1)),
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 180 * (float)Math.PI / 180, projectileIndex: 1)),
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 270 * (float)Math.PI / 180, projectileIndex: 1)),
            //end quite
            //confuse
                        MultiAttack.Instance(10, 1 * (float)Math.PI / 30, 3, 0, projectileIndex: 2),
            //end confuse
            //quite
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 360 * (float)Math.PI / 180, projectileIndex: 1)),
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 0 * (float)Math.PI / 180, projectileIndex: 1)),
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 90 * (float)Math.PI / 180, projectileIndex: 1)),
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 180 * (float)Math.PI / 180, projectileIndex: 1)),
                        Cooldown.Instance(500, RingAttack.Instance(10, 10, offset: 270 * (float)Math.PI / 180, projectileIndex: 1)),
            //end quite

                        Cooldown.Instance(1500),
                        UnsetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),

        #endregion


        #region Spawn Minions + Circleshoot

        #region Spawn Minions

            //SetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),
            //IsEntityNotPresent.Instance(100, 0x0db0),
            //IsEntityNotPresent.Instance(100, 0x0db1),
            //IsEntityNotPresent.Instance(100, 0x0db2),
            //UnsetConditionEffect.Instance(ConditionEffectIndex.Invulnerable),

                        SpawnMinionImmediate.Instance(0x0db0, 0, 4, 6),
                        SpawnMinionImmediate.Instance(0x0db1, 0, 4, 6),
                        SpawnMinionImmediate.Instance(0x0db2, 0, 4, 6),

        #endregion

        #region Circleshoot

        #region Circle Attack 1

 Cooldown.Instance(150),
                      new RunBehaviors(
                          MultiAttack.Instance(5, 1 * (float)Math.PI / 30, 3, 0, projectileIndex: 4),
                          RingAttack.Instance(3, offset: 0 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 18 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 36 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 54 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 72 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          MultiAttack.Instance(5, 1 * (float)Math.PI / 30, 3, 0, projectileIndex: 4),
                          RingAttack.Instance(3, offset: 90 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 108 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 126 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 144 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 162 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          MultiAttack.Instance(5, 1 * (float)Math.PI / 30, 3, 0, projectileIndex: 4),
                          RingAttack.Instance(3, offset: 180 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 198 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 216 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 234 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 252 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          MultiAttack.Instance(5, 1 * (float)Math.PI / 30, 3, 0, projectileIndex: 4),
                          RingAttack.Instance(3, offset: 270 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 288 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 306 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 324 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 342 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(250),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 360 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(100),
        #endregion

        #region Circle Attack 2

 Cooldown.Instance(150),
                      new RunBehaviors(
                          MultiAttack.Instance(5, 1 * (float)Math.PI / 30, 3, 0, projectileIndex: 4),
                          RingAttack.Instance(3, offset: 0 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 18 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 36 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 54 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 72 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          MultiAttack.Instance(5, 1 * (float)Math.PI / 30, 3, 0, projectileIndex: 4),
                          RingAttack.Instance(3, offset: 90 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 108 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 126 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 144 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 162 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          MultiAttack.Instance(5, 1 * (float)Math.PI / 30, 3, 0, projectileIndex: 4),
                          RingAttack.Instance(3, offset: 180 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 198 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 216 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 234 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 252 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          MultiAttack.Instance(5, 1 * (float)Math.PI / 30, 3, 0, projectileIndex: 4),
                          RingAttack.Instance(3, offset: 270 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 288 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 306 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 324 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(150),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 342 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(250),
                      new RunBehaviors(
                          RingAttack.Instance(3, offset: 360 * (float)Math.PI / 180)
                    ),
                    Cooldown.Instance(1100))
        #endregion

        #endregion

        #endregion
                ),
                loot: new LootBehavior(LootDef.Empty,
                        Tuple.Create(100, new LootDef(0, 5, 1, 2,
                            Tuple.Create(0.02, (ILoot)new ItemLoot("Skyfall Wand")),
                            Tuple.Create(0.02, (ILoot)new ItemLoot("Bloody Marry")),
                            Tuple.Create(0.2, (ILoot)new ItemLoot("Lil' Gender Generator")),
							
                            
							Tuple.Create(0.9, (ILoot)new StatPotionLoot(StatPotion.Life)),
                            Tuple.Create(0.1, (ILoot)new TierLoot(17, ItemType.Armor)),
                            Tuple.Create(0.1, (ILoot)new TierLoot(15, ItemType.Weapon)),
							Tuple.Create(0.1, (ILoot)new TierLoot(9, ItemType.Ability))
)))
                        ));
      }
   }