using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Library;

namespace BookStorageInterfaces
{
    /// <summary>
    /// Class XmlFile allows you to write to XML file Book list and read from XML file
    /// </summary>
    class XmlFile : IBookStorage
    {
        /// <summary>
        /// The path to the file.
        /// </summary>
        public string Path { get; }
        /// <summary>
        /// XmlFile ctor
        /// </summary>
        /// <param name="filePath">The path of the file</param>
        public XmlFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentNullException($"{nameof(filePath)} is null.");
            if (!File.Exists(filePath)) throw new ArgumentNullException($"{nameof(filePath)} does not exist.");
            Path = filePath;
        }
        /// <summary>
        /// Reads from storage list of Books
        /// </summary>
        /// <returns>Returns Book list</returns>
        public List<Book> ReadFromStorage()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Book>));
            List<Book> bookList = new List<Book>();
            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
            {
                bookList = (List<Book>)formatter.Deserialize(fs);
            }
            return bookList;
        }

        /// <summary>
        /// Write to file list of Books
        /// </summary>
        /// <param name="bookList">List of Books</param>
        public void WriteToStorage(List<Book> bookList)
        {
            if (ReferenceEquals(bookList, null)) throw new ArgumentNullException($"{nameof(bookList)} is null.");

            XmlSerializer formatter = new XmlSerializer(typeof(List<Book>));
            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, bookList);
            }
        }
    }
}
