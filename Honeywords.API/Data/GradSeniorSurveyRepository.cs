using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Honeywords.API.Models;
namespace Honeywords.API.Data
{
    public class GradSeniorSurveyRepository : IGradSeniorSurveyRepository
    {
        private readonly DataContext _context;
        public GradSeniorSurveyRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<GradSeniorSurvey> GetGradSeniorSurvey(int Id) 
        {
            var eSurvey = await _context.GradSeniorSurveys.FirstOrDefaultAsync(n => n.Id == Id);

            return eSurvey;
        }

        public async Task<IEnumerable<GradSeniorSurvey>> GetGradSeniorSurveys()
        {
          return await _context.GradSeniorSurveys.ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}