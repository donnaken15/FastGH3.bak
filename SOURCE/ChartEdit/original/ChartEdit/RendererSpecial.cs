using System;
using System.Collections.Generic;
using System.Drawing;

namespace ChartEdit
{
	// Token: 0x0200003C RID: 60
	public class RendererSpecial : List<PointF>
	{
		// Token: 0x0600018A RID: 394 RVA: 0x00008210 File Offset: 0x00006410
		public RendererSpecial(string name, int index, PointF[] point)
		{
			this.Name = name;
			this.SIndex = index;
			for (int i = 0; i < point.Length; i++)
			{
				base.Add(point[i]);
			}
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0000825C File Offset: 0x0000645C
		public RendererSpecial(string name, int index, float x1, float y1, float x2, float y2)
		{
			this.Name = name;
			this.SIndex = index;
			base.Add(new PointF(x1, y1));
			base.Add(new PointF(x2, y1));
			base.Add(new PointF(x2, y2));
			base.Add(new PointF(x1, y2));
		}

		// Token: 0x04000129 RID: 297
		public string Name;

		// Token: 0x0400012A RID: 298
		public int SIndex;
	}
}
