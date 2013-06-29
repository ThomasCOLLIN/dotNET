using BusinessManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;

namespace Services
{
    public class BlogService : IBlogService
    {
        public List<Article> GetArticlesFromBlog(string blogOwner, string blogName)
        {
            List<Article> articles = new List<Article>();
            Blog blog = new Blog(blogOwner, blogName);
            BusinessManagement.Article art = new BusinessManagement.Article();

            if (!blog.Exists)
                return articles;

            blog.GetArticles().ForEach(item =>
            {
                Dbo.Article dboArt = BusinessManagement.Article.GetArticleDbo(item.Id);
                articles.Add(ConvertToWebArticle(dboArt));
            });

            return articles;
        }

        public Article GetArticleFromBlog(string blogOwner, string blogName, long articleId)
        {
            Blog blog = new Blog(blogOwner, blogName);

            if (!blog.Exists)
                return null;

            List<DataAccess.T_Article> articles = blog.GetArticles();

            foreach (DataAccess.T_Article art in articles)
            {
                if (art.Id != articleId || blog.Id != art.BlogId)
                    continue;
                return ConvertToWebArticle(BusinessManagement.Article.GetArticleDbo(art.Id));
            };

            return null;
        }

        public bool AddArticle(string login, string password, string blogname, Article article)
        {
            BusinessManagement.User user = new User(login);
            if (!user.Exists || !user.IsPasswordValid(password))
                return false;

            BusinessManagement.Blog blog = new Blog(login, blogname);

            if (!blog.Exists)
                return false;

            BusinessManagement.Article.Create(blog.Id, article.MediaUrl, (long) ConvertToMediaType(article.MediaType), article.Text, TagsAsString(article.Tags));

            return true;
        }

        public bool DeleteArticle(string login, string password, string blogname, long articleId)
        {
            BusinessManagement.User user = new User(login);
            if (!user.Exists || !user.IsPasswordValid(password))
                return false;

            Blog blog = new Blog(login, blogname);
            BusinessManagement.Article art = new BusinessManagement.Article();
            DataAccess.T_Article article = BusinessManagement.Article.Get(articleId);
            if (!blog.Exists || article == null || article.BlogId != blog.Id)
                return false;

            art.Delete(articleId);

            return true;
        }

        private Article ConvertToWebArticle(Dbo.Article article)
        {
            Article result = new Article();

            result.CreationDate = article.CreationDate;
            result.Id = article.Id;
            result.Text = article.Caption;
            result.MediaUrl = article.MediaUrl;
            
            result.Tags = new List<string>();
            article.Tags.ForEach(tag => result.Tags.Add(tag.Name));

            switch ((long) article.MediaTypeId)
	        {
                case ((long) Tools.MediaTypes.Image):
                    result.MediaType = MediaTypeWebService.IMAGE;
                    break;
                case ((long) Tools.MediaTypes.Video):
                    result.MediaType = MediaTypeWebService.VIDEO;
                    break;
                case ((long) Tools.MediaTypes.Music):
                    result.MediaType = MediaTypeWebService.MUSIC;
                    break;
		        default:
                    result.MediaType = MediaTypeWebService.QUOTE;
                    break;
	        }

            return result;
        }

        private Tools.MediaTypes ConvertToMediaType(MediaTypeWebService type)
        {
            switch (type)
            {
                case (MediaTypeWebService.IMAGE):
                    return Tools.MediaTypes.Image;
                case (MediaTypeWebService.MUSIC):
                    return Tools.MediaTypes.Music;
                case (MediaTypeWebService.VIDEO):
                    return Tools.MediaTypes.Video;
                default:
                    return Tools.MediaTypes.Quote;
            }
        }

        private string TagsAsString(List<string> tags)
        {
            StringBuilder sb = new StringBuilder();
            tags.ForEach(tag =>
            {
                if (tag.Trim() != "")
                    sb.Append(tag.Trim() + " ");
            });
            return sb.ToString().TrimEnd();
        }
    }
}
