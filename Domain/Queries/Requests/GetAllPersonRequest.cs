using Domain.Queries.Responses;
using Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queries.Requests
{
    public class GetAllPersonRequest : IRequest<List<Person>>
    {
    }
}