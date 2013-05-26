using System;
using System.Collections;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Markup;
using System.Windows.Input;
using System.Windows.Media.Animation;



using Rene;
using Rene.Event;
using Rene.Controller;
using Rene.Model;
using System.Data;

using Rene.DataObject;
namespace Rene.Util
{
	public static class HTTP
	{
		public static string Post(string URI, string Parameters)
		{

            try
            {
                System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
                //req.Proxy = new System.Net.WebProxy(ProxyString, true);

                req.ContentType = "application/x-www-form-urlencoded";
                req.Method = "POST";

                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(Parameters);
                req.ContentLength = bytes.Length;

                System.IO.Stream os = req.GetRequestStream();
                os.Write(bytes, 0, bytes.Length);
                os.Close();

                System.Net.WebResponse resp = req.GetResponse();
                if (resp == null) return null;
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                return sr.ReadToEnd().Trim();
            }
            catch (Exception e)
            {
                return "";
            }
			
		}
	}
}
