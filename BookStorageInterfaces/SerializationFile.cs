using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Library;

namespace BookStorageInterfaces
{
    /// <summary>
    /// Class SerializationFile allows you to write to binary file Book list and read from din file
    /// </summary>
    class SerializationFile : IBookStorage
    {
        /// <summary>
        /// The path to the file.
        /// </summary>
        public string Path { get; }
        /// <summary>
        /// SerializationFile ctor
        /// </summary>
        /// <param name="filePath">The path of the file</param>
        public SerializationFile(string filePath)
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

            BinaryFormatter formatter = new BinaryFormatter();
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
            
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, bookList);
            }
        }
    }
}
