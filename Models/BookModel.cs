using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_REST_Test.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public AuthorModel Author { get; set; }
        public string Name { get; set; }
    }
}