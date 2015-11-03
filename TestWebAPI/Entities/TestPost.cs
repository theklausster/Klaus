using DAL.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestWebAPI.Entities
{
    [TestFixture]
    class TestPost
    {
        PostContent post;
        [SetUp]
        public void SetUp()
        {
            post = new PostContent();
        } 

        [TearDown]
        public void TearDown()
        {
            post = null;
        }


        [Test]
        public void Test_if_post_id_can_be_set()
        {
            post.Id = 1;
            Assert.AreEqual(1, post.Id);
        }

        [Test]
        public void Test_if_post_imageLink_can_be_set()
        {
            string image = "http://metaldetectorsa.co.za/wp-content/uploads/2012/04/01_ace_350_935x340.jpg";
            post.ImageUrl = image;
            Assert.AreEqual(image, post.ImageUrl);
        }

        [Test]
        public void Test_if_post_description_can_be_set()
        {
            string description = "This is one grate machine";
            post.Description = description;
            Assert.AreEqual(description, post.Description);
        }

        [Test]
        public void Test_if_post_title_can_be_set()
        {
            string title = "Garret EuroAce";
            post.Title = title;
            Assert.AreEqual(title, post.Title);
        }

    }
}
