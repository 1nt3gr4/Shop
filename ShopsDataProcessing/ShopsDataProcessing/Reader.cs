using System.Collections.Generic;
using System.IO;

namespace ShopsDataProcessing
{
    public interface IReader
    {
        List<Shop> Shops { get; set; }
        List<Price> Prices { get; set; }
        List<Good> Goods { get; set; }
        void Read(string shopsPath, string pricesPath, string goodsPath);

    }

    public class Shop
    {
        public int ShopCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Shop(string sc, string n, string a)
        {
            ShopCode = int.Parse(sc);
            Name = n;
            Address = a;
        }
    }

    public class Price
    {
        public int ShopCode { get; set; }
        public int GoodCode { get; set; }
        public int GoodPrice { get; set; }
        public int Discount { get; set; }

        public Price(string sc, string gc, string gp, string ds)
        {
            ShopCode = int.Parse(sc);
            GoodCode = int.Parse(gc);
            GoodPrice = int.Parse(gp);
            Discount = int.Parse(ds);
        }
    }

    public class Good
    {
        public int GoodCode { get; set; }
        public string GoodName { get; set; }
        public string Category { get; set; }

        public Good(string gc, string gn, string c)
        {
            GoodCode = int.Parse(gc);
            GoodName = gn;
            Category = c;
        }
    }

    class Reader : IReader
    {
        public List<Shop> Shops { get; set; }
        public List<Price> Prices { get; set; }
        public List<Good> Goods { get; set; }

        public void Read(string shopsPath, string pricesPath, string goodsPath)
        {
            
            Shops = new List<Shop>();
            Prices = new List<Price>();
            Goods = new List<Good>();

            ReadShops(shopsPath);
            ReadPrices(pricesPath);
            ReadGoods(goodsPath);
        }

        private void ReadShops(string shopsPath)
        {
            List<string> buffer = new List<string>();
            using (StreamReader sr = new StreamReader(shopsPath))
                while (!sr.EndOfStream)
                    buffer.Add(sr.ReadLine());

            foreach (string s in buffer)
                Shops.Add(new Shop(s.Split(';')[0], s.Split(';')[1], s.Split(';')[2]));
        }

        private void ReadPrices(string pricesPath)
        {
            List<string> buffer = new List<string>();
            using (StreamReader sr = new StreamReader(pricesPath))
                while (!sr.EndOfStream)
                    buffer.Add(sr.ReadLine());

            foreach (string s in buffer)
                Prices.Add(new Price(s.Split(';')[0], s.Split(';')[1], s.Split(';')[2], s.Split(';')[3]));
        }

        private void ReadGoods(string goodsPath)
        {
            List<string> buffer = new List<string>();
            using (StreamReader sr = new StreamReader(goodsPath))
                while (!sr.EndOfStream)
                    buffer.Add(sr.ReadLine());

            foreach (string s in buffer)
                Goods.Add(new Good(s.Split(';')[0], s.Split(';')[1], s.Split(';')[2]));
        }
    }
}
