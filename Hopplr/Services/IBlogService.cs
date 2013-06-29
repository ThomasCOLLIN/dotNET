using System.Collections.Generic;
using System.ServiceModel;

namespace Services
{
    [ServiceContract]
    public interface IBlogService
    {
        [OperationContract]
        List<Article> GetArticlesFromBlog(string token, string blogName);

        [OperationContract]
        Article GetArticleFromBlog(string token, string blogName, long articleId);

        [OperationContract]
        bool AddArticle(string token, string blogname, Article article);

        [OperationContract]
        bool DeleteArticle(string token, string blogname, long articleId);
    }
}
