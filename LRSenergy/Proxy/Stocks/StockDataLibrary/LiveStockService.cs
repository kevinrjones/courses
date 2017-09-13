using System;
using System.Collections.Generic;
using System.Text;
using StockDataLibrary.WebStockService;

namespace StockDataLibrary
{
    public abstract class StockServiceBase
    {
        public abstract double GetQuote(string symbol);
    }

    public class LiveStockService : StockServiceBase
    {
        public override double GetQuote(string symbol)
        {
            StockService client = new StockService();

            return client.GetQuote(symbol);
        }
    }

    public class CacheStockService : StockServiceBase
    {
        private readonly StockServiceBase _stockService;

        private readonly Dictionary<string, double> _cache = new Dictionary<string, double>();

        public CacheStockService(StockServiceBase stockService)
        {
            _stockService = stockService;
        }

        public override double GetQuote(string symbol)
        {
            if (!_cache.ContainsKey(symbol))
            {
                _cache[symbol] = _stockService.GetQuote(symbol);
            }
            return _cache[symbol];
        }
    }
}
