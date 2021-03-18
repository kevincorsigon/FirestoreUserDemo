using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using FirestoreUserDemo.Models;

namespace FirestoreUserDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        const string _projectId = "viagens-307823";

        private readonly FirestoreDb _db;

        public UserController()
        {
            _db = FirestoreDb.Create(_projectId);
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            CollectionReference usersRef = _db.Collection("users");
            QuerySnapshot snapshot = await usersRef.GetSnapshotAsync();
            return ConvertToType<User>(snapshot);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<User> Get([FromRoute] string id)
        {
            var usersRef = await _db.Collection("users").Document(id).GetSnapshotAsync();
            return usersRef.ConvertTo<User>();
        }

        [HttpPost]
        public async Task<User> Post([FromBody] User user)
        {
            if (string.IsNullOrWhiteSpace(user.Id))
            {
                user.Id = Guid.NewGuid().ToString();
            }

            DocumentReference docRef = _db.Collection("users").Document(user.Id);
            await docRef.SetAsync(user);
            return user;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<User> Put([FromRoute] string id, [FromBody] User user)
        {
            user.Id = id;
            DocumentReference docRef = _db.Collection("users").Document(user.Id);
            await docRef.SetAsync(user, SetOptions.MergeAll);
            return user;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task Delete([FromRoute] string id)
        {
            await _db.Collection("users").Document(id).DeleteAsync();
        }


        private IEnumerable<T> ConvertToType<T>(QuerySnapshot snapshot) where T : class
        {
            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                yield return document.ConvertTo<T>();
            }
        }
    }
}
