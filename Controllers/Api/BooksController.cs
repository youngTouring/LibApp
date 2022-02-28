using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using LibApp.Data;
using LibApp.Dtos;
using LibApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET /api/books
        [HttpGet]
        //[Authorize(Roles = Role.User)]
        public IActionResult GetBooks(string query = null)
        {
            IEnumerable<Book> bookQuery = _context.Books.Include(b => b.Genre).ToList();

                //.Include(b => b.Genre)
                //.ToList()
                //.Select(_mapper.Map<Book, BookDto>);

            if (!String.IsNullOrWhiteSpace(query))
            {
                bookQuery = bookQuery.Where(c => c.Name.Contains(query));
            }

            var customerDtos = bookQuery.Select(_mapper.Map<Book, BookDto>);
            
            return Ok(customerDtos);
        }

        private ApplicationDbContext _context;
        private IMapper _mapper;
    }
}
