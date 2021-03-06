﻿#region

using System;
using Mono.Game;
using wServer.realm;
using wServer.realm.entities;
using wServer.realm.entities.player;
using wServer.svrPackets;

#endregion

namespace wServer.logic.cond
{
    internal class PetsHealingHP : Behavior
    {
        private readonly int highest;
        private readonly int lowest;

        public PetsHealingHP(int lowest, int highest)
        {
            this.lowest = lowest;
            this.highest = highest;
        }

        protected override bool TickCore(RealmTime time)
        {
            float dist = 10;
            var entity = Host.Self.PlayerOwner;


            if (entity == Host.Self.PlayerOwner & entity.HasConditionEffect(ConditionEffects.Sick) == false)
            {
                try
                {
                    var distance = Vector2.Distance(new Vector2(Host.Self.X, Host.Self.Y),
                        new Vector2(Host.Self.PlayerOwner.X, Host.Self.PlayerOwner.Y));
                    if (distance < 10)
                    {
                        var hp = entity.HP;
                        var maxHp = entity.Stats[0] + entity.Boost[0];
                        hp = Math.Min(hp + new Random().Next(lowest, highest), maxHp);

                        if (hp != entity.HP)
                        {
                            var n = hp - entity.HP;
                            entity.HP = hp;
                            entity.UpdateCount++;
                            entity.Owner.BroadcastPacket(new ShowEffectPacket
                            {
                                EffectType = EffectType.Potion,
                                TargetId = entity.Id,
                                Color = new ARGB(0xffff0000)
                            }, null);
                            entity.Owner.BroadcastPacket(new ShowEffectPacket
                            {
                                EffectType = EffectType.Trail,
                                TargetId = Host.Self.Id,
                                PosA = new Position {X = entity.X, Y = entity.Y},
                                Color = new ARGB(0xffff0000)
                            }, null);
                            entity.Owner.BroadcastPacket(new NotificationPacket
                            {
                                ObjectId = entity.Id,
                                Text = "+" + n,
                                Color = new ARGB(0xffff0000)
                            }, null);
                            return true;
                        }
                        entity = GetNearestEntity(ref dist, null) as Player;
                    }
                }
                catch
                {
                }
            }
            return false;
        }
    }
}

//cerpyright (c)