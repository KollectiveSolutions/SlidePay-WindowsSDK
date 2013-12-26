using System;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Generic;
using Microsoft.Http;
using System.Net.Browser;
namespace WindowsSDK
{
    public partial class SlidePayWindowsSDK
    {
        private rest_response rest_client<T>(
            string url,
            string method,
            int? timeout,
            T body)
        {
            DateTime start_time = DateTime.Now;

            try
            {
                log("rest_client " + method + " to " + url);

                #region Check-Method

                if ((String.Compare(method.ToLower().Trim(), "get") != 0) &&
                    (String.Compare(method.ToLower().Trim(), "post") != 0) &&
                    (String.Compare(method.ToLower().Trim(), "put") != 0) &&
                    (String.Compare(method.ToLower().Trim(), "delete") != 0))
                {
                    log("rest_client invalid method specified: " + method, true);
                    return null;
                }

                #endregion

                #region Variables

                string json_body = null;
                Stream temp_stream;
                int request_bytes = 0;
                int response_bytes = 0;

                #endregion

                #region Build-WebRequest
                WebRequest.RegisterPrefix("http://", WebRequestCreator.ClientHttp);

                WebRequest.RegisterPrefix("https://", WebRequestCreator.ClientHttp);

                HttpWebRequest client = (HttpWebRequest)WebRequest.Create(url);
                
                //client.KeepAlive = false;
                client.Method = method.ToUpper().Trim();
                //client.AllowAutoRedirect = true; //not implemented in silverlight!?
                //client.Timeout = 30000;
               // client.ContentLength = 0;
                //client.ContentType = "application/json";
                //client.UserAgent = "SlidePay-WindowsSDK-" + _version;

                if (timeout == null)
                {
                    //client.Timeout = 30000;
                }
                else
                {
                    //client.Timeout = Convert.ToInt32(timeout);
                }

                #endregion

                #region Custom-Headers

                if (!string_null_or_empty(_token_string))
                {
                    
                    client.Headers["x-cube-token"] = _token_string;
                }
                else if (!string_null_or_empty(_email) && !string_null_or_empty(_password))
                {
                    client.Headers["x-cube-email"] = _email;
                    client.Headers["x-cube-password"] = _password;
                }
                else
                {
                    log("rest_client token not found, and both email and password are null", true);
                    return null;
                }

                #endregion

                #region Setup-the-Proxy-and-Allow-Invalid-SSL-Certificates

                if (!string_null_or_empty(_proxy_url))
                {
                    
                  /*  WebProxy proxy = new WebProxy();
                    proxy.Address = new Uri(_proxy_url);
                    client.Proxy = proxy;
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; 
                  */
                }

                #endregion

                #region Package-Payload

                if ((String.Compare(method.ToLower().Trim(), "post") == 0) ||
                    (String.Compare(method.ToLower().Trim(), "put") == 0))
                {
                    json_body = null;
                    byte[] json_bytes = null;

                    #region JSON-String

                    if (body is string)
                    {
                        if (!string_null_or_empty(body.ToString()))
                        {
                            json_body = body.ToString();
                            json_bytes = Encoding.UTF8.GetBytes(json_body);
                            client.ContentLength = json_bytes.Length;

                            temp_stream = client.GetRequestStream(30000);
                            temp_stream.Write(json_bytes, 0, json_bytes.Length);
                            temp_stream.Close();
                        }
                        else
                        {
                            json_body = null;
                        }
                    }

                    #endregion

                    #region JSON-Object

                    else
                    {
                        json_body = serialize_json<T>(body);
                        json_bytes = Encoding.UTF8.GetBytes(json_body);
                        client.ContentLength = json_bytes.Length;

                        temp_stream = client.GetRequestStream(30000);
                        temp_stream.Write(json_bytes, 0, json_bytes.Length);
                        temp_stream.Close();
                    }

                    #endregion

                    #region Enumerate

                    if (json_body.Length > 0)
                    {
                        log("rest_client packaging JSON string body: " + json_bytes.Length + " bytes: " + json_body);
                        request_bytes = json_bytes.Length;
                    }

                    #endregion
                }

                #endregion

                #region Submit-Request-and-Get-Response

                HttpWebResponse response;

                try
                {
                    response = (HttpWebResponse)client.GetResponse(30000);
                }
                catch (Exception e_inner)
                {
                    if (e_inner is WebException)
                    {
                        #region WebException

                        if (body is string)
                        {
                            #region Body-is-String

                            if (!string_null_or_empty(body.ToString()))
                            {
                                webexception(url, method, "WebException while calling GetResponse", body.ToString(), (WebException)e_inner);
                                return null;
                            }
                            else
                            {
                                webexception(url, method, "WebException while calling GetResponse", null, (WebException)e_inner);
                                return null;
                            }

                            #endregion
                        }
                        else
                        {
                            #region Body-is-Not-String

                            webexception(url, method, "WebException while calling GetResponse", null, (WebException)e_inner);
                            return null;

                            #endregion
                        }

                        #endregion
                    }
                    else
                    {
                        #region Not-WebException

                        exception("rest_client", "Exception while calling GetResponse", e_inner);
                        return null;

                        #endregion
                    }
                }

                #endregion

                #region Parse-Response

                rest_response http_response = new rest_response();

                /*try { http_response.encoding = response.ContentEncoding; }
                catch (Exception)
                {
                    log("rest_client null value for ContentEncoding", true);
                }*/

                try { http_response.content_type = response.ContentType; }
                catch (Exception)
                {
                    log("rest_client null value for ContentType", true);
                }

                try { http_response.content_length = response.ContentLength; }
                catch (Exception)
                {
                    log("rest_client null value for ContentLength", true);
                    http_response.content_length = 0;
                }

                try { http_response.response_uri = response.ResponseUri.ToString(); }
                catch (Exception)
                {
                    log("rest_client null value for ResponseUri", true);
                }

                try { http_response.status_code = (int)response.StatusCode; }
                catch (Exception)
                {
                    log("rest_client null value for StatusCode", true);
                }

                try { http_response.status_description = response.StatusDescription; }
                catch (Exception)
                {
                    log("rest_client null value for StatusDescription", true);
                }

                try
                {
                    StringBuilder sb = new StringBuilder();
                    Byte[] buf = new byte[8192];
                    Stream response_stream = response.GetResponseStream();
                    int count = 0;

                    do
                    {
                        count = response_stream.Read(buf, 0, buf.Length);
                        if (count != 0)
                        {
                            sb.Append(Encoding.UTF8.GetString(buf, 0, count));
                        }
                    }
                    while (count > 0);

                    http_response.output_body_string = sb.ToString();
                    response_stream.Close();
                    http_response.content_length = http_response.output_body_string.Length;

                    if (http_response.output_body_string.Length > 0)
                    {
                        response_bytes = http_response.output_body_string.Length;
                    }
                }
                catch (Exception)
                {
                    log("rest_client no content body found", true);
                    http_response.output_body_string = null;
                    http_response.content_length = 0;
                }

                #endregion

                #region Enumerate-Response

                log("rest_client " + method + " " + http_response.response_uri + " completed " + decimal_tostring(get_total_ms(start_time)) + "ms, response: " + http_response.content_length + "B " + http_response.content_type + " status " + http_response.status_code + " " + http_response.status_description);
                log("response body: " + http_response.output_body_string);
                response.Close();

                #endregion

                return http_response;
            }
            catch (Exception e)
            {
                exception("rest_client", "general exception (" + get_total_ms(start_time) + "ms)", e);
                return null;
            }
        }
    }
}