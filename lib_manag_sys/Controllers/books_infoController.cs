using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lib_manag_sys.Repository;
using System.IO;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Cors;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Log4net.config", Watch = true)]
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lib_manag_sys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class books_infoController : ControllerBase
    {
        private readonly Ibook_management ibook;
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // GET: api/<books_infoController>
        public books_infoController(Ibook_management obj)
        {
            this.ibook = obj;

        }
        [HttpGet]
        [Route("getAllBooks")]
        public IActionResult getAllBooks()
        {

            BasicConfigurator.Configure();
            log.Info("entering into get all books");
            return Ok(ibook.GetAllBooks());

        }

        // GET api/<ValuesController>/5
        [HttpGet]
        [Route("getBookById")]
        public IActionResult getBookById(int id)
        {
            BasicConfigurator.Configure();
            log.Info("entering into get book by ID");
            Books book = ibook.GetBookWithId(id);
            if (book == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(book);
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        [Route("addNewBook")]
        public IActionResult addNewBook([FromBody] Books value)
        {
            BasicConfigurator.Configure();
            log.Info("entering into Add New Book");
            bool result = ibook.AddNewBook(value);
            if (result == false)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        [Route("editABook")]
        public IActionResult editABook(int id, [FromBody] Books value)
        {
            BasicConfigurator.Configure();
            log.Info("entering into Update Book Information");
            bool result = ibook.UpdateBook(id, value);
            if (result == false)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete]
        [Route("deleteABook")]
        public IActionResult deleteABook(int id)
        {

            BasicConfigurator.Configure();
            log.Info("Deleting a book by taking its Id");
            bool result = ibook.DeleteExistingBook(id);
            if (result == false)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }
    }
}
