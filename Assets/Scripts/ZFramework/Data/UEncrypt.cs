using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConfigData
{
    public class UEncrypt
    {
        static UEncrypt _instance;
        public static UEncrypt Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UEncrypt();
                return _instance;
            }
        }

        public UEncrypt()
        {
            CreateRijndaelManaged();
        }

        public ICryptoTransform encoder;
        public ICryptoTransform decoder;
        private void CreateRijndaelManaged()
        {
            RijndaelManaged _aes = new RijndaelManaged();
            _aes.Mode = CipherMode.ECB;
            _aes.Padding = PaddingMode.Zeros;
            _aes.BlockSize = 128;
            string temp = "Your Encode Key";
            _aes.Key = Convert.FromBase64String(temp);
            encoder = _aes.CreateEncryptor();
            decoder = _aes.CreateDecryptor();
        }

    }
}
