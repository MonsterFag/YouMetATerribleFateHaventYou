using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace wServer_Auto_Restarter
{
	public class Form1 : Form
	{
		private IContainer components = null;
		private Timer timer1;
		private ListBox listBox1;
		private Timer timer2;
		public Form1()
		{
			this.InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			Process[] processes = Process.GetProcesses();
			if (!this.IsListening("127.0.0.1", 2050))
			{
				Process[] array = processes;
				for (int i = 0; i < array.Length; i++)
				{
					Process process = array[i];
					if (process.ProcessName == "wServer")
					{
						process.Kill();
						this.listBox1.Items.Add("[" + Convert.ToString(DateTime.Now) + "] Killed wServer");
					}
				}
				Process.Start("wServer\\\\wServer.exe");
				this.listBox1.Items.Add("[" + Convert.ToString(DateTime.Now) + "] Started wServer");
			}
		}
		private bool IsListening(string server, int port)
		{
			bool result;
			using (TcpClient tcpClient = new TcpClient())
			{
				try
				{
					tcpClient.Connect(server, port);
				}
				catch (SocketException)
				{
					this.listBox1.Items.Add("Server off");
					result = false;
					return result;
				}
				tcpClient.Close();
				result = true;
			}
			return result;
		}
		[DllImport("user32.dll")]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
		private void ErrExit()
		{
			IntPtr hWnd = Form1.FindWindow(null, "wServer.exe - Application Error");
			if (hWnd.ToString() != "0")
			{
				Form1.SendMessage(hWnd, 16u, 0, 0);
				this.listBox1.Items.Add("[" + Convert.ToString(DateTime.Now) + "] Killed Csrss");
				Process[] processesByName = Process.GetProcessesByName("wServer");
				if (processesByName.GetLength(0) > 0)
				{
					processesByName[0].Kill();
				}
			}
			IntPtr intPtr = Form1.FindWindow(null, "Assertion Failed: Abort=Quit, Retry=Debug, Ignore=Continue");
			if (hWnd.ToString() != "0")
			{
				Form1.SendMessage(hWnd, 16u, 0, 0);
				this.listBox1.Items.Add("[" + Convert.ToString(DateTime.Now) + "] Killed MySQL");
				Process[] processesByName = Process.GetProcessesByName("wServer");
				if (processesByName.GetLength(0) > 0)
				{
					processesByName[0].Kill();
				}
			}
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			try
			{
				Process[] processes = Process.GetProcesses();
				if (!this.IsListening("127.0.0.1", 2050))
				{
					Process.Start("wServer\\\\wServer.exe");
				}
				if (!this.IsListening("127.0.0.1", 80))
				{
					Process.Start("Server\\\\server.exe");
				}
				Process[] array = processes;
				for (int i = 0; i < array.Length; i++)
				{
					Process process = array[i];
					if (process.ProcessName == "WerFault")
					{
						process.Kill();
						this.listBox1.Items.Add("[" + Convert.ToString(DateTime.Now) + "] Killed WerFault");
						if (process.ProcessName == "wServer")
						{
							process.Kill();
							this.listBox1.Items.Add("[" + Convert.ToString(DateTime.Now) + "] Killed wServer");
						}
					}
				}
			}
			catch (Exception ex)
			{
				this.listBox1.Items.Add("error: " + ex);
				MessageBox.Show(Convert.ToString(ex));
			}
		}
		private void timer2_Tick(object sender, EventArgs e)
		{
			this.ErrExit();
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.components = new Container();
			this.timer1 = new Timer(this.components);
			this.listBox1 = new ListBox();
			this.timer2 = new Timer(this.components);
			base.SuspendLayout();
			this.timer1.Enabled = true;
			this.timer1.Interval = 10000;
			this.timer1.Tick += new EventHandler(this.timer1_Tick);
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new Point(12, 12);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new Size(260, 232);
			this.listBox1.TabIndex = 0;
			this.timer2.Enabled = true;
			this.timer2.Interval = 1000;
			this.timer2.Tick += new EventHandler(this.timer2_Tick);
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(284, 261);
			base.Controls.Add(this.listBox1);
			base.Name = "Form1";
			this.Text = "wServer Restarter";
			base.Load += new EventHandler(this.Form1_Load);
			base.ResumeLayout(false);
		}
	}
}
