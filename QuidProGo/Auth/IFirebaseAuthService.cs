using System.Threading.Tasks;
using QuidProGo.Auth.Models;

namespace QuidProGo.Auth
{
    public interface IFirebaseAuthService
    {
        Task<FirebaseUser> Login(Credentials credentials);
        Task<FirebaseUser> Register(Registration registration);
    }
}
