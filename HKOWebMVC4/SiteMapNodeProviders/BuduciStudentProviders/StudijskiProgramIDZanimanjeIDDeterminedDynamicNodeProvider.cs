using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace HKOWebMVC4.SiteMapNodeProviders.BuduciStudentProviders
{
    public class StudijskiProgramIDZanimanjeIDDeterminedDynamicNodeProvider : DynamicNodeProviderBase
    {
        HKOPodaci HKOData = new HKOPodaci();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            ObjectResult<ZanimanjeStudiji_Result> zanimanjeStudijResult = HKOData.ZanimanjeStudiji();
            foreach (var entry in zanimanjeStudijResult)
            {
                DynamicNode dynamicNode = new DynamicNode();
                dynamicNode.Title = entry.Studijski_program +" i "+entry.Zanimanje ;
                dynamicNode.Key = "BSKolegiji" + entry.StudijskiProgramID + " " + entry.ZanimanjeID;
                dynamicNode.ParentKey = "BuduciStudent";
                dynamicNode.RouteValues.Add("studijskiProgramId", entry.StudijskiProgramID);
                dynamicNode.RouteValues.Add("zanimanjeId", entry.ZanimanjeID);
                yield return dynamicNode;
            }
        }
    }
}