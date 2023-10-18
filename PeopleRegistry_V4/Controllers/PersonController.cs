using Application.Interfaces;
using Domain.Command.Requests;
using Domain.Command.Responses;
using Domain.Queries.Requests;
using Domain.Queries.Responses;
using Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleRegistry_V4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        //private readonly IPersonApplication _iPersonApplication;
        private readonly IMediator _iMediator;


        public PersonController(IMediator iMediator)
        {
            _iMediator = iMediator; 
        }

        /*
        [HttpGet]
        public async Task<List<Person>> ShowPeople()
        {
            return await _iPersonApplication.ShowPeople();
        }
        */

        [HttpGet]
        public async Task<List<Person>> ShowPeople()
        {
            return await _iMediator.Send(new GetAllPersonRequest());
        }

        /*

        [HttpGet("{id}")]
        public async Task<Person> GetPersonById(int id)
        {
            return await _iPersonApplication.GetPersonById(id);
        }

        */

        [HttpGet("{id}")]
        public async Task<Person> GetPersonById(int id)
        {
            var person = await _iMediator.Send(new GetPersonByIdRequest() { Id = id});
            return person;
        }

        //[HttpPost]
        //public async Task InsertPerson([FromBody] Person person)
        //{
        //    await _iPersonApplication.InsertPerson(person);
        //}

        [HttpPost]
        public async Task<CreatePersonResponse> Create([FromServices] IMediator mediator, [FromBody] CreatePersonRequest command)
        {
            return await mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<DeletePersonResponse> Delete([FromServices] IMediator mediator, DeletePersonRequest command)
        {
            return await mediator.Send(command);
        }

        //[HttpDelete]
        //public async Task DeletePerson(int id)
        //{
        //    await _iPersonApplication.DeletePerson(id);
        //}

        [HttpPut]
        public async Task<UpdatePersonResponse> Update([FromServices] IMediator mediator, [FromBody] UpdatePersonRequest command)
        {
            return await mediator.Send(command);
        }

        //[HttpPut("{id}")]
        //public async Task UpdatePerson(Person person, int id)
        //{
        //    await _iPersonApplication.UpdatePerson(person, id);
        //}
    }
}