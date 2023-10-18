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
    public class GetAllPersonQueryHandler : IRequestHandler<GetAllPersonRequest, List<Person>>
    {
        private readonly IPerson _iPerson;

        public GetAllPersonQueryHandler(IPerson iPerson)
        {
            _iPerson = iPerson;
        }

        public async Task<List<Person>> Handle(GetAllPersonRequest request, CancellationToken cancellationToken)
        {
            return await _iPerson.ShowPeople();          
        }
    }
}