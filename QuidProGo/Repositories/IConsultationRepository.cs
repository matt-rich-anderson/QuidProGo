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
        List<Consultation> GetConsultationsByClientId(int clientId);
        List<Consultation> GetConsultationsByAttorneyId(int attorneyId);
        void AddConsultation(Consultation consultation);
        void DeleteConsultation(int id);
        void UpdateConsutation(Consultation consultation);
    }
}