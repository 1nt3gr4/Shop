using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsDataProcessing
{
    public interface IProcess
    {
        void Process();
    }

    class Processing : IProcess
    {
        private IReader _reader;

        public void Process()
        {
            _reader = new Reader();
            _reader.Read("shops.txt", "prices.txt", "goods.txt");

            var result = _reader.Goods.Join(_reader.Prices, x => x.GoodCode, y => y.GoodCode, (x, y) =>
            new { Name = x.GoodName, PriceWithDiscount = y.GoodPrice * ((y.Discount / 100.0)), ShopCode = y.ShopCode }).Join(_reader.Shops,
            x => x.ShopCode, y => y.ShopCode, (x, y) => new
            {
                ProductName = x.Name,
                PriceWithDiscount = x.PriceWithDiscount,
                ShopName = y.Name,
                ShopAddress = y.Address
            }).GroupBy(x => x.ProductName).Select(x => new
            {
                ProductName = x.First().ProductName,
                ProductPrice = x.Min(y => y.PriceWithDiscount),
                ShopName = x.First().ShopName,
                ShopAddress = x.First().ShopAddress
            }).OrderBy(x => x.ProductPrice).ThenBy(x => x.ProductName);

            var cheap = result.Where(x => x.ProductPrice < 1000);
            var medium = result.Where(x => x.ProductPrice >= 1000 && x.ProductPrice < 10000);
            var expensive = result.Where(x => x.ProductPrice >= 10000);

            using (StreamWriter sw = new StreamWriter("cheap.txt"))
                foreach (var i in cheap)
                    sw.WriteLine($"{i.ProductName} {i.ProductPrice} {i.ShopAddress} {i.ShopName}");
            using (StreamWriter sw = new StreamWriter("medium.txt"))
                foreach (var i in medium)
                    sw.WriteLine($"{i.ProductName} {i.ProductPrice} {i.ShopAddress} {i.ShopName}");
            using (StreamWriter sw = new StreamWriter("expensive.txt"))
                foreach (var i in expensive)
                    sw.WriteLine($"{i.ProductName} {i.ProductPrice} {i.ShopAddress} {i.ShopName}");
        }
    }
}
