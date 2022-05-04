using Microsoft.Data.SqlClient;
using QuidProGo.Models;
using System.Collections.Generic;

namespace QuidProGo.Repositories
{
    public interface ICategoryRepository
    {
        SqlConnection Connection { get; }

        List<Category> GetAllCategories();
        void AddConsultationCatagory(int consultationId, int categoryId);
        List<Category> GetCategByConsultId(int id);
        void DeleteCC(int id);
        List<int> GetCCIdsByConsultId(int id);
    }
}