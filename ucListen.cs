using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;

namespace PaJaMa.WebRequestor
{
	public partial class ucListen : UserControl
	{
		private TcpListener _listener;
		public ucListen()
		{
			InitializeComponent();
		}

		private void btnGO_Click(object sender, EventArgs e)
		{
			if (_listener != null)
			{
				stop();
				btnGO.Text = "Start";
			}
			else
			{
				new Thread(new ThreadStart(() => start())).Start();
				btnGO.Text = "Stop";
			}
		}

		private void start()
		{
			_listener = new TcpListener(IPAddress.Parse("10.1.10.13"), (int)numPort.Value);
			_listener.Start();

			Byte[] bytes = new Byte[256];

			// Enter the listening loop.
			while (true)
			{
				Console.Write("Waiting for a connection... ");

				// Perform a blocking call to accept requests.
				// You could also use server.AcceptSocket() here.
				TcpClient client = _listener.AcceptTcpClient();
				Console.WriteLine("Connected!");

				StringBuilder sb = new StringBuilder();

				// Get a stream object for reading and writing
				NetworkStream stream = client.GetStream();


				int i;


				// Loop to receive all the data sent by the client.
				while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
				{
					// Translate data bytes to a ASCII string.
					var data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
					Console.WriteLine("Received: {0}", data);
					sb.Append(data);

					// Process the data sent by the client.
					data = data.ToUpper();

					byte[] msg = System.Text.Encoding.ASCII.GetBytes("breakpoint_set -i 1  -f file:///C:/wamp/www/index.php -n 248 -t line");

					// Send back a response.
					stream.Write(msg, 0, msg.Length);
					// Console.WriteLine("Sent: {0}", data);

					msg = System.Text.Encoding.ASCII.GetBytes("run -i 2");

					// Send back a response.
					stream.Write(msg, 0, msg.Length);
					// Console.WriteLine("Sent: {0}", data);

					msg = System.Text.Encoding.ASCII.GetBytes("breakpoint_list -i 3");

					// Send back a response.
					stream.Write(msg, 0, msg.Length);
					// Console.WriteLine("Sent: {0}", data);
				}

				var all = sb.ToString();
				// Shutdown and end connection
				client.Close();
			}
		}

		private void stop()
		{
			_listener.Stop();
			_listener = null;
		}
	}
}
