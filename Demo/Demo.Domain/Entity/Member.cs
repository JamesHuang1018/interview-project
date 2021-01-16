using Demo.Domain.Enum;

namespace Demo.Domain.Entity
{
    public sealed class Member
    {
        public int MemberId { get; set; }

        public string Name { get; set; }

        public Sex Sex { get; set; }

        public string Telephone { get; set; }

        public string Address { get; set; }
    }
}