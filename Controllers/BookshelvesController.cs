using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_REST_Test.Models;

namespace WebAPI_REST_Test.Controllers
{
    public class BookshelvesController : ApiController
    {
        private IList<BookshelfModel> bookshelves = new List<BookshelfModel>
        {
            new BookshelfModel
            {
                Id = 1,
                Books = new List<BookModel>
                {
                    new BookModel
                    {
                        Id = 1,
                        Name = "Приключения Тома Сойера",
                        Author = new AuthorModel { Id = 1, Name = "Марк Твен" }
                    },
                    new BookModel
                    {
                        Id = 2,
                        Name = @"CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#",
                        Author = new AuthorModel { Id = 1, Name = "Джеффри Рихтер" }
                    }
                }
            },
            new BookshelfModel
            {
                Id = 2,
                Books = new List<BookModel>
                {
                    new BookModel
                    {
                        Id = 3,
                        Name = @"C# 5.0 и платформа .NET 4.5 для профессионалов",
                        Author = new AuthorModel { Id = 1, Name = "Кристиан Нейгель" }
                    }
                }
            },
        };

        [HttpGet]
        public IEnumerable<BookshelfModel> GetBookshelves()
        {
            return bookshelves;
        }

        [HttpGet]
        public HttpResponseMessage GetBookshelf(int id)
        {
            var bookshelf = bookshelves.FirstOrDefault(x => x.Id == id);

            if (bookshelf != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, bookshelf);
            }

            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [HttpPost]
        public HttpResponseMessage PostBookshelf()
        {
            int id = 0;

            if (bookshelves.Count > 0)
            {
                id = bookshelves.Max(x => x.Id);
            }

            var bookshelf = new BookshelfModel { Id = id, Books = new List<BookModel>() }; 

            bookshelves.Add(bookshelf);

            return Request.CreateResponse(HttpStatusCode.Created, bookshelf);
        }

        //[HttpPut]
        //public HttpResponseMessage Put(int id, [FromBody]AuthorModel model)
        //{
        //    if (string.IsNullOrEmpty(model?.Name))
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }

        //    var author = authors.FirstOrDefault(x => x.Id == id);

        //    if (author != null)
        //    {
        //        author.Name = model.Name;

        //        return Request.CreateResponse(HttpStatusCode.OK, author);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.NotFound);
        //}

        [HttpDelete]
        public HttpResponseMessage DeleteBookshelf(int id)
        {
            var item = bookshelves.FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                bookshelves.Remove(item);

                return Request.CreateResponse(HttpStatusCode.OK, item);
            }

            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteBookshelves()
        {
            bookshelves.Clear();

            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}