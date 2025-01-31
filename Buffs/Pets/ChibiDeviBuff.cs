﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace FargowiltasSouls.Buffs.Pets
{
    public class ChibiDeviBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chibi Devi");
            Description.SetDefault("She's interested in 'you'");
            Main.buffNoTimeDisplay[Type] = true;
            Main.lightPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<FargoSoulsPlayer>().ChibiDevi = true;
            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.ChibiDevi>()] <= 0 && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Pets.ChibiDevi>(), 0, 0f, player.whoAmI);
            }
        }
    }
}