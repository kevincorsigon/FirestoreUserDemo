using FirestoreUserDemo.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirestoreUserDemo.Services
{
    public class UserService : IUserService
    {
        const string _projectId = "viagens-307823";

        private readonly FirestoreDb _db;

        public UserService()
        {
            _db = FirestoreDb.Create(_projectId);
        }

        public async Task<User> Create(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Id))
            {
                user.Id = Guid.NewGuid().ToString();
            }

            DocumentReference docRef = _db.Collection("users").Document(user.Id);
            await docRef.SetAsync(user);
            return user;
        }

        public Task Delete(string id)
        {
            return _db.Collection("users").Document(id).DeleteAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            CollectionReference usersRef = _db.Collection("users");
            QuerySnapshot snapshot = await usersRef.GetSnapshotAsync();
            return ConvertToType<User>(snapshot);
        }

        public async Task<User> GetById(string id)
        {
            var usersRef = await _db.Collection("users").Document(id).GetSnapshotAsync();
            return usersRef.ConvertTo<User>();
        }

        public async Task<User> Update(User user)
        {
            DocumentReference docRef = _db.Collection("users").Document(user.Id);
            await docRef.SetAsync(user, SetOptions.MergeAll);
            return user;
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
