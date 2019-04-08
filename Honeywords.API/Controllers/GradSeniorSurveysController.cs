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
    public class GradSeniorSurveysController : ControllerBase
    {
        private readonly IGradSeniorSurveyRepository _eSurveyRepo;
        private readonly IMapper _mapper;

        public GradSeniorSurveysController(IGradSeniorSurveyRepository eSurveyRepo ,IMapper mapper)
        {
            _eSurveyRepo = eSurveyRepo;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> UpdateGradSeniorSurvey([FromBody] GradSeniorSurvey surveyContent)
        {
           _eSurveyRepo.Add(surveyContent);
            if ( await _eSurveyRepo.SaveAll()) {
                return NoContent();
            } else {
                return BadRequest("Update Grad Senior Survey Failed");
            }
        }

        [AllowAnonymous]
        [HttpGet("GetGradSeniorSurveys")]
        public async Task<IActionResult> GetGradSeniorSurveys()
        {
            var eSurveys = await _eSurveyRepo.GetGradSeniorSurveys();
            return Ok(eSurveys);
        }

        [AllowAnonymous]
        [HttpGet("GetGradSeniorSurvey/{Id}")]
        public async Task<IActionResult> GetGradSeniorSurvey(int Id)
        {
            var eSurvey = await _eSurveyRepo.GetGradSeniorSurvey(Id);
            return Ok(eSurvey);
        }
    }
}