using AZCore.Extensions;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

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
        protected virtual void BeforeRequest(WebRequest request, MethodHttp method, string url, dynamic data = null) { }
        protected virtual void BeforeSendRequest(WebRequest request, MethodHttp method, string url, string dataJson = null) { }
        protected virtual void AfterRequest(WebRequest request, MethodHttp method, string url, HttpWebResponse response, string dataJson = null) { }
        protected virtual string GetDataJson(MethodHttp method, string url, dynamic data)
        {
            return JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.None,
                                new JsonSerializerSettings
                                {
                                    NullValueHandling = NullValueHandling.Ignore
                                });
        }
        protected virtual HttpWebResponse CreateRequest(string url, MethodHttp method, dynamic data = null, Action<WebRequest> acRequest = null, Action<WebRequest, HttpWebResponse> acResponse = null)
        {
            WebRequest request = WebRequest.Create(url);
            BeforeRequest(request, method, url, data);
            string dataJson = GetDataJson(method, url, data);
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
            var response = (HttpWebResponse)request.GetResponse();
            acResponse?.Invoke(request, response);
            AfterRequest(request, method, url, response, dataJson);
            return response;
        }
        public virtual string GetUrlBase(string url) => url;
        public virtual HttpWebResponse DoGet(string url, Action<WebRequest> acRequest = null, Action<WebRequest, HttpWebResponse> acResponse = null)
        {
            return CreateRequest(GetUrlBase(url), MethodHttp.GET, null, acRequest, acResponse);
        }
        public virtual HttpWebResponse DoPost(string url, dynamic Data, Action<WebRequest> acRequest = null, Action<WebRequest, HttpWebResponse> acResponse = null)
        {
            return CreateRequest(GetUrlBase(url), MethodHttp.POST, Data, acRequest, acResponse);
        }
        public virtual HttpWebResponse DoPut(string url, dynamic Data, Action<WebRequest> acRequest = null, Action<WebRequest, HttpWebResponse> acResponse = null)
        {
            return CreateRequest(GetUrlBase(url), MethodHttp.PUT, Data, acRequest, acResponse);
        }
        public virtual HttpWebResponse DoDelete(string url, Action<WebRequest> acRequest = null, Action<WebRequest, HttpWebResponse> acResponse = null)
        {
            return CreateRequest(GetUrlBase(url), MethodHttp.DELETE,null, acRequest, acResponse);
        }
        public virtual HttpWebResponse DoPatch(string url, dynamic Data, Action<WebRequest> acRequest = null, Action<WebRequest, HttpWebResponse> acResponse = null)
        {
            return CreateRequest(GetUrlBase(url), MethodHttp.PATCH, Data, acRequest, acResponse);
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
                var rsData = GetResponseAsString(response, encoding);
                Debug.WriteLine(rsData);
                result.Data = rsData.ToObject<TDataResponse>();

            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
            return result;
        }
        //TDataResponse
        public virtual ResponseData<TDataResponse> DoGet<TDataResponse>(string url, Action<WebRequest> acRequest = null, Action<WebRequest, HttpWebResponse> acResponse = null) where TDataResponse : IDataResponse => this.DoAction<TDataResponse>(p => p.DoGet(url, acRequest, acResponse));
        public virtual ResponseData<TDataResponse> DoPatch<TDataResponse>(string url, dynamic Data, Action<WebRequest> acRequest = null, Action<WebRequest, HttpWebResponse> acResponse = null) where TDataResponse : IDataResponse => this.DoAction<TDataResponse>(p => p.DoPatch(url, Data, acRequest, acResponse));
        public virtual ResponseData<TDataResponse> DoPost<TDataResponse>(string url, dynamic Data, Action<WebRequest> acRequest = null, Action<WebRequest, HttpWebResponse> acResponse = null) where TDataResponse : IDataResponse => this.DoAction<TDataResponse>(p => p.DoPost(url, Data, acRequest, acResponse));
        public virtual ResponseData<TDataResponse> DoPut<TDataResponse>(string url, dynamic Data, Action<WebRequest> acRequest = null, Action<WebRequest, HttpWebResponse> acResponse = null) where TDataResponse : IDataResponse => this.DoAction<TDataResponse>(p => p.DoPut(url, Data, acRequest, acResponse));
        public virtual ResponseData<TDataResponse> DoDelete<TDataResponse>(string url, Action<WebRequest> acRequest = null, Action<WebRequest, HttpWebResponse> acResponse = null) where TDataResponse : IDataResponse => this.DoAction<TDataResponse>(p => p.DoDelete(url, acRequest, acResponse));
        // TDataRequest - TDataResponse
        public virtual ResponseData<TDataResponse> DoPatch<TDataResponse, TDataRequest>(string url, TDataRequest Data, Action<WebRequest> acRequest = null, Action<WebRequest, HttpWebResponse> acResponse = null) where TDataResponse : IDataResponse where TDataRequest : IDataRequest => this.DoAction<TDataResponse>(p => p.DoPatch(url, Data, acRequest, acResponse));
        public virtual ResponseData<TDataResponse> DoPost<TDataResponse, TDataRequest>(string url, TDataRequest Data, Action<WebRequest> acRequest = null, Action<WebRequest, HttpWebResponse> acResponse = null) where TDataResponse : IDataResponse where TDataRequest : IDataRequest => this.DoAction<TDataResponse>(p => p.DoPost(url, Data, acRequest, acResponse));
        public virtual ResponseData<TDataResponse> DoPut<TDataResponse, TDataRequest>(string url, TDataRequest Data, Action<WebRequest> acRequest = null, Action<WebRequest, HttpWebResponse> acResponse = null) where TDataResponse : IDataResponse where TDataRequest : IDataRequest => this.DoAction<TDataResponse>(p => p.DoPut(url, Data, acRequest, acResponse));

        public virtual ResponseData<TDataResponse> DoPatch<TDataResponse, TDataRequest>(string url, Action<TDataRequest> acData, Action<WebRequest> acRequest = null, Action<WebRequest, HttpWebResponse> acResponse = null) where TDataResponse : IDataResponse where TDataRequest : IDataRequest,new() => this.DoAction<TDataResponse>(p => { var Data = new TDataRequest();acData?.Invoke(Data); return p.DoPatch(url, Data, acRequest, acResponse); });
        public virtual ResponseData<TDataResponse> DoPost<TDataResponse, TDataRequest>(string url, Action<TDataRequest> acData, Action<WebRequest> acRequest = null, Action<WebRequest, HttpWebResponse> acResponse = null) where TDataResponse : IDataResponse where TDataRequest : IDataRequest, new() =>  this.DoAction<TDataResponse>( p => { var Data = new TDataRequest(); acData?.Invoke(Data); return p.DoPost(url, Data, acRequest, acResponse); });
        public virtual ResponseData<TDataResponse> DoPut<TDataResponse, TDataRequest>(string url, Action<TDataRequest> acData, Action<WebRequest> acRequest = null, Action<WebRequest, HttpWebResponse> acResponse = null) where TDataResponse : IDataResponse where TDataRequest : IDataRequest, new() =>  this.DoAction<TDataResponse>( p => { var Data = new TDataRequest(); acData?.Invoke(Data); return p.DoPut(url, Data, acRequest, acResponse); });
    
        #endregion

    }
}
