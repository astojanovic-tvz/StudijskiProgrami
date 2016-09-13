using HKOWebMVC4.Models;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HKOWebMVC4.SiteMapNodeProviders.StudentiProviders
{
    public class JMBAGDeterminedDynamicNodeProvider : DynamicNodeProviderBase
    {
        HKO_WEB dbContext = new HKO_WEB();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            foreach(UserProfileInfo user in dbContext.UserProfileInfo)
            {
                DynamicNode dynamicNode = new DynamicNode();
                dynamicNode.Title = user.Ime +" "+ user.Prezime;
                dynamicNode.ParentKey = "KandidatiPoslodavca";
                dynamicNode.RouteValues.Add("JMBAG", user.JMBAG);
                yield return dynamicNode;
            }
        }
    }
}