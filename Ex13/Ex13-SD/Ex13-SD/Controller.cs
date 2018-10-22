using System;
using System.Collections.Generic;

namespace Ex13_SD
{
    public class Controller
    {
        private List<Book> BookList = new List<Book>();

        public void AddBook(Book book)
        {
            BookList.Add(book);
        }
        public Book GetBook(int id)
        {
            return BookList[id];
        }
        public bool ExistBook(string title)
        {
            return BookList.Exists(p => p.Title == title);
        }
    }
}