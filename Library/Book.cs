using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Book : IEquatable<Book>, IComparable, IComparable<Book>
    {
        private readonly int id;
        private string authorName;
        private string bookName;
        private string country;
        private int publishedYear;

        /// <summary>
        /// Author name
        /// </summary>
        public string AuthorName
        {
            get => authorName;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException($"{nameof(value)} is invalid!");
                authorName = value;
            }
        }

        /// <summary>
        /// Country, where book was writen
        /// </summary>
        public string Country
        {
            get => country;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException($"{nameof(value)} is invalid!");
                country = value;
            }
        }
        /// <summary>
        /// Dook title
        /// </summary>
        public string BookName
        {
            get => bookName;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException($"{nameof(value)} is invalid!");
                bookName = value;
            }
        }
        /// <summary>
        /// When book was first published
        /// </summary>
        public int PublishedYear
        {
            get => publishedYear;
            set
            {
                if (value > DateTime.Today.Year || value < -2400) throw new ArgumentException($"{nameof(value)} is invalid!");
                publishedYear = value;
            }
        }
        /// <summary>
        /// Useless ctor
        /// </summary>
        public Book()
        {
            Random rand = new Random();
            id = rand.Next(0, Int32.MaxValue);
        }

        /// <summary>
        ///Equivalence relation operator
        /// </summary>
        /// <param name="lhs">First argument</param>
        /// <param name="rhs">Second argument</param>
        /// <returns>True if objects are equal, and false otherwise</returns>
        public static bool operator ==(Book lhs, Book rhs)
        {
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null)) return false;
            return lhs.Equals(rhs);
        }
        public static bool operator !=(Book lhs, Book rhs) => !(lhs == rhs);
        /// <summary>
        ///Equivalence relation operator
        /// </summary>
        /// <param name="other">First argument</param>
        /// <returns>True if objects are equal, and false otherwise</returns>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null)) return false;
            return AuthorName == other.AuthorName && BookName == other.BookName && Country == other.Country && PublishedYear == other.PublishedYear;
        }

        public override bool Equals(object obj)
        {
            if ((ReferenceEquals(obj, null)) || typeof(Book) == obj.GetType()) return false;
            return Equals(obj as Book);
        }
        /// <summary>
        /// Compare two objects by the author name
        /// </summary>
        /// <param name="other">object to compare</param>
        /// <returns>1 if the first is higher, -1 if lower and 0 if equal</returns>
        public int CompareTo(Book other)
            => String.Compare(AuthorName, 0, other.AuthorName, 0, AuthorName.Length < other.AuthorName.Length ? AuthorName.Length : other.AuthorName.Length);

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null) || typeof(Book) == obj.GetType()) throw new ArgumentNullException($"{nameof(obj)} is invalid!");
            return this.CompareTo(obj as Book);
        }

        public override int GetHashCode() => this.id;

        /// <summary>
        /// Owerrided ToString method
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString() => PublishedYear > 0
            ? $"Book: \"{BookName}\", author: {AuthorName}, year of publishing: {PublishedYear} in {Country}"
            : $"Book: \"{BookName}\", author: {AuthorName}, year of publishing: {PublishedYear} BC in {Country}";

    }
}
