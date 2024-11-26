using Jose;
using Newtonsoft.Json;
using System.Text;

namespace TicketManagementUI.Security
{
    public class EncryptionHelper<T>(IConfiguration configuration) where T : class
    {
        byte[] secretKey = Encoding.UTF8.GetBytes(configuration["JWEKey"] ?? "");
        private readonly IConfiguration configuration = configuration;

        public string Encode(object obj)
        {
            return JWT.Encode(obj, secretKey, JweAlgorithm.A256KW, JweEncryption.A256CBC_HS512);
        }
        public T Decode(string token)
        {
            var result = JWT.Decode(token, secretKey, JweAlgorithm.A256KW, JweEncryption.A256CBC_HS512);
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
