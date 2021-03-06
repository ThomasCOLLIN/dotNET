﻿using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;

namespace FluxRss
{
    public class Feed : IFeed
    {
        public SyndicationFeedFormatter CreateFeedForBlog(string user, string blog)
        {
            SyndicationFeed feed = new SyndicationFeed("Blog feed", "A feed linked to a blog", null);
            List<SyndicationItem> items = new List<SyndicationItem>();
            List<Dbo.RssArticle> articles = BusinessManagement.Feed.GetBlogContent(user, blog);

            foreach (Dbo.RssArticle article in articles)
            {
                SyndicationItem item = new SyndicationItem(article.Title, article.Content, null);
                item.PublishDate = article.CreationDate;
                items.Add(item);
            }
            feed.Items = items;

            // Renvoie ATOM ou RSS en fonction de la chaîne de requête
            // rss -> http://localhost:8733/Design_Time_Addresses/FluxRss/Feed1/
            // atom -> http://localhost:8733/Design_Time_Addresses/FluxRss/Feed1/?format=atom
            string query = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["format"];
            SyndicationFeedFormatter formatter = null;
            if (query == "atom")
            {
                formatter = new Atom10FeedFormatter(feed);
            }
            else
            {
                formatter = new Rss20FeedFormatter(feed);
            }

            return formatter;
        }
    }
}
