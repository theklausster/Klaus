using System.Data.Entity;
using DAL.Context;
using DAL.Entities;
using System.Collections.Generic;

namespace DAL.Initializer
{
    public class DBInitializer : DropCreateDatabaseAlways<BackendContext>
    {
        Post postOne = new Post() { Id = 1, Description = "This is awesome!", ImageUrl = "An ImageUrl", Title = "Post One" };
        Post postTwo = new Post() { Id = 2, Description = "This is awesome!", ImageUrl = "An ImageUrl", Title = "Post Two" };
        Post postThree = new Post() { Id = 3, Description = "This is awesome!", ImageUrl = "An ImageUrl", Title = "Post Three" };
        Post postFour = new Post() { Id = 4, Description = "This is awesome!", ImageUrl = "An ImageUrl", Title = "Post Four" };
        Post postFive = new Post() { Id = 5, Description = "This is awesome!", ImageUrl = "An ImageUrl", Title = "Post Five" };

        protected override void Seed(BackendContext context)
        {
            List<Post> list = new List<Post> { postOne, postTwo, postThree, postFour, postFive };
            list.ForEach(x => context.Posts.Add(x));
            base.Seed(context);
        }


    }
}