﻿using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using FargowiltasSouls.Projectiles.JungleMimic;

namespace FargowiltasSouls.Items.Weapons.Misc
{
    public class OvergrownKey : SoulsItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Overgrown Key");
            Tooltip.SetDefault("Summons a Jungle Mimic to fight for you\nNeeds 2 minion slots");
            ItemID.Sets.StaffMinionSlotsRequired[item.type] = 2;
        }

        public override void SetDefaults()
        {
            item.mana = 10;
            item.damage = 30;
            item.useStyle = ItemUseStyleID.Shoot;
            item.shootSpeed = 14f;
            item.width = 36;
            item.height = 16;
            item.UseSound = SoundID.Item77;
            item.useAnimation = 37;
            item.useTime = 37;
            item.noMelee = true;
            item.value = Item.sellPrice(0, 8);
            item.knockBack = 2f;
            item.rare = ItemRarityID.LightRed;
            Item.DamageType = DamageClass.Summon;
            item.shoot = ModContent.ProjectileType<JungleMimicSummon>();
            item.buffType = ModContent.BuffType<JungleMimicSummonBuff>();
        }

        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.AddBuff(item.buffType, 2);
            position = Main.MouseWorld;
            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
    }
}