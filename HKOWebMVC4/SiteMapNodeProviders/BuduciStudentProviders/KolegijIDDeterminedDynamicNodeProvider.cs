using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using HKOWebMVC4.ExtensionMethods;

//http://stackoverflow.com/questions/33159532/can-mvc-sitemapprovider-dynamicnode-be-used-on-1st-level-solved

namespace HKOWebMVC4.SiteMapNodeProviders.BuduciStudentProviders
{
    public class KolegijIDDeterminedDynamicNodeProvider : DynamicNodeProviderBase
    {
        HKOPodaci HKOData = new HKOPodaci();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            Dictionary<int, string> uniqueKolegij = new Dictionary<int, string>();
            List<ZanimanjeStudiji_Result> zanimanjeStudijResult = HKOData.ZanimanjeStudiji().ToList();
            foreach (var entry in zanimanjeStudijResult)
            {
                ObjectResult<StudijskiProgramObavezniKolegiji_Result> obavezniKolegiji = HKOData.StudijskiProgramObavezniKolegiji(entry.StudijskiProgramID);
                ObjectResult<StudijskiProgramIzborniKolegiji_Result> izborniKolegiji = HKOData.StudijskiProgramIzborniKolegiji(entry.StudijskiProgramID);
                ObjectResult<ZanimanjePreporuceniIzborniKolegiji_Result> preporuceniKolegiji = HKOData.ZanimanjePreporuceniIzborniKolegiji(entry.ZanimanjeID);
                Dictionary<int, string> obavezniKolegijiDict = obavezniKolegiji.Select(ok => new { ok.KolegijID, ok.Kolegij }).Distinct().ToDictionary(ok => ok.KolegijID, ok => ok.Kolegij);
                Dictionary<int, string> izborniKolegijiDict = izborniKolegiji.Select(ik => new { ik.KolegijID, ik.Kolegij }).Distinct().ToDictionary(ik => ik.KolegijID, ik => ik.Kolegij);
                Dictionary<int, string> preporuceniKolegijiDict = preporuceniKolegiji.Select(pk => new { pk.KolegijID, pk.Kolegij }).Distinct().ToDictionary(pk => pk.KolegijID, pk => pk.Kolegij);

                uniqueKolegij.AddRange(obavezniKolegijiDict);
                uniqueKolegij.AddRange(izborniKolegijiDict);
                uniqueKolegij.AddRange(preporuceniKolegijiDict);
            }

            foreach(var entry in zanimanjeStudijResult)
            {
                foreach(var dictEntry in uniqueKolegij)
                {
                    DynamicNode dynamicNode = new DynamicNode();
                    dynamicNode.Title = dictEntry.Value;
                    dynamicNode.Key = "BSIshodiUcenja" + dictEntry.Key +" "+ entry.StudijskiProgramID + " " + entry.ZanimanjeID; ;
                    dynamicNode.ParentKey = "BSKolegiji" + entry.StudijskiProgramID + " " + entry.ZanimanjeID;
                    dynamicNode.RouteValues.Add("kolegijId", dictEntry.Key);
                    yield return dynamicNode;
                }
            }
        }
    }
}