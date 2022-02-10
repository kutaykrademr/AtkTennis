using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class MemberList
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string NickName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string UserName { get; set; }
        public string StartDate { get; set; }
        public string FinishDate { get; set; }
        public string Role { get; set; }
        public string Condition { get; set; }
        public string IdentityNumber { get; set; }
        public string WebReservation { get; set; }
        public string Phone { get; set; }
        public string PhoneExp { get; set; }
        public string Phone2 { get; set; }
        public string Phone2Exp { get; set; }
        public string Email { get; set; }
        public string EmailExp { get; set; }
        public string BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Job { get; set; }
        public string Note { get; set; }
        public string Password { get; set; }
        public int Price { get; set; }
        public bool PrivRes { get; set; }
        public int MemberNumber { get; set; }
        public string DetailAddress { get; set; }
        public string ReferenceMember1 { get; set; }
        public string ReferenceMember2 { get; set; }
        public string CompanyId { get; set; }
        public bool whoPartner { get; set; }
        public int memberType { get; set; }
        public string RoleId { get; set; }
        public int SeenPrivacy { get; set; }


        public bool isPartner { get; set; }
        public string PartnerId { get; set; }
       


        public bool ActPas { get; set; }


    }
}



