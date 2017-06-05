using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsDataProcessing
{
    public class Shop
    {
        public int ShopCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class Price
    {
        public int ShopCode { get; set; }
        public int GoodCode { get; set; }
        public int GoodPrice { get; set; }
        public int Discount { get; set; }
    }

    public class Good
    {
        public int GoodCode { get; set; }
        public string GoodName { get; set; }
        public string Category { get; set; }
    }

    class Processing
    {
        public List<Shop> Shops { get; set; }
        public List<Price> Prices { get; set; }
        public List<Good> Goods { get; set; }


    }
}
