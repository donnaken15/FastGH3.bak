using System;
using System.Windows.Forms;

namespace Gma.UserActivityMonitor
{
	// Token: 0x0200003B RID: 59
	public class MouseEventExtArgs : MouseEventArgs
	{
		// Token: 0x06000186 RID: 390 RVA: 0x000081AF File Offset: 0x000063AF
		internal MouseEventExtArgs(MouseEventArgs e) : base(e.Button, e.Clicks, e.X, e.Y, e.Delta)
		{
		}

		// Token: 0x06000187 RID: 391 RVA: 0x000081D8 File Offset: 0x000063D8
		public MouseEventExtArgs(MouseButtons buttons, int clicks, int x, int y, int delta) : base(buttons, clicks, x, y, delta)
		{
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000188 RID: 392 RVA: 0x000081EC File Offset: 0x000063EC
		// (set) Token: 0x06000189 RID: 393 RVA: 0x00008204 File Offset: 0x00006404
		public bool Handled
		{
			get
			{
				return this.m_Handled;
			}
			set
			{
				this.m_Handled = value;
			}
		}

		// Token: 0x04000128 RID: 296
		private bool m_Handled;
	}
}
