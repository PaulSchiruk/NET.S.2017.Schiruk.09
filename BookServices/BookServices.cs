using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using BookStorageInterfaces;

namespace Logic
{
        public class BookListService
        {
            /// <summary>
            /// The book list.
            /// </summary>
            private List<Book> bookList;

            /// <summary>
            /// Initializes a new instance of the BookListService class.
            /// </summary>
            public BookListService()
            {
                bookList = new List<Book>();
            }

        /// <summary>
        /// Initializes a new instance of the BookListService class.
        /// </summary>
        /// <param name="bookList">Book list.</param>
        public BookListService(IEnumerable<Book> bookList) : this()
            {
                if (bookList == null) throw new ArgumentNullException($"{nameof(bookList)} is invalid!");
                foreach (var book in bookList)
                    AddBook(book);
            }

            /// <summary>
            /// Adds the book.
            /// </summary>
            /// <param name="book">Book.</param>
            public void AddBook(Book book)
            {
                if (book == null) throw new ArgumentNullException($"{nameof(book)} is invalid!");
                if (bookList.Contains(book)) throw new ArgumentException($"{nameof(book)} is already exist!");
                bookList.Add(book);
            }

            /// <summary>
            /// Removes the book.
            /// </summary>
            /// <param name="book">Book.</param>
            public void RemoveBook(Book book)
            {
                if (!bookList.Contains(book)) throw new ArgumentException($"{nameof(book)} does not exist!");
                bookList.Remove(book);
            }
        /// <summary>
        /// Find book by tag
        /// </summary>
        /// <param name="tag">Search criteria</param>
        /// <returns></returns>
        public Book FindBookByTag(Predicate<Book> tag)
            {
                if (ReferenceEquals(tag, null)) throw new ArgumentNullException($"{nameof(tag)} is null");
                return bookList.Find(tag);
            }

            /// <summary>
            /// Sorts the books by tag.
            /// </summary>
            /// <param name="comparer">Comparer.</param>
            public void SortBooksByTag(IComparer<Book> comparer)
            {
                if (ReferenceEquals(comparer, null)) throw new ArgumentNullException($"{nameof(comparer)} is null");
                bookList.Sort(comparer);
            }

            /// <summary>
            /// Saves to storage.
            /// </summary>
            /// <param name="storage">Storage.</param>
            public void SaveToStorage(IBookStorage storage)
            {
                if (storage == null) throw new ArgumentNullException($"{nameof(storage)} is invalid!");
                storage.WriteToStorage(bookList);
            }

            /// <summary>
            /// Loads from storage.
            /// </summary>
            /// <param name="storage">Storage.</param>
            public void ReadFromStorage(IBookStorage storage)
            {

                if (ReferenceEquals(storage, null)) throw new ArgumentNullException($"{nameof(storage)} is null");
                bookList = storage.ReadFromStorage();
            }
        
    }
}
