using System;

namespace ChartEdit
{
    // Token: 0x02000028 RID: 40
    internal static class Program
	{
		// Token: 0x06000138 RID: 312 RVA: 0x00006980 File Offset: 0x00004B80
		[STAThread]
		private static void Main(string[] args)
		{
            if (args.Length > 0)
                new QbArrayWriter().Save(new Chart(args[0]));
		}
	}
}
