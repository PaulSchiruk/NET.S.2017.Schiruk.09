using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace BookStorageInterfaces
{
    class BinFileStorage : IBookStorage
    {
        public List<Book> ReadFromStorage()
        {
            throw new NotImplementedException();
        }

        public void WriteToStorage(List<Book> bookList)
        {
            throw new NotImplementedException();
        }
    }
}
