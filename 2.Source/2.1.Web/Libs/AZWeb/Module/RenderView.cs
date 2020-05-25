using AZWeb.Extensions;
using AZWeb.Module.Buffers;
using AZWeb.Module.Formatters;
using AZWeb.Module.View;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace AZWeb.Module
{
    sealed class RenderView
    {
        const string DefaultContentType = "text/html; charset=utf-8";
        const string extends = ".cshtml";

        HttpContext httpContext;
        IHttpResponseStreamWriterFactory writerFactory;
        ICompositeViewEngine viewEngine;
        ITempDataProvider tempDataProvider;
        ActionContext actionContext;
        IViewBufferScope _bufferScope; 
        IOptions<JsonOptions> options;
        public RenderView(HttpContext _httpContext)
        {
            httpContext = _httpContext;
            writerFactory = httpContext.GetService<IHttpResponseStreamWriterFactory>();
            viewEngine = httpContext.GetService<ICompositeViewEngine>();
            actionContext = new ActionContext(httpContext, httpContext.GetRouteData(), new ActionDescriptor());
            tempDataProvider = httpContext.GetService<ITempDataProvider>();
            _bufferScope = httpContext.GetService<IViewBufferScope>();
            options = httpContext.GetService<IOptions<JsonOptions>>();
        }
       JsonSerializerOptions GetHtmlSafeSerializerOptions(JsonSerializerOptions serializerOptions)
        {
            if (serializerOptions.Encoder is null || serializerOptions.Encoder == JavaScriptEncoder.Default)
            {
                return serializerOptions;
            }
            return serializerOptions.Copy(JavaScriptEncoder.Default);
        }
        ViewEngineResult GetView(HtmlView htmlView) {
            if (htmlView.ViewName.IndexOf("/") < 0)
                return viewEngine.GetView(string.Format("{0}/{1}{2}", htmlView.Path, htmlView.ViewName, extends), string.Format("{0}{1}", htmlView.ViewName, extends), false);
            else {
                var indexLast = htmlView.ViewName.LastIndexOf("/");
                var viewName = htmlView.ViewName.Substring(indexLast+1);
                var pathNew = htmlView.Path;
                if (!htmlView.ViewName.StartsWith("/")) {
                    pathNew += "/";
                }
                pathNew += htmlView.ViewName.Substring(0,indexLast);
                return viewEngine.GetView(string.Format("{0}/{1}{2}", pathNew, viewName, extends), string.Format("{0}{1}", viewName, extends), false);

            }
        }
        public async Task<IHtmlContent> GetContentHtmlFromView(HtmlView htmlView)
        {

            var response = httpContext.Response;
            var viewResult = GetView(htmlView);
            if (viewResult.View == null)
            {
                throw new ArgumentNullException($"{htmlView.ViewName} does not match any available view");
            }
            var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = htmlView.Model
            };
            string contentType = "";
            ResponseContentTypeHelper.ResolveContentTypeAndEncoding(
                contentType,
                response.ContentType,
                DefaultContentType,
                out var resolvedContentType,
                out var resolvedContentTypeEncoding);

            response.ContentType = resolvedContentType;
            var viewBuffer = new ViewBuffer(_bufferScope, htmlView.ViewName, ViewBuffer.PartialViewPageSize);
            await using (var writer = new ViewBufferTextWriter(viewBuffer, resolvedContentTypeEncoding))
            {
                // Forcing synchronous behavior so users don't have to await templates.
                var view = viewResult.View;
                using (view as IDisposable)
                {
                    var viewContext = new ViewContext(
                     actionContext,
                     viewResult.View,
                     viewDictionary,
                     new TempDataDictionary(actionContext.HttpContext, tempDataProvider),
                     writer,
                     new HtmlHelperOptions()
                     );
                    await view.RenderAsync(viewContext);
                    await writer.FlushAsync();
                    return viewBuffer;
                }
            }
        }

        public async Task RenderJson(object dataa)
        {
            var json = JsonSerializer.Serialize(dataa, GetHtmlSafeSerializerOptions(options.Value.JsonSerializerOptions));
            var HtmlJson = new HtmlString(json);
            var response = httpContext.Response;
            ResponseContentTypeHelper.ResolveContentTypeAndEncoding(
               null,
               response.ContentType,
               DefaultContentType,
               out var resolvedContentType,
               out var resolvedContentTypeEncoding);
            await using (System.IO.TextWriter writer = writerFactory.CreateWriter(response.Body, resolvedContentTypeEncoding))
            {
                HtmlJson.WriteTo(writer, HtmlEncoder.Default);
                await writer.FlushAsync();
            }
        }

        public async Task RenderHtml(HtmlView htmlView)
        {
            var response = httpContext.Response;
            var viewResult = GetView(htmlView);
            if (viewResult.View == null)
            {
                throw new ArgumentNullException($"{htmlView.ViewName} does not match any available view");
            }
            var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = htmlView.Model
            };
            ResponseContentTypeHelper.ResolveContentTypeAndEncoding(
                null,
                response.ContentType,
                DefaultContentType,
                out var resolvedContentType,
                out var resolvedContentTypeEncoding);

            response.ContentType = resolvedContentType;
            await using (System.IO.TextWriter writer = writerFactory.CreateWriter(response.Body, resolvedContentTypeEncoding))
            {
                var viewContext = new ViewContext(
                actionContext,
                viewResult.View,
                viewDictionary,
                new TempDataDictionary(actionContext.HttpContext, tempDataProvider),
                writer,
                new HtmlHelperOptions()
                );
                var view = viewContext.View;

                await view.RenderAsync(viewContext);
                // Perf: Invoke FlushAsync to ensure any buffered content is asynchronously written to the underlying
                // response asynchronously. In the absence of this line, the buffer gets synchronously written to the
                // response as part of the Dispose which has a perf impact.
                await writer.FlushAsync();
            }
        }
        public async Task RenderFile(DownloadFileView fileView) {
            var response = httpContext.Response;
            response.ContentType = fileView.ContentType;
            response.Headers["Content-Disposition"] = "attachment; filename=" + fileView.Name + ";";
            await fileView.File.CopyToAsync(response.Body);
            await response.Body.FlushAsync();
        }
        public async Task RenderRedirect(RedirectView redirectView)
        {
            httpContext.Response.Redirect(redirectView.RedirectToUrl);
            await Task.CompletedTask;
        }
    }
}
