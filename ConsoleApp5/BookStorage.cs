using System;

namespace BookTracker
{
    public class BookStorage
    {
        private Book[] books;
        private int count;

        public int Count => count;

        public BookStorage()
        {
            books = new Book[4];
            count = 0;
        }

        public Book this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException("Неверный индекс записи.");
                return books[index];
            }
            set
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException("Неверный индекс записи.");
                books[index] = value;
            }
        }

        public void Add(Book book)
        {
            if (count == books.Length)
            {
                Book[] newBooks = new Book[books.Length * 2];
                Array.Copy(books, newBooks, books.Length);
                books = newBooks;
            }
            books[count] = book;
            count++;
        }

        public static BookStorage operator +(BookStorage a, BookStorage b)
        {
            BookStorage result = new BookStorage();
            for (int i = 0; i < a.Count; i++)
                result.Add(a[i]);
            for (int i = 0; i < b.Count; i++)
                result.Add(b[i]);
            return result;
        }
    }
}