using DAL.Context;
using DAL.Entities;
using DAL.Repositories;
using DAL.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebAPI.Repositories
{
    [TestFixture]
    class TestPostRepository
    {
        IRepository<Post> postRepo;

        [SetUp]
        public void SetUp()
        {
            ResetDB();
            postRepo = new PostRepository();

        }

        [TearDown]
        public void TearDown()
        {
            postRepo = null;
        }

        [Test]
        public void Test_if_read_by_id_works()
        {
            Post post = postRepo.ReadEntity(1);
            Assert.NotNull(post);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_if_read_by_id_is_null()
        {
            Post post = postRepo.ReadEntity(-1);
        }

        [Test]
        public void Test_if_get_all_posts_works()
        {
            List<Post> posts = postRepo.ReadAllEntities();
            Assert.NotNull(posts);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_if_delete_post_works()
        {
            int id = 1;
            postRepo.DeleteEntity(id);
            Post deletedPost = postRepo.ReadEntity(id);
            Assert.Null(deletedPost);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_if_delete_post_id_is_wrong()
        {
            int id = -1;
            postRepo.DeleteEntity(id);
        }

        [Test]
        public void Test_if_create_post_works()
        {
            Post p = new Post() { Description = "Hello World", ImageUrl = "imgurl", Title = "Im a Test post" };
            Post createdPost = postRepo.CreateEntity(p);
            Assert.Greater(createdPost.Id, 0);

        }

        [Test]
        public void Test_if_update_post_works()
        {
            Post p = postRepo.ReadEntity(1);
            string title = "loool";
            p.Title = title;
            postRepo.UpdateEntity(p);
            Assert.AreEqual(title, postRepo.ReadEntity(1).Title);

        }


        private void ResetDB()
        {
            var context = new BackendContext();

            context.Database.Initialize(true);
        }
    }
}
