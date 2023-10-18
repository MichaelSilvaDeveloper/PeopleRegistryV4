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
    public class UpdatePersonHandler : IRequestHandler<UpdatePersonRequest, UpdatePersonResponse>
    {
        private readonly IPerson _iPerson;

        public UpdatePersonHandler(IPerson iPerson)
        {
            _iPerson = iPerson;
        }

        public async Task<UpdatePersonResponse> Handle(UpdatePersonRequest request, CancellationToken cancellationToken)
        {
            var updatePersonById = await _iPerson.GetPersonById(request.Id);
            updatePersonById.Name = request.Name;
            updatePersonById.Email = request.Email;
            await _iPerson.UpdatePerson(updatePersonById, request.Id);
            throw new Exception($"Editado");
            //return Task.FromResult();
        }
    }
}