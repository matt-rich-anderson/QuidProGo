using Microsoft.Data.SqlClient;
using QuidProGo.Models;
using System.Collections.Generic;

namespace QuidProGo.Repositories
{
    public interface ICategoryRepository
    {
        SqlConnection Connection { get; }

        List<Category> GetAllCategorys();
    }
}