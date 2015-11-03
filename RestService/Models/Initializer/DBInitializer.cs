using System.Data.Entity;
using DAL.Context;
using DAL.Entities;
using System.Collections.Generic;

namespace DAL.Initializer
{
    public class DBInitializer : DropCreateDatabaseAlways<BackendContext>
    {
        PostContent postOne = new PostContent() { Id = 1, Description = "This is awesome!", ImageUrl = "An ImageUrl", Title = "Post One" };
        PostContent postTwo = new PostContent() { Id = 2, Description = "This is awesome!", ImageUrl = "An ImageUrl", Title = "Post Two" };
        PostContent postThree = new PostContent() { Id = 3, Description = "This is awesome!", ImageUrl = "An ImageUrl", Title = "Post Three" };
        PostContent postFour = new PostContent() { Id = 4, Description = "This is awesome!", ImageUrl = "An ImageUrl", Title = "Post Four" };
        PostContent postFive = new PostContent() { Id = 5, Description = "This is awesome!", ImageUrl = "An ImageUrl", Title = "Post Five" };

        protected override void Seed(BackendContext context)
        {
            List<PostContent> list = new List<PostContent> { postOne, postTwo, postThree, postFour, postFive };
            list.ForEach(x => context.Posts.Add(x));
            base.Seed(context);
        }


    }
}