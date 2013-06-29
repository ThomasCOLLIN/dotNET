using System.Collections.Generic;
using System.ServiceModel;

namespace Services
{
    [ServiceContract]
    public interface IBlogService
    {
        [OperationContract]
        List<Article> GetArticlesFromBlog(string blogOwner, string blogName);

        [OperationContract]
        Article GetArticleFromBlog(string blogOwner, string blogName, long articleId);

        [OperationContract]
        bool AddArticle(string login, string password, string blogname, Article article);

        [OperationContract]
        bool DeleteArticle(string login, string password, string blogname, long articleId);
    }
}
