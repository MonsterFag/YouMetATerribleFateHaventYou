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
        static _ PirateKing = Behav()
            .Init(0x712d, Behaves("Jon Bilgewater the Pirate King",
            new RunBehaviors(
                       


                        Cooldown.Instance(15000, new SimpleTaunt("Check out AWESOME CANNON CLUSTER!"))
                        
                    ),
                    new RunBehaviors(
                        HpGreaterEqual.Instance(15000,
                            new RunBehaviors(
                                
                               Cooldown.Instance(3000, PredictiveMultiAttack.Instance(25, 10 * (float)Math.PI / 180, 9, 1, projectileIndex: 0)),
                       Cooldown.Instance(1500, RingAttack.Instance(10, 7, 0, projectileIndex: 1))
                            )
                        ),
                        HpLesserPercent.Instance(5000,
                          new RunBehaviors(
                          Cooldown.Instance(1500, RingAttack.Instance(10, 7, 0, projectileIndex: 0)),
                       
                         Cooldown.Instance(1500, RingAttack.Instance(10, 7, 0, projectileIndex: 1))
                        
                            )
                        
                            )
                        ),
                loot: new LootBehavior(LootDef.Empty,
                        Tuple.Create(100, new LootDef(0, 5, 1, 2,
                            Tuple.Create(0.1, (ILoot)new ItemLoot("Pirate King's Cutlass")),
							Tuple.Create(0.01, (ILoot)new ItemLoot("Real Pirate King's Cutlass")),
							
							Tuple.Create(0.8, (ILoot)new StatPotionLoot(StatPotion.Dex)),
							Tuple.Create(0.8, (ILoot)new StatPotionLoot(StatPotion.Spd)),
                            Tuple.Create(0.1, (ILoot)new TierLoot(12, ItemType.Weapon)),
							Tuple.Create(0.1, (ILoot)new TierLoot(13, ItemType.Armor)),
							Tuple.Create(0.1, (ILoot)new TierLoot(6, ItemType.Ability))
)))
                        ));
      }
   }