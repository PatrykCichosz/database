//using Google.Cloud.Firestore;
//using MmaApi.Models;

//namespace MmaApi.Services
//{
//    public class FirestoreService
//    {
//        private readonly FirestoreDb _db;

//        public FirestoreService()
//        {
//            var keyPath = Path.Combine(Directory.GetCurrentDirectory(), "serviceAccountKey.json");
//            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", keyPath);
//            _db = FirestoreDb.Create("ead2-ca2-df0c6");
//        }

//        public async Task<List<Fighter>> GetFightersAsync()
//        {
//            var fighters = new List<Fighter>();
//            var snapshot = await _db.Collection("Fighters").GetSnapshotAsync();
//            foreach (var doc in snapshot.Documents)
//            {
//                var f = doc.ConvertTo<Fighter>();
//                f.Id = doc.Id;
//                fighters.Add(f);
//            }
//            return fighters;
//        }

//        public async Task<Fighter?> GetFighterById(string id)
//        {
//            var doc = await _db.Collection("Fighters").Document(id).GetSnapshotAsync();
//            return doc.Exists ? doc.ConvertTo<Fighter>() with { Id = doc.Id } : null;
//        }

//        public async Task AddFighterAsync(Fighter fighter)
//        {
//            await _db.Collection("Fighters").AddAsync(fighter);
//        }

//        public async Task DeleteFighterAsync(string id)
//        {
//            await _db.Collection("Fighters").Document(id).DeleteAsync();
//        }
//    }
//}
