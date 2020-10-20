using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc_Client.Models;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Security.Policy;
using Newtonsoft.Json;

namespace Mvc_Client.Controllers
{
    public class CatalogController : Controller
    {
        // GET: CatalogController
        public async Task<IActionResult> Index()
        {
            IEnumerable<BookViewModel> books = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64043/api/books_info/");
                //HTTP GET
                var responseTask = await client.GetAsync("getAllBooks");
                

                
                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = responseTask.Content.ReadAsAsync<IList<BookViewModel>>();
                    

                    books = readTask.Result;
                }
                
            }
            return View(books);
        }

        // GET: CatalogController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            BookViewModel book = new BookViewModel();
            

            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri("http://localhost:64043/api/books_info/");
                //HTTP GET
                HttpResponseMessage responseTask = await client.GetAsync("getBookById?id=" + id.ToString());

                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = responseTask.Content.ReadAsStringAsync().Result;
                    book = JsonConvert.DeserializeObject<BookViewModel>(readTask);
                }
               
            }
            return View(book);
        }

        // GET: CatalogController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatalogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookViewModel book)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64043/");
                //HTTP POST
                var postTask = client.PostAsJsonAsync("api/books_info/addNewBook", book);

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            

            return View(book);
        }
    

        // GET: CatalogController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            BookViewModel book = new BookViewModel();

            using (var client = new HttpClient())
            {
               
                client.BaseAddress = new Uri("http://localhost:64043/api/books_info/");
                //HTTP GET
                HttpResponseMessage responseTask = await client.GetAsync("getBookById?id=" + id.ToString());

                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = responseTask.Content.ReadAsStringAsync().Result;
                    book = JsonConvert.DeserializeObject<BookViewModel>(readTask);
                }
            }

            return View(book);
        }

        // POST: CatalogController/Edit/5
        [HttpPost]
        public IActionResult Edit(BookViewModel book)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64043/");

                //HTTP POST
                var putTask = client.PutAsJsonAsync("api/books_info/editABook?id=" + book.bookId,book);
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(book);
        }


        // GET: CatalogController/Delete/5
        public IActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64043/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("api/books_info/deleteABook?id=" + id);


                var result = deleteTask.Result;


                return RedirectToAction("Index");

            }

        }
    }


}

