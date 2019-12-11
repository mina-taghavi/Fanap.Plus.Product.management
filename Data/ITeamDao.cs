using System.Collections.Generic;
using Fanap.Plus.Product_Management.Models;

namespace Fanap.Plus.Product_Management.Data
{
    public interface ITeamDao
    {
        List<Teams> Find(int productId);

    }
}