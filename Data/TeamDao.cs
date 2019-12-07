using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Fanap.Plus.Product_Management.Models
{
    public class TeamDao : ITeamDao
    {
        public DataContext DataContext { get; set; }
        public TeamDao(DataContext dataContext)
        {
            DataContext = dataContext;
        }
        public List<Teams> Find(int productId)
        {
            //var query =
            //    from team in DataContext.Teams
            //    join ta in DataContext.TeamAssignments on team.Id equals ta.Team.Id
            //    where ta.Product.Id == productId
            //    select new {Team = team};
            //return query.ToList().Select(t=> t.Team).ToList();
            //var result = DataContext.TeamAssignment.Where(ta=>ta.ProductId == productId).ToList();
            //return null;
            var result = DataContext.Teams
                .Join(
                    DataContext.TeamAssignment.Where(ta=> ta.ProductId == productId),
                    team => team.Id,
                    assignment => assignment.TeamId,
                    (team, assignment) =>  team 
                ).ToList();
            return result;
        }
    }
}