using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Items.Accessories.Masomode
{
    public class PureHeart : ModItem
    {
        public override string Texture => "FargowiltasSouls/Items/Placeholder";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pure Heart");
            Tooltip.SetDefault(@"'It pulses with vitality'
Grants immunity to Rotting and Bloodthirsty
Grants immunity to biome debuffs
20% increased movement speed and 20% increased max life
You spawn mini eaters to seek out enemies every few attacks
Creepers hover around you blocking some damage
A new Creeper appears every 15 seconds, and 5 can exist at once");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.rare = 6;
            item.value = Item.sellPrice(0, 4);
            item.defense = 6;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            FargoPlayer fargoPlayer = player.GetModPlayer<FargoPlayer>();
            fargoPlayer.PureHeart = true;

            player.buffImmune[mod.BuffType("Rotting")] = true;
            player.moveSpeed += 0.2f;
            fargoPlayer.CorruptHeart = true;
            if (fargoPlayer.CorruptHeartCD > 0)
                fargoPlayer.CorruptHeartCD--;

            player.buffImmune[mod.BuffType("Bloodthirsty")] = true;
            fargoPlayer.GuttedHeart = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(mod.ItemType("CorruptHeart"));
            recipe.AddIngredient(mod.ItemType("GuttedHeart"));
            recipe.AddIngredient(ItemID.PurificationPowder, 30);
            recipe.AddIngredient(ItemID.GreenSolution, 50);

            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
