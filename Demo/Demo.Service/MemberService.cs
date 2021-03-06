using System.Collections;
using System.Collections.Generic;
using Demo.Domain.Entity;
using Demo.Domain.Interface;

namespace Demo.Service
{
    public class MemberService
    {
        private readonly IGenericRepository<Member> _repo;

        public MemberService(IGenericRepository<Member> repo)
        {
            _repo = repo;
        }

        public Member GetById(int memberId)
        {
            var member = _repo.Get(memberId);

            return member;
        }

        public IEnumerable<Member> GetAll()
        {
            var data = _repo.Get();

            return data;
        }

        public bool Save(Member member, bool isEdit)
        {
            if (string.IsNullOrWhiteSpace(member.Name) ||
                member.Sex == 0 ||
                string.IsNullOrWhiteSpace(member.Telephone))
                return false;

            var result = isEdit ? _repo.Update(member.MemberId, member) : _repo.Create(member);

            return result;
        }

        public bool Delete(int memberId)
        {
            return _repo.Delete(memberId);
        }
    }
}