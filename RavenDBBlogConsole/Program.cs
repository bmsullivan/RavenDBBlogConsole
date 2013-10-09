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
                var blog = new Blog()
                           {
                               Name = "My New Blog",
                               Author = "Brian"
                           };

                session.Store(blog);
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
}
