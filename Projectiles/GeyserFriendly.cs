﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Projectiles
{
    public class GeyserFriendly : ModProjectile
    {
        public override string Texture => "FargowiltasSouls/Projectiles/Explosion";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Geyser");
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.GeyserTrap);
            Projectile.trap = false;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Melee;
            AIType = ProjectileID.GeyserTrap;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 600);
        }
    }
}