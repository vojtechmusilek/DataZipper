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
		private readonly object m_Lock = new object();

		public Logger(string logPath)
		{
			m_LogPath = logPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log";

			Log("Data Zipper started.");
		}

		public void Log(string name, string text)
		{
			//todo check date - kdyz je jiny den tak vytvorit novy config

			lock (m_Lock)
			{
				using (StreamWriter sw = new StreamWriter(m_LogPath, true))
				{
					sw.WriteLine($"[{GetTimestamp()} {name}]: {text}");
				}
			}

			
		}

		public void Log(string text)
		{
			//todo check date - kdyz je jiny den tak vytvorit novy config

			lock (m_LogPath)
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
