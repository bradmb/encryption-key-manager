using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace EncryptionKeyManager.Controllers
{
    [Route("api/[controller]")]
    public class KeyController : Controller
    {
        private readonly string KEY = Environment.GetEnvironmentVariable("APP_ENCRYPTION_KEY");
        private readonly string[] ALLOWED_HOST = Environment.GetEnvironmentVariable("APP_ALLOWED_HOSTS").Split(";");
        private readonly string ALLOWED_HOST_STR = Environment.GetEnvironmentVariable("APP_ALLOWED_HOSTS");

        /// <summary>
        /// Returns the encryption key
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Get()
        {
            var ipAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            if (ALLOWED_HOST.Contains(ipAddress) || ALLOWED_HOST.Contains("*"))
            {
                return KEY;
            }

            return null;
        }
    }
}
