using System;
using System.Collections.Generic;
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

        public IEnumerable<Member> Get()
        {
            var data = _db.AsNoTracking().Select(x=>new Member
            {
                MemberId = x.Id,
                Name = x.Name,
                Sex = (Sex) x.Sex,
                Telephone = x.Telephone,
                Address = x.Address
            }).ToList();

            return data;
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

        public bool Update(int id, Member entity)
        {
            var old = _db.Find(id);

            if (old == null)
                return false;
 
            var entry = _context.Entry(old); 
                
            entry.CurrentValues.SetValues(entity);

            _context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var entity = _db.Find(id);

            if (entity == null)
                return false;

            _db.Remove(entity);

            _context.SaveChanges();

            return true;
        }
    }
}