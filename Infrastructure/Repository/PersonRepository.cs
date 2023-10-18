using Domain.Interfaces;
using Entities.Models;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class PersonRepository : IPerson
    {
        public readonly PeopleRegistryDBContext _dBContext;

        public PersonRepository(PeopleRegistryDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<List<Person>> ShowPeople()
        {
            return await _dBContext.Pessoa.ToListAsync();
        }

        public async Task<Person> GetPersonById(int id)
        {
            var getPersonById = await _dBContext.Pessoa.FirstOrDefaultAsync(x => x.Id == id);
            if (getPersonById == null)
                throw new Exception($"Pessoa para o id: {id} não foi encontrado");
            return getPersonById;
        }

        public async Task InsertPerson(Person person)
        {
            await _dBContext.Pessoa.AddAsync(person);
            await _dBContext.SaveChangesAsync();
        }

        public async Task DeletePerson(int id)
        {
            var deletePersonById = await GetPersonById(id);
            if (deletePersonById == null)
                throw new Exception($"Pessoa para o id: {id} não foi encontrado");
            _dBContext.Pessoa.Remove(deletePersonById);
            await _dBContext.SaveChangesAsync();
        }

        public async Task UpdatePerson(Person person, int id)
        {
            var updatePersonById = await GetPersonById(id);
            if (updatePersonById == null)
                throw new Exception($"Pessoa para o id: {id} não foi encontrado");

            updatePersonById.Name = person.Name;
            updatePersonById.Email = person.Email;

            _dBContext.Pessoa.Update(updatePersonById);
            await _dBContext.SaveChangesAsync();
        }
    }
}