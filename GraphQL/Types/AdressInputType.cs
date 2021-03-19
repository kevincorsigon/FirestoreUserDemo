using FirestoreUserDemo.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirestoreUserDemo.GraphQL.Types
{
    public class AdressInputType : InputObjectGraphType<Adress>
    {
        public AdressInputType()
        {
            Name = "AdressImput";
            Field<StringGraphType>("city");
            Field<StringGraphType>("country");
            Field<StringGraphType>("neighborhood");
            Field<IntGraphType>("number");
            Field<StringGraphType>("state");
            Field<StringGraphType>("street");
            Field<IntGraphType>("zipCode");
        }       
    }
}
