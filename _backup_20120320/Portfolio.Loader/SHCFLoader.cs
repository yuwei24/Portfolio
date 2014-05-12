using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portfolio.Business;
using System.IO;
using System.Net;

namespace Portfolio.Loader
{
    public class SHCFLoader: AbstractAssetLoader
    {        
        public SHCFLoader(Fund fund)
            : base(fund)
        {
        }

        public override void Load()
        {
            try
            {
                decimal price = 1;
                DateTime now = DateTime.Now.Date;
                DateTime asOfDate = DateTime.Now.Date;
                
                if (now.DayOfWeek == DayOfWeek.Monday)
                    asOfDate = now.AddDays(-3);
                else if (now.DayOfWeek == DayOfWeek.Sunday)
                    asOfDate = now.AddDays(-2);
                else
                    asOfDate = now.AddDays(-1);

                SavePrice(price, asOfDate);

                UpdateAsset(asOfDate);
            }
            catch (Exception) { }
        }
    }
}
