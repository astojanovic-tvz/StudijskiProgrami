using HKOWebMVC4.DAL.HKOPodaciService;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HKOWebMVC4.SiteMapNodeProviders.BuduciStudentProviders
{
    /// <summary>
    /// Class that returns site map according to ZanimanjeId.
    /// It is used in multiple places.
    /// </summary>
    public class ZanimanjeIDDeterminedDynamicNodeProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            HKOPodaciService HKOPodaciServis = new HKOPodaciService();
            Dictionary<int, string> mapaZanimanja = HKOPodaciServis.fetchDistinctZanimanjaDictionary();
            foreach(var entry in mapaZanimanja)
            {
                DynamicNode dynamicNode = new DynamicNode();
                dynamicNode.Title = entry.Value;
                dynamicNode.ParentKey = "BuduciStudent";
                dynamicNode.RouteValues.Add("zanimanjeId", entry.Key);
                yield return dynamicNode;
           }
        }
    }
}