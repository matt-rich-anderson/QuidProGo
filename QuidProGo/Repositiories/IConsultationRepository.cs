using Microsoft.Data.SqlClient;
using QuidProGo.Models;
using System.Collections.Generic;

namespace QuidProGo.Repositories
{
    public interface IConsultationRepository
    {
        SqlConnection Connection { get; }

        List<Consultation> GetAllConsultations();
        Consultation GetConsultationById(int id);
    }
}