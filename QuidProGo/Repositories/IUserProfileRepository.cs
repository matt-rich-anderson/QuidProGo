using Microsoft.Data.SqlClient;
using QuidProGo.Models;
using System.Collections.Generic;

namespace QuidProGo.Repositories
{
    public interface IUserProfileRepository
    {
        SqlConnection Connection { get; }

        void Add(UserProfile userProfile);
        UserProfile GetByFirebaseUserId(string firebaseUserId);
        UserProfile GetById(int id);
        List<UserProfile> GetUserProfileByUserTypeId(int userTypeId);
        UserProfile GetAttorByConsultId(int id);
    }
}