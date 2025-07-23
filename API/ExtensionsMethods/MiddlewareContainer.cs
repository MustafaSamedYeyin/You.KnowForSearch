namespace API.ExtensionsMethods;

public static class MiddlewareContainer
{
    public static IApplicationBuilder UseSwaggerExtension(this IApplicationBuilder builder, bool isDevelopement)
    {
        if (isDevelopement)
        {
            builder.UseSwagger(options =>
            {
                options.RouteTemplate = "openapi/{documentName}.json";
            });

            builder.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/openapi/v1.json", "My API V1");
            });
        }
        return builder;
    }

    public static IApplicationBuilder UseCORSExtension(this IApplicationBuilder builder, bool isDevelopement)
    {
        if (isDevelopement)
        {
            builder.UseCors("AllowDevOrigin");
        }
        else
        {
            builder.UseCors("AllowSpecificOrigin");
        }
        return builder;
    }
}