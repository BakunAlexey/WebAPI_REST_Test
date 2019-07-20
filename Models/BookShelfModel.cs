using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_REST_Test.Models
{
    public class BookshelfModel
    {
        public int Id { get; set; }
        public List<BookModel> Books { get; set; }
    }
}