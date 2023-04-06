using ContactManager.Application.Contacts;
using ContactManager.Application.Contacts.Queries;
using ContactManager.Domain.Contacts;
using ContactManager.Infrastructure.Data.ContactReads;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Read.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContactsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("{contactId}")]
        public async Task<IActionResult> Get(int contactId)
        {
            ContactRead contact = await _mediator.Send(
                new GetContactByIdQuery
                {
                    ContactId = contactId
                });

            if (contact == null) return NotFound();

            return Ok(contact);
        }
    }
}