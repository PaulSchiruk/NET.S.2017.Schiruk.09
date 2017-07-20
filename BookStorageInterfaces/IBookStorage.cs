using System.Collections.Generic;
using Library;

namespace BookStorageInterfaces
{
    public interface IBookStorage
    {
        List<Book> ReadFromStorage();
        void WriteToStorage(List<Book> bookList);

    }
}
