using System;
using System.Data.Entity;
using System.Linq;
using Demo.Domain.Entity;
using Demo.Domain.Enum;
using Demo.Domain.Interface;
using ORMMember = Demo.DAL.ORMModel.Member;

namespace Demo.DAL.Repository
{
    public class MemberRepository : IGenericRepository<Member>
    {
        private readonly DbContext _context;
        private readonly DbSet<ORMMember> _db;

        public MemberRepository(IDbContext dbContext)
        { 
            _context = dbContext.DbContext; 
            _db = _context.Set<ORMMember>();
        }

        public Member Get(int id)
        {
            var entity = _db.AsNoTracking().SingleOrDefault(x => x.Id == id);

            if (entity == null)
                return null;

            var member = new Member
            {
                MemberId = entity.Id,
                Name = entity.Name,
                Sex = (Sex) entity.Sex,
                Telephone = entity.Telephone,
                Address = entity.Address
            };

            return member;
        }

        public bool Create(Member entity)
        {
            try
            {
                _db.Add(new ORMMember
                { 
                    Name = entity.Name,
                    Sex = (int) entity.Sex,
                    Telephone = entity.Telephone,
                    Address = entity.Address
                });

                _context.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool Update(int id, Member entity)
        {
            try
            {
                var old = _db.Find(id);

                if (old == null)
                    return false;
 
                var entry = _context.Entry(old); 
                
                entry.CurrentValues.SetValues(entity);

                _context.SaveChanges();

                return true;
            }
            catch  
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = _db.Find(id);

                if (entity == null)
                    return false;

                _db.Remove(entity);

                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}