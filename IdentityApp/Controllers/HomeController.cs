using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityApp.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class HomeController : Controller
    {
        IdContext db = new IdContext();

        [HttpGet("AddMember", Name = "AddMember")]
        public MemberList AddMember(string detailAddress, string name, string username, string startDate, string finishDate, string condition,
            string identificationNumber, string webReservation, string phoneExp, string phone2, string phone2Exp, string email,
            string emailExp, string birthPlace, string motherName, string fatherName, string city, string district, string job,
            string note, string phone, string password, string birthdate, string gender, string role, string nickName,
            int memberNumber, string partnerBirthdate, string partnerIdNumber, string partnerPhone, string partnerName,
            bool isPartner, string refmem1, string refmem2, string nickName2, string username2, string startDate2,
            string finishDate2, string memberNumber2, string password2, string MyIp, string user2Id, string userId)
        {


            MemberList model3 = new MemberList();
            MemberList model2 = new MemberList();

            if (isPartner)
            {



                model3.UserId = user2Id;
                model3.IdentityNumber = partnerIdNumber;
                model3.NickName = nickName2;
                model3.UserName = username2;
                model3.FullName = partnerName;
                model3.StartDate = startDate2;
                model3.FinishDate = finishDate2;
                model3.Phone = partnerPhone;
                model3.PhoneExp = "Kendi";
                model3.BirthDate = partnerBirthdate;
                model3.Role = role;
                model3.MemberNumber = Convert.ToInt32(memberNumber2);
                model3.WebReservation = webReservation;
                model3.Password = password2;
                model3.isPartner = false;
                model3.PartnerId = userId;


                db.Add(model3);
                db.SaveChanges();


            }

            var id = userId;


            if (isPartner)
            {
                model2.isPartner = isPartner;
                model2.PartnerId = user2Id;
            }

            model2.DetailAddress = detailAddress;
            model2.ReferenceMember1 = refmem1;
            model2.ReferenceMember2 = refmem2;
            model2.MemberNumber = memberNumber;
            model2.UserId = id;
            model2.FullName = name;
            model2.NickName = nickName;
            model2.Gender = gender;
            model2.UserName = username;
            model2.StartDate = startDate;
            model2.FinishDate = finishDate;
            model2.Role = role;
            model2.Condition = condition;
            model2.IdentityNumber = identificationNumber;
            model2.WebReservation = webReservation;
            model2.Phone = phone;
            model2.PhoneExp = phoneExp;
            model2.Phone2 = phone2;
            model2.Phone2Exp = phone2Exp;
            model2.Email = email;
            model2.EmailExp = emailExp;
            model2.BirthDate = birthdate;
            model2.BirthPlace = birthPlace;
            model2.MotherName = motherName;
            model2.FatherName = fatherName;
            model2.City = city;
            model2.District = district;
            model2.Job = job;
            model2.Note = note;
            model2.Password = password;
            model2.CompIp = MyIp;



            db.Add(model2);
            db.SaveChanges();


            return model2;
        }

        [HttpGet("GetAllUsers", Name = "GetAllUsers")]
        public List<MemberList> GetAllUsers()
        {
            List<MemberList> mem = new List<MemberList>();

            mem = db.memberLİst.ToList();

            return mem;
        }
    }
}
