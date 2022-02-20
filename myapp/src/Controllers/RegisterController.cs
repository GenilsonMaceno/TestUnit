using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Entities;
using src.Repositories;

namespace src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        private readonly IRegisterRepository _registerRepository;

        public RegisterController(IRegisterRepository registerRepository){
            _registerRepository = registerRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<EntityPerson>> Get()
        {

            var register = _registerRepository.Get().ToList();

            return register;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<EntityPerson>> Get(int id)
        {
            var registerId = _registerRepository.GetById(id).ToList();

            return registerId;
        }

        // POST api/values
        [HttpPost]
        public ActionResult<bool> Post([FromBody] EntityPerson entityPerson)
        {
            var result = _registerRepository.Add(entityPerson);

            return result;

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}