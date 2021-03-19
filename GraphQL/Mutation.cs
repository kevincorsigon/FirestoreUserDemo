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
    public class Mutation : ObjectGraphType
    {
        IUserService _userService;

        public Mutation(IUserService userService)
        {
            _userService = userService;

            Field<UserType>("addUser",arguments: new QueryArguments(new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }),
            resolve: context =>
            {
                var user = context.GetArgument<User>("user");
                return _userService.Create(user).Result;
            });

            Field<UserType>("updateUser", arguments: new QueryArguments(new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }),
            resolve: context =>
            {
               var user = context.GetArgument<User>("user");
               return _userService.Update(user).Result;
            });

            Field<StringGraphType>("removeUser", arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id" }),
            resolve: context =>
            {
                var id = context.GetArgument<string>("id");
                 _userService.Delete(id);
                return id;
            });
        }
    }
}
