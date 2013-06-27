using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement
{
    public class Feed
    {
        public static List<Dbo.RssArticle> GetBlogContent(string user, string blog)
        {
            List<Dbo.RssArticle> rssArticles = new List<Dbo.RssArticle>();
            List<DataAccess.T_Article> articles = DataAccess.Feed.GetBlogContent(user, blog);

            foreach (DataAccess.T_Article article in articles)
            {
                Dbo.RssArticle rssArticle = new Dbo.RssArticle();
                rssArticle.Title = article.Text;
                rssArticle.Content = "<img src=\"http://imgs.xkcd.com/comics/password_strength.png\">" + article.MediaUrl;
                rssArticle.CreationDate = article.CreationDate;

                rssArticles.Add(rssArticle);
            }

            return rssArticles;
        }
    }
}
