using Google.Cloud.Firestore;

namespace FirestoreUserDemo.Models
{
    [FirestoreData]
    public class Adress
    {
        [FirestoreProperty("street")]
        public string Street { get; set; }

        [FirestoreProperty("number")]
        public int Number { get; set; }

        [FirestoreProperty("city")]
        public string city { get; set; }

        [FirestoreProperty("state")]
        public string State { get; set; }

        [FirestoreProperty("country")]
        public string Country { get; set; }

        [FirestoreProperty("neighborhood")]
        public string Neighborhood { get; set; }

        [FirestoreProperty("zipcode")]
        public int ZipCode { get; set; }
    }
}