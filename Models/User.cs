using Google.Cloud.Firestore;
using System;

namespace FirestoreUserDemo.Models
{
    [FirestoreData]
    public class User
    {
        [FirestoreDocumentId]
        public string Id { get; set; }

        [FirestoreProperty("name")]
        public string Name { get; set; }

        [FirestoreProperty("surname")]
        public string Surname { get; set; }

        [FirestoreProperty("userName")]
        public string UserName { get; set; }

        [FirestoreProperty("password")]
        public string Password { get; set; }

        [FirestoreProperty("email")]
        public string Email { get; set; }

        [FirestoreProperty("adress")]
        public Adress Adress { get; set; }

        public int Version { get; set; }

    }
}
