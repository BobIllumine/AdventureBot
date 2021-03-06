﻿using AdventureBot;
using AdventureBot.Item;
using AdventureBot.ObjectManager;
using AdventureBot.User;
using AdventureBot.User.Stats;

namespace Content.Items
{
    [Item("item/energy")]
    public class EnergyDrink : ItemBase
    {
        public override StructFlag<BuyGroup> Group => new StructFlag<BuyGroup>(BuyGroup.Market);
        public override string Name => "Энергетик";
        public override string Description => "Для тех, кто хочет жить опасно";
        public override decimal? Price => 100;
        public override string Identifier => "item/energy";
        public override StatsEffect Effect => null;

        public override bool CanUse(User user, ItemInfo info)
        {
            return true;
        }

        public override void OnUse(User user, ItemInfo info)
        {
            user.Info.ChangeStats(StatsProperty.Stamina, user.Info.MaxStats.Effect[StatsProperty.Stamina]);
        }
    }
}