using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;

namespace FluxRss
{
    [ServiceContract]
    [ServiceKnownType(typeof(Atom10FeedFormatter))]
    [ServiceKnownType(typeof(Rss20FeedFormatter))]
    public interface IFeed
    {

        [OperationContract]
        [WebGet(UriTemplate = "{user}/{blog}", BodyStyle = WebMessageBodyStyle.Bare)]
        SyndicationFeedFormatter CreateFeedForBlog(string user, string blog);

        // TODO: ajoutez vos opérations de service ici
    }
}
