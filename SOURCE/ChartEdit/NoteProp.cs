using System.Xml.Serialization;

namespace ChartEdit
{
    // Token: 0x02000020 RID: 32
    public class NoteProp
	{
		// Token: 0x0400009F RID: 159
		[XmlAttribute]
		public bool FlipsHOPO;

		// Token: 0x040000A0 RID: 160
		[XmlAttribute]
		public bool ForcesHOPO;

		// Token: 0x040000A1 RID: 161
		[XmlAttribute]
		public bool ForcesStrum;

		// Token: 0x040000A2 RID: 162
		[XmlAttribute]
		public bool ForcesTapping;

		// Token: 0x040000A3 RID: 163
		[XmlAttribute]
		public int Fret;

		// Token: 0x040000A4 RID: 164
		[XmlAttribute]
		public bool IsNote;

		// Token: 0x040000A5 RID: 165
		[XmlAttribute]
		public int PointValue;
	}
}
