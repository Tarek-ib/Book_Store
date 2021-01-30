using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store1.Models.Repositories
{
    public class AuthorDbRepository: IBookStoreRepository<Author>

    {
        BookStore1DbContext db;
        public AuthorDbRepository(BookStore1DbContext _db)
        {
            db = _db;
        }
        public void Add(Author entity)
        {
            //entity.Id = db.AuthorDbSet.Max(b => b.Id) + 1;
            db.AuthorDbSet.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var author1 = Find(id);
            db.AuthorDbSet.Remove(author1);
            db.SaveChanges();
        }

        public Author Find(int id)
        {
            var author = db.AuthorDbSet.SingleOrDefault(b => b.Id == id);
            db.SaveChanges();
            return author;
           
        }

        public IList<Author> list()
        {
            return db.AuthorDbSet.ToList();
        }

        public List<Author> Search(string item)
        {
            return db.AuthorDbSet.Where(a => a.FullName.Contains(item)).ToList();
        }

        public void Update(int id, Author entity)
        {
            db.Update(entity);
            db.SaveChanges();
        }
    }
    
    }

