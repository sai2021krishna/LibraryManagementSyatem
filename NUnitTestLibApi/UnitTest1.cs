using lib_manag_sys;
using lib_manag_sys.Controllers;
using lib_manag_sys.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;

namespace NUnitTestLibApi
{
    public class Tests
    {

        List<Books> books = new List<Books>();
        IQueryable<Books> bookdata;
        Mock<DbSet<Books>> mockSet;
        Mock<Library_management_systemContext> bookcontextmock;
        [SetUp]
        public void Setup()
        {
            books = new List<Books>()
            {
                new Books{BookId=1,BookName="kite runner",BookAuthor="khaled",BookEdition=1},
                 new Books{BookId=2,BookName="another kite runner",BookAuthor="khaled",BookEdition=2}

            };

            bookdata = books.AsQueryable();
            mockSet = new Mock<DbSet<Books>>();
            mockSet.As<IQueryable<Books>>().Setup(m => m.Provider).Returns(bookdata.Provider);
            mockSet.As<IQueryable<Books>>().Setup(m => m.Expression).Returns(bookdata.Expression);
            mockSet.As<IQueryable<Books>>().Setup(m => m.ElementType).Returns(bookdata.ElementType);
            mockSet.As<IQueryable<Books>>().Setup(m => m.GetEnumerator()).Returns(bookdata.GetEnumerator());
            var p = new DbContextOptions<Library_management_systemContext>();
            bookcontextmock = new Mock<Library_management_systemContext>(p);
            bookcontextmock.Setup(x => x.Books).Returns(mockSet.Object);



        }

        [Test]
        public void GetAllBooksTest()
        {
            var bookingrepo = new book_management(bookcontextmock.Object);
            var bookinglist = bookingrepo.GetAllBooks();
            Assert.IsNotNull(bookinglist);

        }
        [Test]
        public void GetBookWithIdTest()
        {
            
            var bookingrepo = new book_management(bookcontextmock.Object);
            var bookinglist = bookingrepo.GetBookWithId(1);
            Assert.IsNotNull(bookinglist);




        }
        [Test]
        public void AddBookingDetailTest()
        {
            
            var bookingrepo = new book_management(bookcontextmock.Object);
            var bookingobj = bookingrepo.AddNewBook(new Books { BookName = "third kite runner", BookAuthor = "khaled", BookEdition = 2 });
            //Assert.IsNotNull(bookingobj);
            Assert.AreEqual(true, bookingobj);
        }

        [Test]
        public void UpdateBookDetailsTest()
        {
            var bookingrepo = new book_management(bookcontextmock.Object);
            var bookupdate = bookingrepo.UpdateBook(1, new Books {BookName = "high 5", BookAuthor = "sam anand", BookEdition = 2 });
            Assert.AreEqual(true, bookupdate);
        }

        [Test]
        public void DeleteBookTest()
        {
            var bookingrepo = new book_management(bookcontextmock.Object);
            var bookdelete = bookingrepo.DeleteExistingBook(2);
            Assert.AreEqual(true, bookdelete);
        }
    }
}