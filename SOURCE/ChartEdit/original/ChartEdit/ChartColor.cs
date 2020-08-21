using System;
using System.Drawing;
using System.Xml.Serialization;

namespace ChartEdit
{
	// Token: 0x0200001F RID: 31
	public class ChartColor
	{
		// Token: 0x06000112 RID: 274 RVA: 0x00005A22 File Offset: 0x00003C22
		public ChartColor()
		{
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00005A30 File Offset: 0x00003C30
		public ChartColor(Color color, int brushSize)
		{
			this.A = (int)color.A;
			this.R = (int)color.R;
			this.G = (int)color.G;
			this.B = (int)color.B;
			this.BrushSize = brushSize;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00005A81 File Offset: 0x00003C81
		public ChartColor(int a, int r, int g, int b, int brushSize)
		{
			this.A = a;
			this.R = r;
			this.G = g;
			this.B = b;
			this.BrushSize = brushSize;
		}

		// Token: 0x0400009A RID: 154
		[XmlAttribute]
		public int A;

		// Token: 0x0400009B RID: 155
		[XmlAttribute]
		public int B;

		// Token: 0x0400009C RID: 156
		[XmlAttribute]
		public int BrushSize;

		// Token: 0x0400009D RID: 157
		[XmlAttribute]
		public int G;

		// Token: 0x0400009E RID: 158
		[XmlAttribute]
		public int R;
	}
}
