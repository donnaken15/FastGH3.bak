using System;
using System.Xml.Serialization;

namespace ChartEdit
{
	// Token: 0x0200000E RID: 14
	public class ChartPoint
	{
		// Token: 0x06000086 RID: 134 RVA: 0x00003700 File Offset: 0x00001900
		public ChartPoint()
		{
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0000370B File Offset: 0x0000190B
		public ChartPoint(float x, float y)
		{
			this.X = x;
			this.Y = y;
		}

		// Token: 0x0400005D RID: 93
		[XmlAttribute]
		public float X;

		// Token: 0x0400005E RID: 94
		[XmlAttribute]
		public float Y;
	}
}
