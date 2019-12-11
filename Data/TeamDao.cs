using System.Collections.Generic;
using System.Linq;
using Fanap.Plus.Product_Management.Models;

namespace Fanap.Plus.Product_Management.Data
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