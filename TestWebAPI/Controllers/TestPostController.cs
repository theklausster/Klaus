using DAL.Context;
using DAL.Entities;
using DAL.Repository;
using NUnit.Framework;
using RestService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace TestWebAPI.Controllers
{
    [TestFixture]
    class TestPostController
    {

        RestService.Controllers.ApiController controller;

        [SetUp]
        public void SetUp()
        {
            controller = new RestService.Controllers.ApiController();
            ResetDB();
        }

        [TearDown]
        public void TearDown()
        {
            controller = null;
        }

        //[Test]
        //public void Test_if_controller_can_GET_a_post()
        //{
        //    PostContent post = new PostContent() { Title = "I'm a Post", Description = "This is me writing something to display", ImageUrl = "Just another Image url" };

        //    Assert.AreEqual(HttpStatusCode.Created, 
        //}

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_if_controller_can_GET_a_post_if_id_is_wrong()
        {
            int id = -1;
            controller.GetPost(id);
        }

        [Test]
        public void Test_if_controller_can_CREATE_a_post()
        {
            PostContent post = new PostContent() { Title = "I'm a Post", Description = "This is me writing something to display", ImageUrl = "Just another Image url" };
            HttpResponseMessage output = controller.Post(post);
            Assert.AreEqual(HttpStatusCode.Created, output.StatusCode);
        }

        [Test]
        public void Test_if_controlller_can_CREATE_a_post_when_modelstate_is_wrong()
        {
            //PostContent requires all attributes filled out due to data annotation
            //In this case post is missing the imageurl and it should return a badrequest
            PostContent post = new PostContent() { Title = "I'm a Post", Description = "This is me writing something to display" };
            HttpResponseMessage output = controller.Post(post);
            Assert.AreEqual(HttpStatusCode.BadRequest, output.StatusCode);
        }

        [Test]
        public void Test_if_controller_can_GETALL_posts()
        {
            IEnumerable<PostContent> list = controller.GetAll();
            Assert.True(list.ToList().Count() > 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_if_controller_can_DELETE_post()
        {
            int id = 1;
            controller.Delete(id);
            // This should trigger the argument exception
            controller.GetPost(id);
        }

        [Test]
        public void Test_if_controller_can_UPDATE_post()
        {
            PostRepository postRepo = new PostRepository();
            PostContent p = postRepo.ReadEntity(1);
            p.Description = "Fail";
            controller.PutPost(p);
            var updatedPost = (OkNegotiatedContentResult<PostContent>)controller.GetPost(1);
            Assert.AreEqual(p.Description, updatedPost.Content.Description);
        }


        private void ResetDB()
        {
            var context = new BackendContext();

            context.Database.Initialize(true);
        }
    }
}
