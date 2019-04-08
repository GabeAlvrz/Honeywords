using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Honeywords.API.Models;

namespace Honeywords.API.Data
{
    public interface IHoneywordRepository
    {
        void GenerateHoneyWords(DataContext context, User user, int count, string password);
    }
}