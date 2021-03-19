using FirestoreUserDemo.GraphQL.Types;
using FirestoreUserDemo.Models;
using FirestoreUserDemo.Services;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirestoreUserDemo.GraphQL
{
    public class Query : ObjectGraphType
    {
        IUserService _userService;

        public Query(IUserService userService)
        {
            _userService = userService;

            Field<ListGraphType<UserType>>(
            name: "users", resolve: context => 
            {
                return _userService.GetAll().Result;
            });

            Field<UserType>(
                name: "user",
                arguments: new QueryArguments(new
                QueryArgument<StringGraphType>
                { Name = "id" }),
                resolve: context =>
                {
                   var id = context.GetArgument<string>("id");
                    return _userService.GetById(id);
                }
            );
          
        }    
    }
}
