using System;
using System.Xml.Serialization;

namespace ChartEdit
{
	// Token: 0x02000030 RID: 48
	public class KMKey
	{
		// Token: 0x06000170 RID: 368 RVA: 0x00007E09 File Offset: 0x00006009
		public KMKey()
		{
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00007E14 File Offset: 0x00006014
		public KMKey(KeyType type, NoteType nType, int key, int value)
		{
			this.Type = type;
			this.NType = nType;
			this.Key = key;
			this.Value = value;
		}

		// Token: 0x040000DD RID: 221
		public int Key;

		// Token: 0x040000DE RID: 222
		public NoteType NType;

		// Token: 0x040000DF RID: 223
		[XmlAttribute]
		public KeyType Type;

		// Token: 0x040000E0 RID: 224
		public int Value;
	}
}
