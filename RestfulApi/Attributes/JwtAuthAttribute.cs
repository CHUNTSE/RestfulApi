using Jose;
using Microsoft.AspNetCore.Mvc.Filters;
using Repository.Models;
using Repository.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Attributes
{
    public class JwtAuthAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string jwtKey = AppSettings.Keys.JwtKey;

            if (!string.IsNullOrEmpty(context.HttpContext.Request.Headers["Authorization"].ToString()) && context.HttpContext.Request.Headers["Authorization"].ToString().Contains("Bearer"))
            {
                try
                {
                    var jwtObject = Jose.JWT.Decode<JwtAuthPayloadViewModel>(
                           context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", string.Empty),
                           Encoding.UTF8.GetBytes(jwtKey),
                           JwsAlgorithm.HS256);
                }
                catch
                {
                    context.HttpContext.Response.StatusCode = 401;
                    throw new Exception();
                }
            }
        }
    }
}
