using System.Collections.Generic;

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
                rssArticle.Title = "";
                rssArticle.Content = GetMediaAsHtml((long) article.MediaTypeId, article.MediaUrl)
                    + "<br>" + article.Text;
                rssArticle.CreationDate = article.CreationDate;

                rssArticles.Add(rssArticle);
            }

            return rssArticles;
        }

        private static string GetMediaAsHtml(long mediaType, string media)
        {
            switch (mediaType)
            {
                case ((long)Tools.MediaTypes.Image):
                    return GetImageAsHtml(media);
                case ((long)Tools.MediaTypes.Music):
                    return GetSoundAsHtml(media);
                case ((long)Tools.MediaTypes.Quote):
                    return GetQuoteAsHtml(media);
                case ((long)Tools.MediaTypes.Video):
                    return GetVideoAsHtml(media);
                default:
                    return "";
            }
        }

        private static string GetImageAsHtml(string image)
        {
            return "<img src=\"" + image + "\" alt=\"image\">";
        }

        private static string GetSoundAsHtml(string sound)
        {
            return "<video controls>"
                + "<source src=\"" + sound + "\" type=\"audio/mpeg\">"
                + "</video>";
        }

        private static string GetQuoteAsHtml(string quote)
        {
            return quote;
        }

        private static string GetVideoAsHtml(string videoId)
        {
            return "<iframe width=\"640\" height=\"385\" src=\"http://www.youtube.com/v/" + videoId + "\" frameborder=\"0\" allowfullscreen=\"true\"></iframe>";
        }
    }
}
