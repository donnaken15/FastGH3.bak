using System;
using System.IO;

namespace ChartEdit
{
	// Token: 0x02000028 RID: 40
	internal static class Program
	{
		// Token: 0x06000138 RID: 312 RVA: 0x00006980 File Offset: 0x00004B80
		[STAThread]
		private static void Main(string[] args)
		{
			Chart chart = new Chart(args[0]);
			string fileName = Path.ChangeExtension(args[0], ".qb");
			new QbArrayWriter().Save(chart, fileName);
		}
	}
}
