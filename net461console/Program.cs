using System;
using System.Security.Cryptography;

namespace netcore
{
    class Program
    {
        public static byte[] Base64UrlDecodeBytes(string str)
        {
            str = str.Replace('-', '+');
            str = str.Replace('_', '/');

            switch (str.Length % 4)
            {
                case 0:
                    break;
                case 2:
                    str += "==";
                    break;
                case 3:
                    str += "=";
                    break;
            }

            return Convert.FromBase64String(str);
        }

        static void Main(string[] args)
        {
            var e = Base64UrlDecodeBytes("AQAB");
            var n = Base64UrlDecodeBytes("AJSn-hXW9Zzz9ORBKIC9Oi6wzM4zhqwHaKW2vZAqjOeLlpUW7zXwyk4tkivwsydPNaWUm-9oDlEAB2lsQJv7jwWNsF7SGx5R03kenC-cf8Nbxlxwa-Tncjo6uruEsK_Vke244KiSCHP8BOuHI-r5CS0x9edFLgesoYlPPFoJxTs5");
            var data = System.Convert.FromBase64String("ZXlKNE5YUWlPaUpPYlVwdFQwZFZlRTE2V214WmFrMHlXa1JTYUU1VVdteFpWRUV4V1hwa2FGcFVVbWxQVjBVd1RsZEpNazB5U20xUFZHTXhXa0VpTENKcmFXUWlPaUprTUdWak5URTBZVE15WWpabU9EaGpNR0ZpWkRFeVlUSTROREEyT1RsaVpHUXpaR1ZpWVRsa0lpd2lZV3huSWpvaVVsTXlOVFlpZlEuZXlKaGRGOW9ZWE5vSWpvaWVtZGhUV3RhTkVONldUY3hhbFJmVVRsQlRYQm5RU0lzSW1GamNpSTZJblZ5YmpwdFlXTmxPbWx1WTI5dGJXOXVPbWxoY0RwemFXeDJaWElpTENKemRXSWlPaUpYVTA4eUxrOVNSMXd2WVdSdGFXNUFZMkZ5WW05dUxuTjFjR1Z5SWl3aVlYVmtJanBiSWpsSWRUUlFNREJKVW5WcFRIazRTM2xpZFhwclpqWnVOR3R0YjJFaVhTd2lZWHB3SWpvaU9VaDFORkF3TUVsU2RXbE1lVGhMZVdKMWVtdG1ObTQwYTIxdllTSXNJbkp2YkdWeklqb2lTVzUwWlhKdVlXeGNMMlYyWlhKNWIyNWxMRmRUVHpJdVQxSkhYQzloWkcxcGJpeEJjSEJzYVdOaGRHbHZibHd2Ykc5allXeG9iM04wVTJWeWRtbGpaU0lzSW1semN5STZJbWgwZEhCek9sd3ZYQzlzYjJOaGJHaHZjM1E2T1RRME0xd3ZiMkYxZEdneVhDOTBiMnRsYmlJc0ltVjRjQ0k2TVRVeE1qVTJNVEU1TlN3aWFXRjBJam94TlRFd09EYzNPRFUxZlE=");
            var signature = System.Convert.FromBase64String("kabTcKZB7a+YaQ4C+8IAeDxAE/Ppr/DhnD42YdqR1fZpMatc+bNSP8rt1dL85KnbzDqkMm39KfNQqZp/5QSR0+EXDIs/gEAJjGW3+lvUF58KQKwMZVtcObueA9+UWUVdJhaB5sbzq8TG6GduftM+/NQMYFB6TcQzvb4IEtrzW0I=");
            var rsa = RSA.Create();
            rsa.ImportParameters(new RSAParameters { Exponent = e, Modulus = n });

            var result = (rsa as RSACryptoServiceProvider).VerifyData(data, "SHA256", signature);
            Console.WriteLine(result);
        }
    }
}
