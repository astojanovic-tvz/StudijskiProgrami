using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace HKOWebMVC4.SiteMapNodeProviders.ZavrseniStudentProviders
{
    public class StudijskiProgramIDDeterminedDynamicNodeProvider : DynamicNodeProviderBase
    {
        HKOPodaci HKOData = new HKOPodaci();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            ObjectResult<StudijskiProgrami_Result> zanimanjeStudijResult = HKOData.StudijskiProgrami();
            foreach (var entry in zanimanjeStudijResult)
            {
                DynamicNode dynamicNode = new DynamicNode();
                dynamicNode.Title = entry.StudijskiProgram;
                dynamicNode.ParentKey = "ZavrseniStudent";
                dynamicNode.RouteValues.Add("studijskiProgramId", entry.StudijskiProgramID);
                yield return dynamicNode;
            }
        }
    }
}