using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Projectiles.MutantBoss
{
    public class MutantEyeHoming : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_452";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantasmal Eye");
        }

        public override void SetDefaults()
        {
            projectile.width = 4;
            projectile.height = 4;
            projectile.aiStyle = -1;
            projectile.hostile = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.alpha = 0;
            cooldownSlot = 1;
        }

        public override void AI()
        {
            int d = Dust.NewDust(projectile.Center - Vector2.One * 5f, 10, 10, 229, -projectile.velocity.X / 3f, -projectile.velocity.Y / 3f, 150, Color.Transparent, 1.2f);
            Main.dust[d].noGravity = true;

            if (--projectile.ai[1] < 0 && projectile.ai[1] > -300)
            {
                if (projectile.ai[0] >= 0 && projectile.ai[0] < Main.maxPlayers)
                {
                    Player p = Main.player[(int)projectile.ai[0]];
                    
                    Vector2 target = p.Center;

                    if (Math.Abs(p.Center.Y - projectile.Center.Y) > 150)
                    {
                        Vector2 distance = target - projectile.Center;

                        double angle = distance.ToRotation() - projectile.velocity.ToRotation();
                        if (angle > Math.PI)
                            angle -= 2.0 * Math.PI;
                        if (angle < -Math.PI)
                            angle += 2.0 * Math.PI;

                        projectile.velocity = projectile.velocity.RotatedBy(angle * 0.2);
                    }
                    else
                    {
                        projectile.ai[1] = -300;
                    }
                }
                else
                {
                    projectile.ai[0] = Player.FindClosest(projectile.Center, 0, 0);
                }
            }

            if (projectile.ai[1] < 0)
                projectile.velocity = Vector2.Normalize(projectile.velocity) * MathHelper.Lerp(projectile.velocity.Length(), 12f, 0.035f);

            projectile.rotation = projectile.velocity.ToRotation() + 1.570796f;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (target.GetModPlayer<FargoPlayer>().BetsyDashing)
                return;
            if (FargoSoulsWorld.MasochistMode)
            {
                target.GetModPlayer<FargoPlayer>().MaxLifeReduction += 100;
                target.AddBuff(mod.BuffType("OceanicMaul"), 5400);
                target.AddBuff(mod.BuffType("MutantFang"), 180);
            }
            target.AddBuff(mod.BuffType("CurseoftheMoon"), 360);
            projectile.timeLeft = 0;
        }

        public override void Kill(int timeleft)
        {
            Main.PlaySound(SoundID.Zombie, (int)projectile.position.X, (int)projectile.position.Y, 103, 1f, 0.0f);
            projectile.position = projectile.Center;
            projectile.width = projectile.height = 144;
            projectile.position.X -= (float)(projectile.width / 2);
            projectile.position.Y -= (float)(projectile.height / 2);
            for (int index = 0; index < 2; ++index)
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
            for (int index1 = 0; index1 < 20; ++index1)
            {
                int index2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 229, 0.0f, 0.0f, 0, new Color(), 2.5f);
                Main.dust[index2].noGravity = true;
                Dust dust1 = Main.dust[index2];
                dust1.velocity = dust1.velocity * 3f;
                int index3 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 229, 0.0f, 0.0f, 100, new Color(), 1.5f);
                Dust dust2 = Main.dust[index3];
                dust2.velocity = dust2.velocity * 2f;
                Main.dust[index3].noGravity = true;
            }
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White * projectile.Opacity;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D13 = Main.projectileTexture[projectile.type];
            int num156 = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type]; //ypos of lower right corner of sprite to draw
            int y3 = num156 * projectile.frame; //ypos of upper left corner of sprite to draw
            Rectangle rectangle = new Rectangle(0, y3, texture2D13.Width, num156);
            Vector2 origin2 = rectangle.Size() / 2f;
            Main.spriteBatch.Draw(texture2D13, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), projectile.GetAlpha(lightColor), projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}