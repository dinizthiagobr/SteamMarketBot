using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamMarketBot.Classes
{
    class Item
    {
        public string item;
        public int desiredPrice;
        public string type;

        public Item(string _item, int _desiredPrice, string _type)
        {
            this.item = _item;
            this.desiredPrice = _desiredPrice;
            this.type = _type;
        }
    }
}
