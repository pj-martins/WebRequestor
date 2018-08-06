using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaJaMa.WebRequestor.Classes
{
	public class Header
	{
		public string Name { get; set; }
		public string Value { get; set; }
	}

	public class RequestResponse
	{
		public DateTime RequestDate { get; set; }
		public string URL { get; set; }
		public string Method { get; set; }
		public int StatusCode { get; set; }
		public List<Header> RequestHeaders { get; set; }
		public List<Header> ResponseHeaders { get; set; }
		public string RequestBody { get; set; }
		public string ResponseBody { get; set; }

		public RequestResponse()
		{
			RequestHeaders = new List<Header>();
			ResponseHeaders = new List<Header>();
		}
	}
}
