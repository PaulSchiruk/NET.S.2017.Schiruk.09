﻿using System;
using System.Collections.Generic;
using System.IO;
using Library;

namespace BookStorageInterfaces
{
    /// <summary>
    /// Class BinFileStorage allows you to write to binary file Book list and read from bin file
    /// </summary>
    class BinFileStorage : IBookStorage
    {
        /// <summary>
        /// The path to the file.
        /// </summary>
        public string Path { get; }
        /// <summary>
        /// BinFileStorage ctor
        /// </summary>
        /// <param name="filePath">The path of the file</param>
        public BinFileStorage(string filePath)
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
            List<Book> bookList = new List<Book>();

            using (BinaryReader reader = new BinaryReader(File.Open(Path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    var authorName = reader.ReadString();
                    var bookName = reader.ReadString();
                    var country = reader.ReadString();
                    var publishedYear = reader.ReadInt32();

                    bookList.Add(new Book
                    {
                        AuthorName = authorName,
                        BookName = bookName,
                        Country = country,
                        PublishedYear = publishedYear
                    });
                }
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

            using (BinaryWriter writer = new BinaryWriter(File.Open(Path, FileMode.OpenOrCreate)))
            {
                foreach (Book b in bookList)
                {
                    writer.Write(b.AuthorName);
                    writer.Write(b.BookName);
                    writer.Write(b.Country);
                    writer.Write(b.PublishedYear);
                }
            }
        }
    }
}
