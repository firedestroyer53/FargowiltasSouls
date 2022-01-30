﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Projectiles.Masomode
{
    public class ElfCopterBullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Explosive Bullet");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.ExplosiveBullet);
            AIType = ProjectileID.Bullet;
            projectile.friendly = false;
            projectile.ranged = false;
            projectile.hostile = true;
        }

        public override void Kill(int timeLeft)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
                Projectile.NewProjectile(projectile.Center, Vector2.Zero, ModContent.ProjectileType<ElfCopterBulletExplosion>(), projectile.damage, projectile.knockBack, projectile.owner);
        }
    }
}