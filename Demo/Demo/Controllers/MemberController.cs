using System;
using System.Web.Http;
using Demo.Domain.Entity;
using Demo.DTO;
using Demo.Models;
using Demo.Service;

namespace Demo.Controllers
{
    public class MemberController : ApiController
    {
        private readonly MemberService _service;

        public MemberController(MemberService service)
        {
            _service = service;
        }

        public APIResult Get()
        {
            try
            {
                var members = _service.GetAll();
                
                return new APIResult()
                {
                    IsSuccess = true,
                    Payload = members
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new APIResult()
                {
                    IsSuccess = false,
                    Message = "讀取失敗"
                };
            }
        }

        public APIResult Get(int id)
        {
            try
            {
                var member = _service.GetById(id);

                return new APIResult()
                {
                    IsSuccess = true,
                    Payload = new MemberViewModel
                    {
                        Id = member.MemberId,
                        Name = member.Name,
                        Sex = member.Sex,
                        Telephone = member.Telephone,
                        Address = member.Address
                    }
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new APIResult()
                {
                    IsSuccess = false,
                    Message = "讀取失敗"
                };
            }
        }

        public APIResult Post([FromBody] MemberViewModel value)
        {
            try
            {
                var member = new Member
                {
                    Name = value.Name,
                    Sex = value.Sex,
                    Telephone = value.Telephone,
                    Address = value.Address
                };

                var result = _service.Save(member, false);

                return new APIResult()
                {
                    IsSuccess = result
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new APIResult()
                {
                    IsSuccess = false,
                    Message = "新增執行錯誤"
                };
            }
        }

        public APIResult Put([FromBody] MemberViewModel value)
        {
            try
            {
                var member = new Member
                {
                    MemberId = value.Id,
                    Name = value.Name,
                    Sex = value.Sex,
                    Telephone = value.Telephone,
                    Address = value.Address
                };

                var result = _service.Save(member, true);

                return new APIResult()
                {
                    IsSuccess = result
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new APIResult()
                {
                    IsSuccess = false,
                    Message = "更新執行錯誤"
                };
            }
        }

        public APIResult Delete(int id)
        {
            try
            {
                var result = _service.Delete(id);

                return new APIResult()
                {
                    IsSuccess = result,
                };
            }
            catch (Exception e)
            { 
                Console.WriteLine(e);
                return new APIResult()
                {
                    IsSuccess = false,
                    Message = "刪除執行錯誤"
                };
            }
        }
    }
}