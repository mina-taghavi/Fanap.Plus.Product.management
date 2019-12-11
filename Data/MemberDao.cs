using System.Collections.Generic;
using System.Linq;
using Fanap.Plus.Product_Management.Models;

namespace Fanap.Plus.Product_Management.Data
{
    public class MemberDao : IMemberDao
    {
        public DataContext DataContext { get; set; }
        public MemberDao(DataContext dataContext)
        {
            DataContext = dataContext;
        }
        public List<Members> Find(int productId)
        {

            var result = DataContext.Members
                .Where(Members => Members.ProductId == productId).ToList();
            return result;
        }
    }
}
