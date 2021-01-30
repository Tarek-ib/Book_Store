using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Book_Store1.Models;

namespace Book_Store1
{
    public class BookStore1DbContext:DbContext
    {
        public BookStore1DbContext(DbContextOptions<BookStore1DbContext> options): base(options)
        {
                
        }
        public DbSet<Author> AuthorDbSet { get; set; }
        public DbSet<Book> BookDbSet { get; set; }
    }
}
