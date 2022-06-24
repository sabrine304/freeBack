using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crudProjectWebApi.Models
{
    public class RegisterInspector
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string BirthDate { get; set; }
        public string BirthDateCountry { get; set; }
        public string FamilyStatus { get; set; }
        public short ChildrenNumber { get; set; }
        public string WorkPartner { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        public int SchoolId { get; set; }
        public string HiringDate { get; set; }
        public int RankId { get; set; }
        public string UpgradeDate { get; set; }
        public string ScientificCrtificate { get; set; }
        public string Specialization { get; set; }
        public string AssignmentDate { get; set; }
        public string DemarcationDate { get; set; }
        public bool NewTeacher { get; set; }
        public bool NewTeacherScience { get; set; }
        //Summary of control 
        public bool InspectorStatus { get; set; }
        public string ControlDate { get; set; }
        public int Number { get; set; }
        public string Language { get; set; }
        public string School { get; set; }
        public string Circle { get; set; }
        public string InspectorName { get; set; }
        public string Comment { get; set; }
        public string Password { get; set; }
        public string RoleCode { get; set; }
        public int UserId { get; set; }
        public string ValidationStatus { get; set; }
        public string IdentificationCode { get; set; }
        public string CommentStatus { get; set; }


    }
}
