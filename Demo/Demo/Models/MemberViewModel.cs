using Demo.Domain.Enum;

namespace Demo.Models
{
    public class MemberViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Sex Sex { get; set; }

        public string Telephone { get; set; }

        public string Address { get; set; }
    }
}