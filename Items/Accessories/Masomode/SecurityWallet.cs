using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Items.Accessories.Masomode
{
    public class SecurityWallet : ModItem
    {
        public override string Texture => "FargowiltasSouls/Items/Placeholder";
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Security Wallet");
            Tooltip.SetDefault(@"'Results not guaranteed in multiplayer'
Grants immunity to Midas and enemies that steal items
Prevents you from reforging items with certain modifiers
Protected modifiers can be chosen in the toggles menu");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.rare = 5;
            item.value = Item.sellPrice(0, 4);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[mod.BuffType("Midas")] = true;
            player.GetModPlayer<FargoPlayer>().SecurityWallet = true;
        }
    }
}
