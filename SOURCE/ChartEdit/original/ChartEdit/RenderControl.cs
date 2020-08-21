using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChartEdit
{
	// Token: 0x0200001E RID: 30
	public class RenderControl : Panel
	{
		// Token: 0x06000110 RID: 272 RVA: 0x000059CB File Offset: 0x00003BCB
		public RenderControl()
		{
			base.SetStyle(ControlStyles.UserPaint, true);
			base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000059F9 File Offset: 0x00003BF9
		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.Clear(Color.Black);
			e.Graphics.DrawLine(Pens.Black, 0, 0, 0, 0);
		}
	}
}
