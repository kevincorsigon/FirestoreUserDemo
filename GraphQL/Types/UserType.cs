using FirestoreUserDemo.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirestoreUserDemo.GraphQL.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Name = "User";
            Field(_ => _.Id).Description("User's Id.");
            Field(_ => _.Name).Description("First name of the user");
            Field(_ => _.Surname).Description("Last name of the user");
            Field(_ => _.UserName).Description("UserName of the user");
            Field(_ => _.Email).Description("Email of the user");
            Field(
            name: "Adress",
            type: typeof(AdressType),
            resolve: context => context.Source.Adress);
            Field(_ => _.Password).Description("Password of the user");
        }
    }
}
