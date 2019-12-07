using System.Collections.Generic;

namespace Fanap.Plus.Product_Management.Models
{
    public interface ITeamDao
    {
        List<Teams> Find(int productId);

    }
}