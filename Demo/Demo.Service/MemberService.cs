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
            try
            {
                var member = _repo.Get(memberId);

                return member;
            }
            catch
            {
                return null;
            }
        }

        public bool Save(Member member, bool isEdit)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(member.Name) ||
                    member.Sex == 0 ||
                    string.IsNullOrWhiteSpace(member.Telephone))
                    return false;

                var result = isEdit ? _repo.Update(member.MemberId, member) : _repo.Create(member);

                return result;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int memberId)
        {
            try
            {
                return _repo.Delete(memberId);
            }
            catch
            {
                return false;
            }
        }
    }
}