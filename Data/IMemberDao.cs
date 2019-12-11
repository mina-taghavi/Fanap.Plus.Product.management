
using System.Collections.Generic;
using Fanap.Plus.Product_Management.Models;

namespace Fanap.Plus.Product_Management.Data
{
    public interface IMemberDao
    {

        List<Members> Find(int productId);
    }
}
