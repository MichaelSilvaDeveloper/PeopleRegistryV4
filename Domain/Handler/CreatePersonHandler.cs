using Domain.Command.Requests;
using Domain.Command.Responses;
using Domain.Interfaces;
using Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Handler
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonRequest, CreatePersonResponse>
    {
        private readonly IPerson _iPerson;

        public CreatePersonHandler(IPerson iPersonTwo)
        {
            _iPerson = iPersonTwo;
        }

        public async Task<CreatePersonResponse> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
        {
            var result = new Person(request.Name, request.Email);
            await _iPerson.InsertPerson(result);
            return null;
        }
    }
}