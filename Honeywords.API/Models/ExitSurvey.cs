using System;

namespace Honeywords.API.Models
{
    public class ExitSurvey
    {
        public int Id { get; set;}
        public DateTime surveyDate { get; set; }
        public string studentName { get; set; }
        public string ssId { get; set; }
        public string degreeProgram { get; set; }
        public string termGraDuateSemester { get; set; }
        public string termGraDuateYear { get; set; }
        public string contact1Name { get; set; }
        public string contact1PhoneHome { get; set; }
        public string contact1PhoneWork { get; set; }
        public string contact1PhoneCell { get; set; }
        public string contact1Address { get; set; }
        public string contact1Email { get; set; }
        public string contactOtherOption { get; set; }
        public string contact2Name { get; set; }
        public string contact2PhoneHome { get; set; }
        public string contact2PhoneWork { get; set; }
        public string contact2PhoneCell { get; set; }
        public string contact2Address { get; set; }
        public string contact2Email { get; set; }
        public string assessQ1 { get; set; }
        public string assessQ2 { get; set; }
        public string assessQ3 { get; set; }
        public string assessComment { get; set; }
        public string furtherStudySchool { get; set; }
        public string furtherStudyMajor { get; set; }
        public string furtherStudyScholarship { get; set; }
        public string jobSearchDuration { get; set; }
        public string jobSearchNumInterview { get; set; }
        public string jobSearchNumOffer { get; set; }
        public string jobSearchAvgSalary { get; set; }
        public string jobCompany { get; set; }
        public string jobCity { get; set; }
        public string jobTitle { get; set; }
        public string jobCompanyContact { get; set; }
        public string jobCompanyWeb { get; set; }
        public string jobSalary { get; set; }
        public string networkingQ1 { get; set; }
        public string networkingQ2 { get; set; }
    }
}