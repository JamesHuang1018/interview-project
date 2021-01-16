using Demo.Domain.Entity;
using Demo.Domain.Enum;
using Demo.Domain.Interface;
using Demo.Service;
using NSubstitute;
using NUnit.Framework;

namespace Demo.ServiceTest
{
    [TestFixture]
    public class MemberServiceTest
    {
        private IGenericRepository<Member> _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = Substitute.For<IGenericRepository<Member>>();

            _repository.Get(1).Returns(x => new Member
            {
                MemberId = 1,
                Name = "James",
                Sex = Sex.男,
                Telephone = "09xxxxx",
                Address = "Test Adress"
            });

            _repository.Create(Arg.Any<Member>()).Returns(x => true);

            _repository.Delete(1).Returns(x => true);

            _repository.Delete(Arg.Is<int>(i => i > 1)).Returns(x => false);
        }

        [Test]
        public void GetMember_傳入人員代碼1＿應該要回傳代碼為1的人員資料()
        {
            var memberId = 1;
            var act = new MemberService(_repository).GetById(memberId);

            Assert.AreEqual(1, act.MemberId);
        }

        [Test]
        public void GetMember_傳入人員代碼2_應該找不到該人員()
        {
            var memberId = 3;
            var act = new MemberService(_repository).GetById(memberId);

            Assert.IsNull(act);
        }

        [Test]
        public void SaveMember_儲存人員資訊_姓名_性別_電話為必填資訊_傳入完整資訊_應該會得到true()
        {
            var member = new Member
            {
                Name = "Test",
                Sex = Sex.男,
                Telephone = "09xxxxx"
            };

            var act = new MemberService(_repository).Save(member, false);

            Assert.AreEqual(true, act);
        }

        [Test]
        public void SaveMember_儲存人員資訊_姓名_性別_電話為必填資訊_傳入缺少姓名資訊_應該會得到false()
        {
            var member = new Member
            {
                Name = "",
                Sex = Sex.男,
                Telephone = "09xxxxx"
            };

            var act = new MemberService(_repository).Save(member, false);

            Assert.AreEqual(false, act);
        }

        [Test]
        public void SaveMember_儲存人員資訊_姓名_性別_電話為必填資訊_傳入缺少性別資訊_應該會得到false()
        {
            var member = new Member
            {
                Name = "Test",
                Sex = 0,
                Telephone = "09xxxxx"
            };

            var act = new MemberService(_repository).Save(member, false);

            Assert.AreEqual(false, act);
        }

        [Test]
        public void SaveMember_儲存人員資訊_姓名_性別_電話為必填資訊_傳入缺少電話資訊_應該會得到false()
        {
            var member = new Member
            {
                Name = "Test",
                Sex = Sex.男,
                Telephone = ""
            };

            var act = new MemberService(_repository).Save(member, false);

            Assert.AreEqual(false, act);
        }

        [Test]
        public void DeleteMember_刪除人員資訊_傳入存在人員代碼1_應該會得到true()
        {
            var memberId = 1;

            var act = new MemberService(_repository).Delete(memberId);

            Assert.AreEqual(true, act);
        }

        [Test]
        public void DeleteMember_刪除人員資訊_傳入不存在人員代碼2_應該會得到false()
        {
            var memberId = 2;

            var act = new MemberService(_repository).Delete(memberId);

            Assert.AreEqual(false, act);
        }
    }
}