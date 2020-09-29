using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceStore.Api.Author.Application;
using ServiceStore.Api.Author.Model;

namespace ServiceStore.Api.Author.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Execute data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorDto>>> GetAuthors()
        {
            return await _mediator.Send(new Query.AuthorList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthor(string id)
        {
            return await _mediator.Send(new QueryFiltered.UniqueAuthor { AuthorBookGuid = id });
        }
    }
}
