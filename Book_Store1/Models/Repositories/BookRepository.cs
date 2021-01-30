using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store1.Models.Repositories
{
    public class BookRepository : IBookStoreRepository<Book>
    {
        List<Book> books;
        public BookRepository()
        {
            books = new List<Book>()
            {
                new Book
                {
                    Id=1,Title="C# pro0",Describtion="No Describtion0",My_ImageUrl="1.jpg",Author=new Author()
                },
                 new Book
                {
                    Id=2,Title="C# pro1",Describtion="No Describtion1",My_ImageUrl="2.jpg",Author=new Author()
                },
                  new Book
                {
                    Id=3,Title="C# pro2",Describtion="No Describtion2",My_ImageUrl="2.jpg",Author=new Author()
                },
                   
                
            };
        }
        public void Add(Book entity)
        {
            entity.Id = books.Max(b => b.Id)+1;
            books.Add(entity);
        }

        public void Delete( int id) 
        {
            var book = Find(id);
            books.Remove(book);
        }

       
        public Book Find(int id)
        {
            var book = books.SingleOrDefault(b => b.Id == id);
            return book;
        }

        public IList<Book> list()
        {
            return books;
        }

        public List<Book> Search(string item)
        {
            return books.Where(a => a.Title.Contains(item)).ToList();
        }

        public void Update(int id, Book entity)
        {
            var book1 = Find(id);
            book1.Title = entity.Title;
            book1.Describtion = entity.Describtion;
            book1.Author = entity.Author;
            book1.My_ImageUrl = entity.My_ImageUrl;
        }
    }
}
