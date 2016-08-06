

namespace Eveo7.Models.ServiceInterfaces
{
    public interface ISecurityService
    {
        string Encrypt(string plainText, string passPhrase);
        string Decrypt(string cipherText, string passPhrase);
        string GenerateSalt();
    }
}
