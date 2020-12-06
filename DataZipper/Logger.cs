using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataZipper
{
	public class Logger
	{
		private string m_LogPath;
		private string m_LogDirectory;
		private DateTime m_LogDateTime;
		private readonly object m_Lock;

		public Logger(string logPath, object logLock)
		{
			m_LogPath = logPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
			m_LogDateTime = DateTime.Now;
			m_LogDirectory = logPath;
			m_Lock = logLock;

			Log("### Data Zipper successfully started ###");
		}

		private void CheckLog()
		{
			lock (m_Lock)
			{
				if (m_LogDateTime.Date != DateTime.Now.Date)
				{
					m_LogPath = m_LogDirectory + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
					m_LogDateTime = DateTime.Now;
				}

				if (!File.Exists(m_LogPath))
				{
					var newLog = File.Create(m_LogPath);
					newLog.Close();
				}
			}
		}

		public void Log(string text, string name)
		{
			Log($"{text} ({name})");
		}

		public void Log(string text)
		{
			CheckLog();

			lock (m_Lock)
			{
				using (StreamWriter sw = new StreamWriter(m_LogPath, true))
				{
					sw.WriteLine($"[{GetTimestamp()}]: {text}");
				}
			}

			
		}

		private string GetTimestamp()
		{
			return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		}
	}
}
