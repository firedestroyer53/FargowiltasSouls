﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FargowiltasSouls.NPCs;

namespace FargowiltasSouls.Projectiles.Masomode
{
    public class SkeletronBone : ModProjectile
    {
        public override string Texture => "Terraria/Images/Projectile_471";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.SkeletonBone);
            AIType = ProjectileID.SkeletonBone;
            projectile.light = 1f;
            projectile.scale = 1.5f;
            projectile.timeLeft = 240;
            projectile.tileCollide = false;
            if (FargoSoulsUtil.BossIsAlive(ref EModeGlobalNPC.guardBoss, NPCID.DungeonGuardian)
                || (FargoSoulsUtil.BossIsAlive(ref EModeGlobalNPC.skeleBoss, NPCID.SkeletronHead) && Main.npc[EModeGlobalNPC.skeleBoss].ai[1] == 2f))
            {
                CooldownSlot = 1;
            }
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (FargoSoulsUtil.BossIsAlive(ref EModeGlobalNPC.guardBoss, NPCID.DungeonGuardian))
            {
                target.AddBuff(ModContent.BuffType<MarkedforDeath>(), 300);
                /*target.AddBuff(ModContent.BuffType<GodEater>(), 420);
                target.AddBuff(ModContent.BuffType<FlamesoftheUniverse>(), 420);
                target.immune = false;
                target.immuneTime = 0;
                target.hurtCooldowns[1] = 0;*/
            }
            target.AddBuff(ModContent.BuffType<Lethargic>(), 300);
        }
    }
}