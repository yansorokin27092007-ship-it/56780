using System;
using System.Windows.Forms;

namespace ConsoleApp2
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			ApplicationConfiguration.Initialize();
			Application.Run(new FormTruck());   // ← вот здесь запускается твоя форма
		}
	}
}