using BusinessManagement;
using BusinessManagement.WebServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Services
{
    public class BlogService : IBlogService
    {
        public List<Article> GetArticlesFromBlog(string token, string blogOwnerLogin, string blogName)
        {
            List<Article> articles = new List<Article>();

            if (!TokenManager.IsTokenValid(token))
                return articles;

            Blog blog = new Blog(blogOwnerLogin, blogName);

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

        public Article GetArticleFromBlog(string token, string blogOwnerLogin, string blogName, long articleId)
        {
            if (!TokenManager.IsTokenValid(token))
                return null;

            Blog blog = new Blog(blogOwnerLogin, blogName);

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

        private string GetUrl(long mediaType, string media)
        {
            return mediaType == (long)BusinessManagement.Tools.MediaTypes.Video
                ? "http://www.youtube.com/v/" + media
                : media;
        }

        public List<Article> GetArticlesFromBlog(string token, string blogName)
        {
            throw new NotImplementedException();
        }

        public Article GetArticleFromBlog(string token, string blogName, long articleId)
        {
            throw new NotImplementedException();
        }

        public bool AddArticle(string token, string blogname, Article article)
        {
            return true;
        }

        public bool DeleteArticle(string token, string blogname, long articleId)
        {
            return false;
        }
    }
}
