using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace HKOWebMVC4.DAL.HKOPodaciService
{
    public class HKOPodaciService
    {
        private static HKOPodaci HKOData = new HKOPodaci();

        public Dictionary<int, string> fetchDistinctZanimanjaDictionary()
        {
            ObjectResult<ZanimanjeStudiji_Result> zanimanjeStudijResult = HKOData.ZanimanjeStudiji();
            Dictionary<int, string> zanimanjaDict = zanimanjeStudijResult.Select(z => new { z.ZanimanjeID, z.Zanimanje }).Distinct().ToDictionary(z => z.ZanimanjeID, z => z.Zanimanje);
            return zanimanjaDict;
        }
    }   
}