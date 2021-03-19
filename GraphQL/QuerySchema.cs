using FirestoreUserDemo.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirestoreUserDemo.GraphQL
{
    public class FirestoreSchema : Schema, ISchema
    {
        public FirestoreSchema(IServiceProvider services)
        {
            Query = (Query)services.GetService(typeof(Query));
            Mutation = (Mutation)services.GetService(typeof(Mutation));
        }
    }
}
