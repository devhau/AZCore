using AZCore.Extensions;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AZSocial.Base
{
    public enum MethodHttp { 
        GET,
        POST,
        PUT,
        DELETE,
        PATCH
    }
    public class ResponseData<TClass> { 
        public TClass Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
    public class RestApi : ISocial{
        #region -- Common --
        public virtual HttpClient CreateHttp() => new HttpClient();
        public virtual Task BeforeRequest(HttpClient client, MethodHttp method) => Task.CompletedTask;
        public virtual async Task<HttpResponseMessage> DoGet(string url)
        {
            var client = this.CreateHttp();
            await this.BeforeRequest(client, MethodHttp.GET);
            return await client.GetAsync(url);
        }
        public virtual async Task<HttpResponseMessage> DoPost(string url, dynamic Data)
        {
            var client = this.CreateHttp();
            await this.BeforeRequest(client, MethodHttp.POST);
            var DataContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(Data)));
            DataContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return await client.PostAsync(url, DataContent);
        }
        public virtual async Task<HttpResponseMessage> DoPut(string url, dynamic Data)
        {
            var client = this.CreateHttp();
            await this.BeforeRequest(client, MethodHttp.PUT);
            var DataContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(Data)));
            DataContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return await client.PutAsync(url, DataContent);
        }
        public virtual async Task<HttpResponseMessage> DoDelete(string url)
        {
            var client = this.CreateHttp();
            await this.BeforeRequest(client, MethodHttp.DELETE);
            return await client.DeleteAsync(url);
        }
        public virtual async Task<HttpResponseMessage> DoPatch(string url, dynamic Data)
        {
            var client = this.CreateHttp();
            await this.BeforeRequest(client, MethodHttp.PATCH);
            var DataContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(Data)));
            DataContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return await client.PatchAsync(url, DataContent);
        }
        #endregion
    }
    public class RestApi<TSocial> : RestApi
            where TSocial : RestApi
    {
     
        #region -- ResponseData --
        public virtual async Task<ResponseData<TClass>> DoAction<TClass>(Func<TSocial, Task<HttpResponseMessage>> fnSocial) 
        {
            var result = new ResponseData<TClass>();
            var rs = await fnSocial(this as TSocial);
            result.StatusCode = rs.StatusCode;
            result.Data = (await rs.Content.ReadAsStringAsync()).ToObject<TClass>();
            return result;
        }
        public virtual async Task<ResponseData<TClass>> DoGet<TClass>(string url) =>await this.DoAction<TClass>(p =>p.DoGet(url));
        public virtual async Task<ResponseData<TClass>> DoPatch<TClass>(string url, dynamic Data) => await this.DoAction<TClass>(p => p.DoPatch(url, Data));
        public virtual async Task<ResponseData<TClass>> DoPost<TClass>(string url, dynamic Data) => await this.DoAction<TClass>(p => p.DoPost(url, Data));
        public virtual async Task<ResponseData<TClass>> DoPut<TClass>(string url, dynamic Data) => await this.DoAction<TClass>(p => p.DoPut(url, Data));
        public virtual async Task<ResponseData<TClass>> DoDelete<TClass>(string url) => await this.DoAction<TClass>(p => p.DoDelete(url));

        #endregion

    }
}
