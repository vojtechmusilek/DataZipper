using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DataZipper
{
	public class Zipper
	{
		public Configuration Configuration;
		private Logger m_Logger;
		private Timer m_Timer;
		
		public Zipper(Configuration configuration, Logger logger)
		{
			Configuration = configuration;
			m_Logger = logger;

			m_Timer = new Timer();
			m_Timer.Elapsed += OnElapsed;
			m_Timer.Interval = Configuration.Interval * 60 * 1000;
			m_Timer.Enabled = Configuration.Enabled;

			if (Configuration.Enabled)
			{
				DataZip();
			}
		}
		public void Start()
		{
			if(Configuration.Enabled == true)
			{
				m_Timer.Start();
				DataZip();
			}
		}

		public void Stop()
		{
			if (m_Timer.Enabled)
			{
				m_Logger.Log("Zipping stopped", Configuration.Name);
				m_Timer.Stop();
			}
		}

		public void Restart()
		{
			Stop();
			Start();
		}

		private void OnElapsed(object sender, ElapsedEventArgs e)
		{
			m_Timer.Interval = Configuration.Interval * 60 * 1000;

			DataZip();
		}

		private void DataZip()
		{
			m_Logger.Log("Zipping started", Configuration.Name);

			Stopwatch zippingTime = new Stopwatch();
			zippingTime.Start();

			// Clear all files in temporary folder
			foreach (var item in Directory.GetFiles(Configuration.TemporaryPath))
			{
				File.Delete(item);
			}

			foreach (var item in Directory.GetDirectories(Configuration.TemporaryPath))
			{
				Directory.Delete(item, true);
			}

			try
			{
				// Copy all sources to temporary folder
				foreach (var item in Configuration.SourceFiles)
				{
					File.Copy(item, Configuration.TemporaryPath + Path.GetFileName(item));
				}

				if (Configuration.SourceFolder != null)
				{
					Copy(Configuration.SourceFolder, Configuration.TemporaryPath);
				}

				string zipTemporaryPath = Path.GetFullPath(Path.Combine(Configuration.TemporaryPath, "..\\")) + Configuration.Name + ".zip";

				if (File.Exists(zipTemporaryPath))
				{
					File.Delete(zipTemporaryPath);
				}

				string zipDestinationPath = Configuration.DestinationPath + "\\" + Configuration.Name + ".zip";

				ZipFile.CreateFromDirectory(Configuration.TemporaryPath, zipTemporaryPath);

				File.Copy(zipTemporaryPath, zipDestinationPath, true);

				File.Delete(zipTemporaryPath);

				m_Logger.Log($"Zipping finished successfully in {zippingTime.ElapsedMilliseconds} ms.", Configuration.Name);
			}
			catch (Exception ex)
			{
				m_Logger.Log($"Zipping failed after {zippingTime.ElapsedMilliseconds} ms.", Configuration.Name);
				m_Logger.Log($"Error message: {ex.Message}", Configuration.Name);
			}

		}

		public static void Copy(string sourceDirectory, string targetDirectory)
		{
			DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
			DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

			CopyAll(diSource, diTarget);
		}

		public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
		{
			Directory.CreateDirectory(target.FullName);

			// Copy each file into the new directory.
			foreach (FileInfo fi in source.GetFiles())
			{
				fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
			}

			// Copy each subdirectory using recursion.
			foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
			{
				DirectoryInfo nextTargetSubDir =
						target.CreateSubdirectory(diSourceSubDir.Name);
				CopyAll(diSourceSubDir, nextTargetSubDir);
			}
		}
	}
}
