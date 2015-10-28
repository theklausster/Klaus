using System;
using System.Collections.Generic;
using DAL.Entities;
using DAL.Repositories;
using DAL.Context;
using System.Linq;

namespace DAL.Repository
{
    public class PostRepository : IRepository<Post>
    {



        public Post CreateEntity(Post t)
        {
            using (var db = new BackendContext())
            { 
                Post createdPost = db.Posts.Add(t);
                db.SaveChanges();
                return createdPost;
            }
        }

        public void DeleteEntity(int id)
        {
            using (var db = new BackendContext())
            {
                Post p = db.Posts.FirstOrDefault(a => a.Id == id);
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

        public List<Post> ReadAllEntities()
        {
            using (var db = new BackendContext())
            {
                return db.Posts.ToList();
            }
        }

        public Post ReadEntity(int id)
        {
            using (var db = new BackendContext())
            {
                Post post = db.Posts.FirstOrDefault(a => a.Id == id);
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

        public void UpdateEntity(Post t)
        {
            using (var db = new BackendContext())
            {
                Post p = db.Posts.FirstOrDefault(a => a.Id == t.Id);
                p.ImageUrl = t.ImageUrl;
                p.Title = t.Title;
                p.Description = t.Description;
                db.SaveChanges();
                
            }
        }
    }
}