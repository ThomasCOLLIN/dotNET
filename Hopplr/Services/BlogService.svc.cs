using BusinessManagement;
using System;
using System.Collections.Generic;
using System.Web;

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
                Dbo.Article dboArt = art.GetArticleDbo(item.Id);
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
                return ConvertToWebArticle(new BusinessManagement.Article().GetArticleDbo(art.Id));
            };

            return null;
        }

        public bool AddArticle(string blogname, Article article)
        {
            string username = HttpContext.Current.User.Identity.Name;
            BusinessManagement.Blog blog = new Blog(username, blogname);

            if (!blog.Exists)
                return false;

            throw new Exception("Not Implemented yet");

            return true;
        }

        public bool DeleteArticle(string blogname, long articleId)
        {
            string username = HttpContext.Current.User.Identity.Name;
            Blog blog = new Blog(username, blogname);
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
                    result.MediaType = Article.MediaTypeEnum.IMAGE;
                    break;
                case ((long) Tools.MediaTypes.Video):
                    result.MediaType = Article.MediaTypeEnum.YOUTUBE_ID;
                    break;
                case ((long) Tools.MediaTypes.Music):
                    result.MediaType = Article.MediaTypeEnum.MP3;
                    break;
		        default:
                    result.MediaType = Article.MediaTypeEnum.TEXTE;
                    break;
	        }

            return result;
        }
    }
}
