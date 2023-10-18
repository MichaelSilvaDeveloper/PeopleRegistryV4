    using Domain.Interfaces;
using Domain.Queries.Requests;
using Domain.Queries.Responses;
using Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Queries.Handler
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdRequest, Person>
    {
        private readonly IPerson _iPerson;

        public GetPersonByIdHandler(IPerson iPerson)
        {
            _iPerson = iPerson;
        }

        public async Task<Person> Handle(GetPersonByIdRequest request, CancellationToken cancellationToken)
        {
            return await _iPerson.GetPersonById(request.Id);
        }
    }
}