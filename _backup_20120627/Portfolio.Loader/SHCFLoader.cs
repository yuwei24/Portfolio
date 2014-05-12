using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portfolio.Business;
using System.IO;
using System.Net;

using Portfolio.Common;

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

                DateTime asOfDate = DateHelper.GetAsOfDate();
                
                SavePrice(price, asOfDate);

                UpdateAsset(asOfDate);
            }
            catch (Exception) { }
        }
    }
}
