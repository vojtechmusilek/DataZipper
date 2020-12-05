using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DataZipper
{
	public class Zipper
	{
		private Configuration m_Configuration;
		private Logger m_Logger;
		private Timer m_Timer;
		
		public Zipper(Configuration configuration, Logger logger)
		{
			m_Configuration = configuration;
			m_Logger = logger;

			m_Timer = new Timer() { Enabled = false, Interval = m_Configuration.Interval * 60 * 1000 };
			m_Timer.Elapsed += OnElapsed;
			m_Timer.Enabled = m_Configuration.Enabled;
			DataZip();
		}

		private void OnElapsed(object sender, ElapsedEventArgs e)
		{
			DataZip();
		}

		private void DataZip()
		{
			m_Logger.Log(m_Configuration.Name, "Zipping started.");
		}
	}
}
