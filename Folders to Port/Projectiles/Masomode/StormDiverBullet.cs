﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Projectiles.Masomode
{
    public class StormDiverBullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Luminite Bullet");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.MoonlordBullet);
            AIType = ProjectileID.MoonlordBullet;
            projectile.friendly = false;
            projectile.ranged = false;
            projectile.hostile = true;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(ModContent.BuffType<LightningRod>(), 300);
            target.AddBuff(ModContent.BuffType<ClippedWings>(), 120);
        }
    }
}