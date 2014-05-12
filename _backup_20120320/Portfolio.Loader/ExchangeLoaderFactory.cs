using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portfolio.Business;

namespace Portfolio.Loader
{
    public class ExchangeLoaderFactory
    {
        public static AbstractExchangeLoader CreateLoader()
        {
            return new DefaultExchangeLoader();
        }
    }
}
