using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ChartEdit
{
	// Token: 0x0200003D RID: 61
	public class Globals : Serializable<Globals>
	{
		// Token: 0x0600018C RID: 396 RVA: 0x000082C0 File Offset: 0x000064C0
		public static void Initialize()
		{
			if (Globals.Instance == null)
			{
				Globals.Instance = Serializable<Globals>.Load("config/globals.xml");
			}
		}

		// Token: 0x0600018D RID: 397 RVA: 0x000082F0 File Offset: 0x000064F0
		public string ReplaceKey(string key)
		{
			foreach (KeyValue keyValue in this.KeyVals)
			{
				if (keyValue.Key == key)
				{
					return keyValue.Value;
				}
			}
			return key;
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600018E RID: 398 RVA: 0x00008368 File Offset: 0x00006568
		// (set) Token: 0x0600018F RID: 399 RVA: 0x0000837F File Offset: 0x0000657F
		public static Globals Instance
		{
			[CompilerGenerated]
			get
			{
				return Globals.Instance;
			}
			[CompilerGenerated]
			private set
			{
				Globals.Instance = value;
			}
		}

		// Token: 0x0400012B RID: 299
		public List<GameProps> GameProperties = new List<GameProps>();

		// Token: 0x0400012C RID: 300
		public List<KeyValue> KeyVals = new List<KeyValue>();
	}
}
