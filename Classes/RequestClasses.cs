using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace PaJaMa.WebRequestor.Classes
{
	public class Header
	{
		public string Name { get; set; }
		public string Value { get; set; }

		public Header Clone()
		{
			return new Header() { Name = this.Name, Value = this.Value };
		}
	}

	public class RequestResponse
	{
		public bool UseDefaultCredentials { get; set; }
		public DateTime RequestDate { get; set; }
		public string URL { get; set; }
		public string Method { get; set; }
		public int StatusCode { get; set; }
		public List<Header> RequestHeaders { get; set; }
		public List<Header> ResponseHeaders { get; set; }
		public string RequestBody { get; set; }
		public string ResponseBody { get; set; }
		public int Duration { get; set; }

		[XmlIgnore]
		public double ResponseLength
		{
			get { return string.IsNullOrEmpty(ResponseBody) ? 0 : ResponseBody.Length; }
		}

		public RequestResponse()
		{
			RequestHeaders = new List<Header>();
			ResponseHeaders = new List<Header>();
		}

		public RequestResponse Clone()
		{
			return new RequestResponse()
			{
				UseDefaultCredentials = this.UseDefaultCredentials,
				RequestDate = this.RequestDate,
				URL = this.URL,
				Method = this.Method,
				StatusCode = this.StatusCode,
				RequestHeaders = this.RequestHeaders.Select(r => r.Clone()).ToList(),
				ResponseHeaders = this.ResponseHeaders.Select(r => r.Clone()).ToList(),
				RequestBody = this.RequestBody,
				ResponseBody = this.ResponseBody,
				Duration = this.Duration
			};
		}
	}

	public class Workspace
    {
		public List<RequestResponse> RequestResponses { get; set; }
		public Guid ID { get; set; }
		public Workspace()
        {
			RequestResponses = new List<RequestResponse>();
			ID = Guid.NewGuid();
        }
    }
}
