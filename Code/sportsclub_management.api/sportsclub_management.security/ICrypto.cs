using System;
using System.Collections.Generic;
using System.Text;

namespace sportsclub_management.security
{
	public interface ICrypto : IDisposable
    {
        string Encrypt(string TextToEncrypt);

        string Decrypt(string TextToDecrypt);

        string EncryptPassword(string TextToEncrypt);

        string DecryptPassword(string TextToDecrypt);
    }
}
