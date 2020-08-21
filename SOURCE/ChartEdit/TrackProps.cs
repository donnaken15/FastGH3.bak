using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ChartEdit
{
	// Token: 0x02000004 RID: 4
	public class TrackProps
	{
		// Token: 0x0400001C RID: 28
		[XmlAttribute]
		public string HopoLogic;

		// Token: 0x0400001D RID: 29
		[XmlAttribute]
		public string Name;

		// Token: 0x0400001E RID: 30
		public List<NoteProp> NoteProperties = new List<NoteProp>();

		// Token: 0x0400001F RID: 31
		public List<SpecialProp> SpecialProperties = new List<SpecialProp>();
	}
}
