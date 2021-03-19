using FirestoreUserDemo.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirestoreUserDemo.GraphQL.Types
{
    public class UserInputType : InputObjectGraphType
    {
        public UserInputType()
        {
            Name = "UserInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("userName");       
            Field<StringGraphType>("id");
            Field<StringGraphType>("surname");
            Field<StringGraphType>("email");
            Field<StringGraphType>("password");
            Field<AdressInputType>("adress");          
        }
    }
}
