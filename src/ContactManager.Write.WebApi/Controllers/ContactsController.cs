using ContactManager.Application.Contacts.Commands;
using ContactManager.Application.Contacts.Queries;
using ContactManager.Domain.Contacts;
using ContactManager.Write.WebApi.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Write.WebApi.Controllers
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContactViewModel contactViewModel)
        {
            Contact contact = await _mediator.Send(
                new CreateContactCommand
                {
                    FirstName = contactViewModel.FirstName,
                    Surname = contactViewModel.Surname,
                    BirthDate = contactViewModel.BirthDate,
                    PhoneNumber = contactViewModel.PhoneNumber,
                    IBAN = contactViewModel.IBAN,
                    Address = contactViewModel.Address == null ? null : new AddressCommand
                    {
                        Street = contactViewModel.Address.Street,
                        City = contactViewModel.Address.City,
                        Country = contactViewModel.Address.Country,
                        Postcode = contactViewModel.Address.Postcode,
                    }
                });

            return Ok(new ContactViewModel(contact));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ContactViewModel contactViewModel)
        {
            Contact contact = await _mediator.Send(
                new UpdateContactCommand
                {
                    Id = contactViewModel.Id,
                    FirstName = contactViewModel.FirstName,
                    Surname = contactViewModel.Surname,
                    BirthDate = contactViewModel.BirthDate,
                    PhoneNumber = contactViewModel.PhoneNumber,
                    IBAN = contactViewModel.IBAN,
                    Address = contactViewModel.Address == null ? null : new AddressCommand
                    {
                        Street = contactViewModel.Address.Street,
                        City = contactViewModel.Address.City,
                        Country = contactViewModel.Address.Country,
                        Postcode = contactViewModel.Address.Postcode,
                    }
                });

            return Ok(new ContactViewModel(contact));
        }

        [HttpDelete("{contactId}")]

        public async Task<IActionResult> Delete(int contactId)
        {
            await _mediator.Send(
                new DeleteContactCommand
                {
                    ContactId = contactId
                });

            return Ok();
        }
    }
}