using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AdminEquipoApi
{
    public class BasePathDocumentFilter : IDocumentFilter
    {
        private readonly string _basePath;

        public BasePathDocumentFilter(string basePath)
        {
            _basePath = basePath;
        }

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Servers.Clear();
            swaggerDoc.Servers.Add(new OpenApiServer { Url = _basePath });
        }
    }

}
