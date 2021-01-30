using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store1.Models.Repositories
{
    public class AuthorRepository : IBookStoreRepository<Author>

    {
        IList<Author> authorsList;
        public AuthorRepository()
        {
            authorsList = new List<Author>()
            {
                new Author{Id=1,FullName="tarek0"},
                new Author{Id=2,FullName="tarek0"},
                new Author{Id=3,FullName="tarek2"},
                new Author{Id=4,FullName="tarek3"}
            };
        }
        public void Add(Author entity)
        {
            entity.Id = authorsList.Max(b => b.Id) + 1;
            authorsList.Add (entity);
        }

        public void Delete(int id)
        {
            var author1 = Find(id);
            authorsList.Remove(author1);
        }

        public Author Find(int id)
        {
            var author = authorsList.SingleOrDefault(b => b.Id == id);
            return author;
        }

        public IList<Author> list()
        {
            return authorsList;
        }

        public void Update(int id, Author entity)
        {
            var author = Find(id);
            author.FullName = entity.FullName;
        }
        public List<Author> Search (string item)
        {
            return authorsList.Where(a => a.FullName.Contains(item)).ToList();  
        }
    }
}
