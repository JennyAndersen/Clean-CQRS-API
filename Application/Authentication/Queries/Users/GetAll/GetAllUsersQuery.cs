using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Queries.Users.GetAll
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {

    }
}
