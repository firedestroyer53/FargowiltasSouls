using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace FargowiltasSouls.Buffs
{
    public class TwinsInstall : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Twins Install");
            Description.SetDefault("Effects of Cursed Inferno and Ichor");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.onFire2 = true;
            player.ichor = true;
            if (player.buffTime[buffIndex] < 2)
                player.buffTime[buffIndex] = 2;
        }
    }
}