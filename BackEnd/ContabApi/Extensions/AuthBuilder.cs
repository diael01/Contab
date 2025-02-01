using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ContabApi.Extensions
{
    public static class AuthBuilder
    {
        public static void AddAuthInfrastructure(this WebApplicationBuilder builder)
        {

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.Authority = "https://localhost:5001";
                //o.Audience = "ContabApi";//it is not a OAuth2 standard, it belongs to microsoft, 
                //the alternative is an authorization policy coz is essential to check if a
                //received token is meant for THIS API, coz otherwise the API will accept any token
                //coming from a trusted authority
                o.TokenValidationParameters.ValidateAudience = false;
                o.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
            });


            //todo: later when i add the UI
            //builder.Services.AddBff(o => o.ManagementBasePath = "/account").AddServerSideSessions();

            //builder.Services.AddAuthentication(o =>
            //{
            //    o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    o.DefaultChallengeScheme = "oidc";
            //    o.DefaultSignOutScheme = "oidc";
            //})
            //    .AddCookie(o =>
            //    {
            //        o.Cookie.Name = "__Host-spa";
            //        o.Cookie.SameSite = SameSiteMode.Strict;

            //        o.Events.OnRedirectToLogin = (context) =>
            //  {
            //      context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //      return Task.CompletedTask;
            //  };
            //    })
            //    .AddOpenIdConnect("oidc", options =>
            //    {
            //        //this is Identity Provider port
            //        options.Authority = "https://localhost:5001";

            //        // confidential ClientDTO using code flow + PKCE + query response mode
            //        options.ClientId = "ContabApi";
            //        options.ClientSecret = "secret"; // Secret("secret".Sha256());  
            //        options.ResponseType = "code";
            //        options.ResponseMode = "query";
            //        options.UsePkce = true;

            //        options.MapInboundClaims = false;
            //        options.GetClaimsFromUserInfoEndpoint = true;

            //        // save access and refresh token to enable automatic lifetime management
            //        options.SaveTokens = true;

            //        // request scopes
            //        options.Scope.Add("ContabApi.basicAccess");
            //        options.Scope.Add("roles");

            //        // request refresh token
            //        options.Scope.Add("offline_access");
            //    });
            builder.Services.AddAuthorization(o =>
                o.AddPolicy("admin", p => p.RequireClaim("role", "admin"))
            );

        }
    }
}
