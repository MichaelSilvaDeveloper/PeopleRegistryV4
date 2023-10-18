using Domain.Command.Requests;
using Domain.Command.Responses;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Handler
{
    public class DeletePersonHandler : IRequestHandler<DeletePersonRequest, DeletePersonResponse>
    {
        private readonly IPerson _iPerson;

        public DeletePersonHandler(IPerson iPerson)
        {
            _iPerson = iPerson;
        }

        public async Task<DeletePersonResponse> Handle(DeletePersonRequest request, CancellationToken cancellationToken)
        {
            //var deletePersonById = await _iPerson.GetPersonById(request.Id);
            await _iPerson.DeletePerson(request.Id);
            return null;
        }
    }
}