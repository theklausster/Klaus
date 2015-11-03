using System;
using System.Collections.Generic;
using DAL.Entities;
using DAL.Repositories;
using DAL.Context;
using System.Linq;

namespace DAL.Repository
{
    public class PostRepository : IRepository<PostContent>
    {



        public PostContent CreateEntity(PostContent t)
        {
            using (var db = new BackendContext())
            { 
                PostContent createdPost = db.Posts.Add(t);
                db.SaveChanges();
                return createdPost;
            }
        }

        public void DeleteEntity(int id)
        {
            using (var db = new BackendContext())
            {
                PostContent p = db.Posts.FirstOrDefault(a => a.Id == id);
                if (p != null)
                {
                    db.Posts.Remove(p);
                    db.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Post Delete Method ID is wrong!");
                }

            }
           
        }

        public List<PostContent> ReadAllEntities()
        {
            using (var db = new BackendContext())
            {
                return db.Posts.ToList();
            }
        }

        public PostContent ReadEntity(int id)
        {
            using (var db = new BackendContext())
            {
                PostContent post = db.Posts.FirstOrDefault(a => a.Id == id);
                if (post != null)
                {
                    return post;
                }
                else
                {
                    throw new ArgumentException("Post ReadEntity Method ID is wrong!");
                }
            }
        }

        public void UpdateEntity(PostContent t)
        {
            using (var db = new BackendContext())
            {
                PostContent p = db.Posts.FirstOrDefault(a => a.Id == t.Id);
                p.ImageUrl = t.ImageUrl;
                p.Title = t.Title;
                p.Description = t.Description;
                db.SaveChanges();
                
            }
        }
    }
}