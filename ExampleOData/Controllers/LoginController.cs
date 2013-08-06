using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Security;

namespace ExampleOData.Controllers
{
    public class LoginController : ApiController
    {
        public HttpResponseMessage Get(int idUtente, string ruolo)
        {
            var authCookie = FormsAuthentication.GetAuthCookie(string.Format("{0}:{1}", idUtente, ruolo), true);
            var cookie = new CookieHeaderValue("WebCare", authCookie.Value);
            cookie.Domain = Request.RequestUri.Host;
            cookie.Expires = authCookie.Expires;
            cookie.HttpOnly = authCookie.HttpOnly;
            cookie.Path = authCookie.Path;
            cookie.Secure = authCookie.Secure;

            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Headers.AddCookies(new CookieHeaderValue[] { cookie });

            return httpResponseMessage;
        }

        public HttpResponseMessage Delete()
        {
            FormsAuthentication.SignOut();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}