using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceStore.Api.Book.Application;

namespace ServiceStore.Api.Book.Controllers
{
    [Route("api/[controller]")] //api/book
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Execute data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<BookAuthorDto>>> GetBooks()
        {
            return await _mediator.Send(new Query.Execute());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookAuthorDto>> GetBook(Guid id)
        {
            return await _mediator.Send(new QueryFiltered.UniqueBook { BookId = id });
        }
    }
}
