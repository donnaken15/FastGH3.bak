using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace ChartEdit.Properties
{
	// Token: 0x02000029 RID: 41
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
	[CompilerGenerated]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000139 RID: 313 RVA: 0x000069B4 File Offset: 0x00004BB4
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x040000C6 RID: 198
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
