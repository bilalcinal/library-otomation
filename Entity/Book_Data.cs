using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entity
{
  public  class Book_Data
    {
        int BookId;
        string BookName, BookType, BookPage, BookWriter;

        public int BkId { get => BookId; set => BookId = value; }
        public string BkName { get => BookName; set => BookName = value; }
        public string BkType { get => BookType; set => BookType = value; }
        public string BkPage { get => BookPage; set => BookPage = value; }
        public string BkWriter { get => BookWriter; set => BookWriter = value; }
    }
}
