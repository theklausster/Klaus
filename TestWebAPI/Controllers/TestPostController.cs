using DAL.Entities;
using NUnit.Framework;
using RestService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace TestWebAPI.Controllers
{
    [TestFixture]
    class TestPostController
    {

        PostController controller;

        [SetUp]
        public void SetUp()
        {
            controller = new PostController();
        }

        [TearDown]
        public void TearDown()
        {
            controller = null;
        }

        [Test]
        public void Test_if_controller_can_GET_a_post()
        {
            int id = 1;
            var p = (OkNegotiatedContentResult<Post>)controller.GetPost(id);
            Assert.AreEqual(id, p.Content.Id);
        }

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
            Post post = new Post() { Title = "I'm a Post", Description = "This is me writing something to display", ImageUrl = "Just another Image url" };
            var createdPost = (OkNegotiatedContentResult<Post>)controller.PutPost(post);
            Assert.Greater(createdPost.Content.Id, 0); 
        }
    }
}
