using FirestoreUserDemo.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirestoreUserDemo.GraphQL.Types
{
    public class AdressType : ObjectGraphType<Adress>
    {
        public AdressType()
        {
            Name = "Adress";
            Field(_ => _.City).Description("City of user");
            Field(_ => _.Country).Description("Country of user");
            Field(_ => _.Neighborhood).Description("Neighborhood of user");
            Field(_ => _.Number).Description("Number of user");
            Field(_ => _.State).Description("State of user");
            Field(_ => _.Street).Description("Street of user");
            Field(_ => _.ZipCode).Description("ZipCode of user");
        }
    }
}
