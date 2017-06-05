using System;
using System.Collections.Generic;
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

            var cheap = _reader.Goods.Join(_reader.Prices, x => x.GoodCode, y => y.GoodCode, (x, y) =>
            new { Name = x.GoodName, PriceWithDiscount = y.GoodPrice * ((y.Discount / 100.0)), ShopCode = y.ShopCode }).Join(_reader.Shops,
            x => x.ShopCode, y => y.ShopCode, (x, y) => new
            {
                ProductName = x.Name,
                PriceWithDiscount = x.PriceWithDiscount,
                ShopName = y.Name,
                ShopAddress = y.Address
            });
        }
    }
}
