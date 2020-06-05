using AZCore.Extensions;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        private const int timeout = 90000;
        public virtual void BeforeRequest(WebRequest request, MethodHttp method, string url, dynamic Data = null) { }
        public virtual void BeforeSendRequest(WebRequest request, MethodHttp method, string url, string Data = null) { }
        protected virtual HttpWebResponse CreateRequest(string url, MethodHttp method, dynamic data = null, Action<WebRequest> acRequest = null)
        {
            WebRequest request = WebRequest.Create(url);
            BeforeRequest(request, method, url, data);
            string dataJson = JsonConvert.SerializeObject(data);
            byte[] postdatabyte = Encoding.UTF8.GetBytes(dataJson);
            request.Method = method.ToString();
            request.ContentType = "application/json";
            request.ContentLength = postdatabyte.Length;
            request.Timeout = timeout;
            acRequest?.Invoke(request);
            Stream stream = request.GetRequestStream();
            stream.Write(postdatabyte, 0, postdatabyte.Length);
            stream.Close();
            BeforeSendRequest(request, method, url, dataJson);
            return (HttpWebResponse)request.GetResponse();
        }
        public virtual HttpWebResponse DoGet(string url)
        {
            return CreateRequest(url,MethodHttp.GET);
        }
        public virtual HttpWebResponse DoPost(string url, dynamic Data)
        {
            return CreateRequest(url, MethodHttp.POST, Data);
        }
        public virtual HttpWebResponse DoPut(string url, dynamic Data)
        {
            return CreateRequest(url, MethodHttp.PUT, Data);
        }
        public virtual HttpWebResponse DoDelete(string url)
        {
            return CreateRequest(url, MethodHttp.DELETE);
        }
        public virtual HttpWebResponse DoPatch(string url, dynamic Data)
        {
            return CreateRequest(url, MethodHttp.PATCH, Data);
        }
        #endregion
    }
    public class RestApi<TSocial> : RestApi
            where TSocial : RestApi
    {
        private String GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
        {
            Stream stream = null;
            StreamReader reader = null;

            try
            {
                stream = rsp.GetResponseStream();
                reader = new StreamReader(stream, encoding);
                return reader.ReadToEnd();
            }
            finally
            {
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                if (rsp != null) rsp.Close();
            }
        }
        #region -- ResponseData --
        public virtual ResponseData<TDataResponse> DoAction<TDataResponse>(Func<TSocial, HttpWebResponse> fnSocial) where TDataResponse : IDataResponse
        {
            var result = new ResponseData<TDataResponse>();
            try
            {
                var response = fnSocial(this as TSocial);
                Encoding encoding = Encoding.GetEncoding(response.CharacterSet);
                result.StatusCode = response.StatusCode;
                var rs = GetResponseAsString(response, encoding);
                result.Data = rs.ToObject<TDataResponse>();
                
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public virtual ResponseData<TDataResponse> DoGet<TDataResponse>(string url) where TDataResponse : IDataResponse => this.DoAction<TDataResponse>(p =>p.DoGet(url));
        public virtual ResponseData<TDataResponse> DoPatch<TDataResponse>(string url, dynamic Data) where TDataResponse : IDataResponse =>  this.DoAction<TDataResponse>( p =>  p.DoPatch(url, Data));
        public virtual ResponseData<TDataResponse> DoPost<TDataResponse>(string url, dynamic Data) where TDataResponse : IDataResponse =>  this.DoAction<TDataResponse>( p =>  p.DoPost(url, Data));
        public virtual ResponseData<TDataResponse> DoPut<TDataResponse>(string url, dynamic Data) where TDataResponse : IDataResponse =>  this.DoAction<TDataResponse>( p =>  p.DoPut(url, Data));
        public virtual ResponseData<TDataResponse> DoDelete<TDataResponse>(string url) where TDataResponse : IDataResponse =>  this.DoAction<TDataResponse>( p =>  p.DoDelete(url));

        public virtual ResponseData<TDataResponse> DoPatch<TDataResponse, TDataRequest>(string url, TDataRequest Data) where TDataResponse : IDataResponse where TDataRequest : IDataResponse =>  this.DoAction<TDataResponse>( p =>  p.DoPatch(url, Data));
        public virtual ResponseData<TDataResponse> DoPost<TDataResponse, TDataRequest>(string url, dynamic Data) where TDataResponse : IDataResponse where TDataRequest : IDataResponse =>  this.DoAction<TDataResponse>( p =>  p.DoPost(url, Data));
        public virtual ResponseData<TDataResponse> DoPut<TDataResponse, TDataRequest>(string url, dynamic Data) where TDataResponse : IDataResponse where TDataRequest : IDataResponse =>  this.DoAction<TDataResponse>( p =>  p.DoPut(url, Data));
    
        #endregion

    }
}
