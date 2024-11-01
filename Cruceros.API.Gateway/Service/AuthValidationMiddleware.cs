using Cruceros.API.Gateway.Client;

namespace Cruceros.API.Gateway.Service;

public class AuthValidationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IAutenticationClient autenticationClient)
    {
        var token = context.Request.Headers.Authorization;
        token = token.ToString().Substring("Bearer ".Length).Trim();
        await autenticationClient.VerifySession(token);

        // Call the next delegate/middleware in the pipeline.
       await _next(context);
    }
}

public static class AuthValidationMiddlewareExtensions
{
    public static IApplicationBuilder UseAuthValidation(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AuthValidationMiddleware>();
    }
}