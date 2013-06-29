﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ArticleCRUD
    {

        public static void Create(T_Article article)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    bdd.T_Article.Add(article);
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static T_Article Get(long articleId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_Article.Where(art => art.Id == articleId).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static Dbo.Article GetArticleDbo(long articleId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                     T_Article article = bdd.T_Article.Include("T_Comment").Include("T_ArticleTag.T_Tag").Where(a => a.Id == articleId).FirstOrDefault();
                     Dbo.Article dboArticle = new Dbo.Article(){
                        Id = article.Id,
                        BlogId = article.BlogId,
                        MediaUrl = article.MediaUrl,
                        MediaTypeId = article.MediaTypeId,
                        Caption = article.Text,
                        CreationDate = article.CreationDate,
                        Comments = new List<Dbo.Comment>(),
                        Tags = new List<Dbo.Tag>()
                    };
                    
                    foreach (T_Comment comment in article.T_Comment)
                    {
                        dboArticle.Comments.Add(new Dbo.Comment()
                        {
                            Id = comment.Id,
                            UserId = comment.UserId,
                            ArticleId = comment.ArticleId,
                            Content = comment.Comment,
                            CreationDate = comment.CreationDate
                        });
                    }

                    foreach (T_ArticleTag aTag in article.T_ArticleTag)
                    {
                        Dbo.Tag tag = new Dbo.Tag();
                        tag.Id = aTag.T_Tag.Id;
                        tag.Name = aTag.T_Tag.Name;

                        dboArticle.Tags.Add(tag);
                    }

                    return dboArticle;
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static List<T_Article> GetWithBlog(long blogId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_Article.Where(art => art.BlogId == blogId).ToList();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Update(long articleId, T_Article newT_Article)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    T_Article article = Get(articleId);
                    article = newT_Article;
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Delete(long articleId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    bdd.T_Article.Remove(Get(articleId));
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static List<T_Article> GetAll()
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_Article.ToList();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }
    }
}
