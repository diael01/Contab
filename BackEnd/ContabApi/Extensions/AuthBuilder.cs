using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace ContabApi.Extensions
{
    public static class AuthBuilder
    {
        public static void AddAuthInfrastructure(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient("authorization", o => o.BaseAddress = new Uri("https://localhost:5001"));

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.Authority = "https://localhost:5001";
                //o.Audience = "ContabApi";//it is not a OAuth2 standard, it belongs to microsoft, 
                //the alternative is an authorization policy coz is essential to check if a
                //received token is meant for THIS API, coz otherwise the API will accept any token
                //coming from a trusted authority
                //o.TokenValidationParameters.ValidateAudience = false;
                o.Audience = "ContabApi";
                o.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    RoleClaimType = JwtClaimTypes.Role,
                    NameClaimType = JwtClaimTypes.Name
                };
            });

            builder.Services.AddAuthorization(o =>
            {
                //employing Microsoft standard
                o.AddPolicy("fullaccess",
                           p => p.RequireClaim(JwtClaimTypes.Scope, "ContabApi_fullaccess"));
                o.AddPolicy("isadmin",
                                   p => p.RequireClaim(JwtClaimTypes.Role, "admin"));
                //or own generic strings
                o.AddPolicy("isemployee",
                               p => p.RequireClaim("employeeno"));
                //builder.Services.AddAuthorization(o => o.AddPolicy("admin", 
                //                                       p => p.RequireClaim("role", "admin"))
                o.FallbackPolicy = new AuthorizationPolicyBuilder()
                        .RequireClaim(JwtClaimTypes.Role, "contributor")
                        .RequireAuthenticatedUser()
                        .Build();

                //API authorization should be based on SCOPES, because for service to service communication
                //there is no user, thus role check cant be done. Scopes can be defined in the IDP buta token
                //containing a scope doesnt verify the scope, IDP does not do authorization, however it determise
                //which client gets which scope. Authorization based on scope gotten from IDP it is done in the API via policies.

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


        }
    }
}
