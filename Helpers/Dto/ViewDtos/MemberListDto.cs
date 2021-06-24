using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.ViewDtos
{
    public class MemberListDto
    {
        
        public int Id { get; set; }
        public string UserId { get; set; }
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
    }
}
