using FargowiltasSouls.Buffs.Masomode;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Projectiles.Masomode
{
    public class PrimeGuardian : MutantBoss.MutantGuardian
    {
        public override string Texture => "Terraria/Images/NPC_127";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dungeon Guardian Prime");
            Main.projFrames[Projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.timeLeft = 600;
            CooldownSlot = -1;
        }

        public override bool CanHitPlayer(Player target)
        {
            return true;
        }

        public override void AI()
        {
            if (Projectile.localAI[0] == 0)
            {
                Projectile.localAI[0] = 1;
                Projectile.rotation = Main.rand.NextFloat(0, 2 * (float)Math.PI);
                Projectile.hide = false;

                for (int i = 0; i < 30; i++)
                {
                    int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0, 0, 100, default(Color), 2f);
                    Main.dust[dust].noGravity = true;
                }
            }

            Projectile.frame = 2;
            Projectile.direction = Projectile.velocity.X < 0 ? -1 : 1;
            Projectile.rotation += Projectile.direction * .3f;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(ModContent.BuffType<NanoInjection>(), 480);
            target.AddBuff(ModContent.BuffType<Defenseless>(), 480);
            target.AddBuff(ModContent.BuffType<Lethargic>(), 480);
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 30; i++)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0, 0, 100, default(Color), 2f);
                Main.dust[dust].noGravity = true;
            }

            if (!Main.dedServ)
                Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity / 3, ModContent.Find<ModGore>(Mod.Name, Main.rand.NextBool() ? "Gore_149" : "Gore_150").Type, Projectile.scale);
        }
    }
}

