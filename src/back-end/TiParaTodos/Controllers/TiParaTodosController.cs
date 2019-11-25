using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using TiParaTodos.Models;

namespace TiParaTodos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TiParaTodosController : ControllerBase
    {
        private static readonly List<Contact> Contacts = new List<Contact>();

        private readonly ILogger<TiParaTodosController> _logger;

        public TiParaTodosController(ILogger<TiParaTodosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return Contacts.ToArray();
        }

        [HttpPost]
        public IEnumerable<Contact> Post(Contact contact)
        {
            Contacts.Add(contact);

            return Contacts.ToArray();
        }
    }

}
