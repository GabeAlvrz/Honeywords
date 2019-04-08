using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Honeywords.API.Data;
using Honeywords.API.Dtos;
using Honeywords.API.Models;

namespace Honeywords.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExitSurveysController : ControllerBase
    {
        private readonly IExitSurveyRepository _eSurveyRepo;
        private readonly IMapper _mapper;

        //public ExitSurveysController(IExitSurveyRepository exitSurveyRepo, IMapper mapper)
        public ExitSurveysController(IExitSurveyRepository eSurveyRepo ,IMapper mapper)
        {
            _eSurveyRepo = eSurveyRepo;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]

        public async Task<IActionResult> UpdateExitSurvey([FromBody] dynamic surveyContent)
        {
            ExitSurvey eSurvey = new ExitSurvey();
            dynamic assessQ    = null;
            foreach (JProperty fld in surveyContent)
            {
                switch(fld.Name.ToLower()){
                    case "surveydate":
                      eSurvey.surveyDate = (DateTime)fld.Value;
                      break;
                    case "studentname":
                      eSurvey.studentName = (string)fld.Value;
                      break;
                    case "ssid":
                      eSurvey.ssId = (string)fld.Value;
                      break;
                    case "degreeprogram":
                      eSurvey.degreeProgram= (string)fld.Value;
                      break;
                    case "termgraduatesemester":
                      eSurvey.termGraDuateSemester = (string)fld.Value;
                      break;
                    case "termgraduateyear":
                      eSurvey.termGraDuateYear = (string)fld.Value;
                      break;
                    case "contact1name":
                      eSurvey.contact1Name = (string)fld.Value;
                      break;
                    case "contact1phonehome":
                      eSurvey.contact1PhoneHome= (string)fld.Value;
                      break;
                    case "contact1phonework":
                      eSurvey.contact1PhoneWork= (string)fld.Value;
                      break;
                    case "contact1phonecell":
                      eSurvey.contact1PhoneCell= (string)fld.Value;
                      break;
                    case "contact1address":
                      eSurvey.contact1Address= (string)fld.Value;
                      break;   
                    case "contact1email":
                      eSurvey.contact1Email= (string)fld.Value;
                      break;  
                    case "contactotheroption":
                      eSurvey.contactOtherOption= (string)fld.Value;
                      break;
                    case "contact2name":
                      eSurvey.contact2Name= (string)fld.Value;
                      break;    
                    case "contact2phonehome":
                      eSurvey.contact2PhoneHome= (string)fld.Value;
                      break; 
                    case "contact2phonework":
                      eSurvey.contact2PhoneWork= (string)fld.Value;
                      break;        
                    case "contact2phonecell":
                      eSurvey.contact2PhoneCell= (string)fld.Value;
                      break;  
                    case "contact2address":
                      eSurvey.contact2Address= (string)fld.Value;
                      break;   
                    case "contact2email":
                      eSurvey.contact2Email= (string)fld.Value;
                      break;                                                                                                                                        
                    case "assessq":
                      assessQ = fld.Value;
                      break;
                    case "assessq1":
                      eSurvey.assessQ1 = (string)fld.Value;
                      break;
                    case "assessq2":
                      eSurvey.assessQ2 = (string)fld.Value;
                      break;
                    case "assessq3":
                      eSurvey.assessQ3 = (string)fld.Value;
                      break;
                    case "assesscomment":
                      eSurvey.assessComment= (string)fld.Value;
                      break; 
                    case "furtherstudyschool":
                      eSurvey.furtherStudySchool= (string)fld.Value;
                      break;
                    case "furtherstudymajor":
                      eSurvey.furtherStudyMajor= (string)fld.Value;
                      break;  
                    case "furtherstudyscholarship":
                      eSurvey.furtherStudyScholarship= (string)fld.Value;
                      break;    
                    case "jobsearchduration":
                      eSurvey.jobSearchDuration= (string)fld.Value;
                      break;
                    case "jobsearchnuminterview":
                      eSurvey.jobSearchNumInterview= (string)fld.Value;
                      break; 
                    case "jobsearchnumoffer":
                      eSurvey.jobSearchNumOffer= (string)fld.Value;
                      break; 
                    case "jobsearchavgsalary":
                      eSurvey.jobSearchAvgSalary= (string)fld.Value;
                      break;     
                    case "jobcompany":
                      eSurvey.jobCompany= (string)fld.Value;
                      break; 
                    case "jobcity":
                      eSurvey.jobCity= (string)fld.Value;
                      break;
                    case "jobtitle":
                      eSurvey.jobTitle= (string)fld.Value;
                      break;      
                    case "jobcompanycontact":
                      eSurvey.jobCompanyContact= (string)fld.Value;
                      break;   
                    case "jobcompanyweb":
                      eSurvey.jobCompanyWeb= (string)fld.Value;
                      break;
                    case "jobsalary":
                      eSurvey.jobSalary= (string)fld.Value;
                      break;       
                    case "networkingq1":
                      eSurvey.networkingQ1= (string)fld.Value;
                      break; 
                    case "networkingq2":
                      eSurvey.networkingQ2= (string)fld.Value;
                      break;                                                                                                                                                                                                                                                                                                                                                                                                                                                    
                    default:
                      break;
                }
            }
            if (assessQ != null) {
                foreach (JProperty Ques in assessQ) {
                    switch (Ques.Name.ToLower()){
                        case "assessq1":
                          eSurvey.assessQ1 = (string)Ques.Value;
                          break;
                        case "assessq2":
                          eSurvey.assessQ2 = (string)Ques.Value;
                          break;
                        case "assessq3":
                          eSurvey.assessQ3 = (string)Ques.Value;
                          break;
                        default:
                          break;
                    }
                }
            }
            Console.WriteLine("survey date: " + eSurvey.surveyDate);
            Console.WriteLine("student name: " + eSurvey.studentName);
            Console.WriteLine("assessQ1: " + eSurvey.assessQ1);
            _eSurveyRepo.Add(eSurvey);
            if ( await _eSurveyRepo.SaveAll()) {
                return NoContent();
            } else {
                return BadRequest("Update ExitSurvey Failed");
            }
            //return null;
        }

        [AllowAnonymous]
        [HttpGet("GetExitSurveys")]
        public async Task<IActionResult> GetExitSurveys()
        {
            var eSurveys = await _eSurveyRepo.GetExitSurveys();
            return Ok(eSurveys);
        }

        [AllowAnonymous]
        [HttpGet("GetExitSurvey/{Id}")]
        public async Task<IActionResult> GetExitSurvey(int Id)
        {
            var eSurvey = await _eSurveyRepo.GetExitSurvey(Id);
            return Ok(eSurvey);
        }

    }    
}