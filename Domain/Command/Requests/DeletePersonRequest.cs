using Domain.Command.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Command.Requests
{
    public class DeletePersonRequest : IRequest<DeletePersonResponse>
    {
        public int Id { get; set; }
    }
}