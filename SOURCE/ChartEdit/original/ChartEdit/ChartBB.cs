using System;
using System.Drawing;
using System.Xml.Serialization;

namespace ChartEdit
{
	// Token: 0x02000037 RID: 55
	public class ChartBB
	{
		// Token: 0x06000176 RID: 374 RVA: 0x00007F80 File Offset: 0x00006180
		public ChartBB()
		{
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00007F8B File Offset: 0x0000618B
		public ChartBB(float x, float y, float width, float height)
		{
			this.X = x;
			this.Y = y;
			this.Width = width;
			this.Height = height;
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000178 RID: 376 RVA: 0x00007FB4 File Offset: 0x000061B4
		// (set) Token: 0x06000179 RID: 377 RVA: 0x00007FD7 File Offset: 0x000061D7
		public PointF XY
		{
			get
			{
				return new PointF(this.X, this.Y);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
			}
		}

		// Token: 0x04000110 RID: 272
		[XmlAttribute]
		public float Height;

		// Token: 0x04000111 RID: 273
		[XmlAttribute]
		public float Width;

		// Token: 0x04000112 RID: 274
		[XmlAttribute]
		public float X;

		// Token: 0x04000113 RID: 275
		[XmlAttribute]
		public float Y;
	}
}
