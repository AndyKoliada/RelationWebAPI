
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WebAPI.Core.Repositories;
//using WebAPI.ModelsConnected;

//namespace WebAPI.Repository
//{
//    public class RelationContext : DbContext
//    {
//        public DbSet<Relation> Relations { get; set; }
//    }

//    public class UserRepository : IRepository<Relation>
//    {
//        RelationContext db;
//        public UserRepository()
//        {
//            db = new RelationContext();
//        }
//        public IEnumerable<Relation> GetAll()
//        {
//            return db.Relations.ToList();
//        }

//        public Relation Get(int id)
//        {
//            return db.Relations.Find(id);
//        }

//        public void Create(Relation item)
//        {
//            db.Relations.Add(item);
//        }

//        public void Update(Relation item)
//        {
//            db.Entry(item).State = EntityState.Modified;
//        }

//        public void Delete(int id)
//        {
//            Relation relation = db.Relations.Find(id);
//            if (relation != null)
//                db.Relations.Remove(relation);
//        }

//        public void Save()
//        {
//            db.SaveChanges();
//        }

//        private bool disposed = false;

//        public virtual void Dispose(bool disposing)
//        {
//            if (!this.disposed)
//            {
//                if (disposing)
//                {
//                    db.Dispose();
//                }
//            }
//            this.disposed = true;
//        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//    }
    
//}
