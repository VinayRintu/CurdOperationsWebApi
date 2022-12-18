using CurdOperationsWebApi.Data;
using CurdOperationsWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace CurdOperationsWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ApiDbContext dbcontext;

        public ContactsController(ApiDbContext _dbcontext)
        {
            this.dbcontext = _dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await dbcontext.Contacts.ToListAsync());
        }
        
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContact([FromRoute] Guid id)
        {
            var contact = dbcontext.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }
        
        [HttpPost]
        public async Task< IActionResult> AddContact(AddContactRequest addContactRequest)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                FullName = addContactRequest.FullName,
                Address = addContactRequest.Address,
                Phone = addContactRequest.Phone,
                Email = addContactRequest.Email,
            };
              await dbcontext.Contacts.AddAsync(contact);
              await dbcontext.SaveChangesAsync();

            return Ok(contact);
        }
        
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute] Guid id, UpdateContactRequest updateContactRequest)
        {
            var contact = await dbcontext.Contacts.FindAsync(id);
            if(contact !=null)
            {
                contact.FullName= updateContactRequest.FullName;
                contact.Address= updateContactRequest.Address;
                contact.Phone= updateContactRequest.Phone;
                contact.Email= updateContactRequest.Email;

                await dbcontext.SaveChangesAsync();

                return Ok(contact);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var contact = await dbcontext.Contacts.FindAsync(id);
            if(contact!=null)
            {
                dbcontext.Remove(contact);
                await dbcontext.SaveChangesAsync();
                return Ok(contact); //return OK("Successfully Deleted")  We Can Use This Also
            }
            return NotFound();
        }
    }
}
