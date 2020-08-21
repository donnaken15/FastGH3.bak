using System;
using System.Xml.Serialization;

namespace ChartEdit
{
	// Token: 0x02000005 RID: 5
	public class SpecialProp
	{
		// Token: 0x04000020 RID: 32
		[XmlAttribute]
		public int Flag;

		// Token: 0x04000021 RID: 33
		[XmlAttribute]
		public string Name;
	}
}
