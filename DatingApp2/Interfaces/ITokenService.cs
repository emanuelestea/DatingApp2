using DatingApp2.Models;

namespace DatingApp2.Interfaces
{
    //l'interfaccia non è prettamente necessaria potremmo creare direttamente il serivzio
    //lo facciamo per il testing, è facile mock un interfaccia
    //best practice
    public interface ITokenService
    {
        string CreateToken(AppUser user);

    }
}
