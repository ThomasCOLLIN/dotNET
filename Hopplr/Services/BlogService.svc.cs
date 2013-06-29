using BusinessManagement;
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

            if (!blog.Exists)
                return articles;

            blog.GetArticles().ForEach(art =>
            {
                Article article = new Article();
                article.CreationDate = art.CreationDate;
                article.Id = art.Id;
                article.Text = art.Text;
                article.MediaUrl = GetUrl((long)art.MediaTypeId, art.MediaUrl);

                articles.Add(article);
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
                if (art.Id != articleId)
                    continue;

                Article article = new Article();
                article.CreationDate = art.CreationDate;
                article.Id = art.Id;
                article.Text = art.Text;
                article.MediaUrl = GetUrl((long)art.MediaTypeId, art.MediaUrl);

                return article;
            };

            return null;
        }

        public bool AddArticle(string blogname, Article article)
        {
            string username = HttpContext.Current.User.Identity.Name;
            BusinessManagement.Blog blog = new Blog(username, blogname);

            if (!blog.Exists)
                return false;

            return true;
        }

        public bool DeleteArticle(string blogname, long articleId)
        {
            string username = HttpContext.Current.User.Identity.Name;
            Blog blog = new Blog(username, blogname);
            BusinessManagement.Article art = new BusinessManagement.Article();
            DataAccess.T_Article article = art.Get(articleId);
            if (!blog.Exists || article == null || article.BlogId != blog.Id)
                return false;

            art.Delete(articleId);

            return true;
        }

        private string GetUrl(long mediaType, string media)
        {
            return mediaType == (long)BusinessManagement.Tools.MediaTypes.Video
                ? "http://www.youtube.com/v/" + media
                : media;
        }
    }
}
