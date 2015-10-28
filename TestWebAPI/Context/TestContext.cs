using DAL.Context;
using DAL.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestWebAPI.Context
{
    [TestFixture]
    class TestContext
    {
        BackendContext db;
       [SetUp]
        public void SetUp()
        {
             db = new BackendContext();
        }

        [TearDown]
        public void TearDown()
        {
            db = null;
        }
        [Test]
        public void Test_database_connection_in_db_context()
        {
            
            List<Post> list = db.Posts.ToList();
            Assert.IsNotNull(list);
        }

        [Test]
        public void Test_amount_of_items_in_db()
        {
            Assert.Greater(db.Posts.Count(), 4);
        }
        
    }
}
