using System.Collections.Generic;
using System.Threading.Tasks;
using Honeywords.API.Models;
namespace Honeywords.API.Data
{
    public interface IGradSeniorSurveyRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;

        Task<GradSeniorSurvey> GetGradSeniorSurvey(int Id);
        Task<IEnumerable<GradSeniorSurvey>> GetGradSeniorSurveys();
        Task<bool> SaveAll();
    }
}