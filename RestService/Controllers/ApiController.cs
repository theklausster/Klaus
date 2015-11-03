
using DAL.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace RestService.Controllers
{
    public class ApiController : System.Web.Http.ApiController
    {
        private PostRepository postRepo = new PostRepository();
     
       
        public IHttpActionResult GetPost(int id)
        {
            PostContent post = postRepo.ReadEntity(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }
        
        public HttpResponseMessage Post(PostContent post)
        {
            if (ModelState.IsValid)
            {
                PostContent p = postRepo.CreateEntity(post);
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
     
        public IEnumerable<PostContent> GetAll()
        {
            IEnumerable<PostContent> list = postRepo.ReadAllEntities();
            return list;
        }

        public void Delete(int id)
        {
            postRepo.DeleteEntity(id);
        }

        public void PutPost(PostContent p)
        {
            postRepo.UpdateEntity(p);
        }
    }
}
