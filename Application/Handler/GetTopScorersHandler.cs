using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GetTopScorersHandler
    {
        private readonly IStudentScoreService _studentScoreService;

        public GetTopScorersHandler(IStudentScoreService studentScoreService)
        {
            _studentScoreService = studentScoreService;
        }

        public IEnumerable<string> GetTopScorers(int topScorers)
        {
            var studentScores = _studentScoreService.GetStudentScores();
            var topScorersList = studentScores.OrderByDescending(x => x.Score).Take(topScorers).OrderBy(ps => ps.FirstName).ThenBy(ps => ps.SecondName); ;
           
            //returning the top scorers with firstname, secondname and score
            return topScorersList.Select(x => $"{x.FirstName} {x.SecondName}, {x.Score}");
        }
    }
}
