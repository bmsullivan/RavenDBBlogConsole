using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Document;

namespace RavenDBBlogConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var docStore = new DocumentStore()
            {
                Url = "http://localhost:8080"
            };

            docStore.Initialize();

            using (var session = docStore.OpenSession())
            {
                var post = session.Load<Post>("posts/1").Title = "New Title";
                session.SaveChanges();
            }
        }
    }


    public class Blog
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }

    public class Post
    {
        public string Id { get; set; }
        public string BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Comment> Comments { get; set; }
        public List<string> Tags { get; set; }
    }

    public class Comment
    {
        public string CommenterName { get; set; }
        public string Text { get; set; }
    }
}
