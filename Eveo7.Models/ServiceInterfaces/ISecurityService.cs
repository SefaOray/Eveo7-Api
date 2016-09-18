

namespace Eveo7.Models.ServiceInterfaces
{
    public interface ISecurityService
    {
        byte[] Encrypt(byte[] plainText, byte[] salt);
        byte[] CreateSalt(int size);
        bool CompareByteArrays(byte[] array1, byte[] array2);
    }
}
