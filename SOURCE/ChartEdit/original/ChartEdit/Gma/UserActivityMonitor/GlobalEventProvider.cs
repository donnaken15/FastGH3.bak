using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Gma.UserActivityMonitor
{
	// Token: 0x02000012 RID: 18
	public class GlobalEventProvider : Component
	{
		// Token: 0x14000017 RID: 23
		// (add) Token: 0x06000091 RID: 145 RVA: 0x00003AD8 File Offset: 0x00001CD8
		// (remove) Token: 0x06000092 RID: 146 RVA: 0x00003B24 File Offset: 0x00001D24
		public event KeyEventHandler KeyDown
		{
			add
			{
				if (this.m_KeyDown == null)
				{
					HookManager.KeyDown += this.HookManager_KeyDown;
				}
				this.m_KeyDown = (KeyEventHandler)Delegate.Combine(this.m_KeyDown, value);
			}
			remove
			{
				this.m_KeyDown = (KeyEventHandler)Delegate.Remove(this.m_KeyDown, value);
				if (this.m_KeyDown == null)
				{
					HookManager.KeyDown -= this.HookManager_KeyDown;
				}
			}
		}

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x06000093 RID: 147 RVA: 0x00003B70 File Offset: 0x00001D70
		// (remove) Token: 0x06000094 RID: 148 RVA: 0x00003BBC File Offset: 0x00001DBC
		public event KeyPressEventHandler KeyPress
		{
			add
			{
				if (this.m_KeyPress == null)
				{
					HookManager.KeyPress += this.HookManager_KeyPress;
				}
				this.m_KeyPress = (KeyPressEventHandler)Delegate.Combine(this.m_KeyPress, value);
			}
			remove
			{
				this.m_KeyPress = (KeyPressEventHandler)Delegate.Remove(this.m_KeyPress, value);
				if (this.m_KeyPress == null)
				{
					HookManager.KeyPress -= this.HookManager_KeyPress;
				}
			}
		}

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x06000095 RID: 149 RVA: 0x00003C08 File Offset: 0x00001E08
		// (remove) Token: 0x06000096 RID: 150 RVA: 0x00003C54 File Offset: 0x00001E54
		public event KeyEventHandler KeyUp
		{
			add
			{
				if (this.m_KeyUp == null)
				{
					HookManager.KeyUp += this.HookManager_KeyUp;
				}
				this.m_KeyUp = (KeyEventHandler)Delegate.Combine(this.m_KeyUp, value);
			}
			remove
			{
				this.m_KeyUp = (KeyEventHandler)Delegate.Remove(this.m_KeyUp, value);
				if (this.m_KeyUp == null)
				{
					HookManager.KeyUp -= this.HookManager_KeyUp;
				}
			}
		}

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x06000097 RID: 151 RVA: 0x00003C9D File Offset: 0x00001E9D
		// (remove) Token: 0x06000098 RID: 152 RVA: 0x00003CB6 File Offset: 0x00001EB6
		private event KeyEventHandler m_KeyDown;

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x06000099 RID: 153 RVA: 0x00003CCF File Offset: 0x00001ECF
		// (remove) Token: 0x0600009A RID: 154 RVA: 0x00003CE8 File Offset: 0x00001EE8
		private event KeyPressEventHandler m_KeyPress;

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x0600009B RID: 155 RVA: 0x00003D01 File Offset: 0x00001F01
		// (remove) Token: 0x0600009C RID: 156 RVA: 0x00003D1A File Offset: 0x00001F1A
		private event KeyEventHandler m_KeyUp;

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x0600009D RID: 157 RVA: 0x00003D33 File Offset: 0x00001F33
		// (remove) Token: 0x0600009E RID: 158 RVA: 0x00003D4C File Offset: 0x00001F4C
		private event MouseEventHandler m_MouseClick;

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x0600009F RID: 159 RVA: 0x00003D65 File Offset: 0x00001F65
		// (remove) Token: 0x060000A0 RID: 160 RVA: 0x00003D7E File Offset: 0x00001F7E
		private event EventHandler<MouseEventExtArgs> m_MouseClickExt;

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x060000A1 RID: 161 RVA: 0x00003D97 File Offset: 0x00001F97
		// (remove) Token: 0x060000A2 RID: 162 RVA: 0x00003DB0 File Offset: 0x00001FB0
		private event MouseEventHandler m_MouseDoubleClick;

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x060000A3 RID: 163 RVA: 0x00003DC9 File Offset: 0x00001FC9
		// (remove) Token: 0x060000A4 RID: 164 RVA: 0x00003DE2 File Offset: 0x00001FE2
		private event MouseEventHandler m_MouseDown;

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x060000A5 RID: 165 RVA: 0x00003DFB File Offset: 0x00001FFB
		// (remove) Token: 0x060000A6 RID: 166 RVA: 0x00003E14 File Offset: 0x00002014
		private event MouseEventHandler m_MouseMove;

		// Token: 0x14000022 RID: 34
		// (add) Token: 0x060000A7 RID: 167 RVA: 0x00003E2D File Offset: 0x0000202D
		// (remove) Token: 0x060000A8 RID: 168 RVA: 0x00003E46 File Offset: 0x00002046
		private event EventHandler<MouseEventExtArgs> m_MouseMoveExt;

		// Token: 0x14000023 RID: 35
		// (add) Token: 0x060000A9 RID: 169 RVA: 0x00003E5F File Offset: 0x0000205F
		// (remove) Token: 0x060000AA RID: 170 RVA: 0x00003E78 File Offset: 0x00002078
		private event MouseEventHandler m_MouseUp;

		// Token: 0x14000024 RID: 36
		// (add) Token: 0x060000AB RID: 171 RVA: 0x00003E94 File Offset: 0x00002094
		// (remove) Token: 0x060000AC RID: 172 RVA: 0x00003EE0 File Offset: 0x000020E0
		public event MouseEventHandler MouseClick
		{
			add
			{
				if (this.m_MouseClick == null)
				{
					HookManager.MouseClick += this.HookManager_MouseClick;
				}
				this.m_MouseClick = (MouseEventHandler)Delegate.Combine(this.m_MouseClick, value);
			}
			remove
			{
				this.m_MouseClick = (MouseEventHandler)Delegate.Remove(this.m_MouseClick, value);
				if (this.m_MouseClick == null)
				{
					HookManager.MouseClick -= this.HookManager_MouseClick;
				}
			}
		}

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x060000AD RID: 173 RVA: 0x00003F2C File Offset: 0x0000212C
		// (remove) Token: 0x060000AE RID: 174 RVA: 0x00003F78 File Offset: 0x00002178
		public event EventHandler<MouseEventExtArgs> MouseClickExt
		{
			add
			{
				if (this.m_MouseClickExt == null)
				{
					HookManager.MouseClickExt += this.HookManager_MouseClickExt;
				}
				this.m_MouseClickExt = (EventHandler<MouseEventExtArgs>)Delegate.Combine(this.m_MouseClickExt, value);
			}
			remove
			{
				this.m_MouseClickExt = (EventHandler<MouseEventExtArgs>)Delegate.Remove(this.m_MouseClickExt, value);
				if (this.m_MouseClickExt == null)
				{
					HookManager.MouseClickExt -= this.HookManager_MouseClickExt;
				}
			}
		}

		// Token: 0x14000026 RID: 38
		// (add) Token: 0x060000AF RID: 175 RVA: 0x00003FC4 File Offset: 0x000021C4
		// (remove) Token: 0x060000B0 RID: 176 RVA: 0x00004010 File Offset: 0x00002210
		public event MouseEventHandler MouseDoubleClick
		{
			add
			{
				if (this.m_MouseDoubleClick == null)
				{
					HookManager.MouseDoubleClick += this.HookManager_MouseDoubleClick;
				}
				this.m_MouseDoubleClick = (MouseEventHandler)Delegate.Combine(this.m_MouseDoubleClick, value);
			}
			remove
			{
				this.m_MouseDoubleClick = (MouseEventHandler)Delegate.Remove(this.m_MouseDoubleClick, value);
				if (this.m_MouseDoubleClick == null)
				{
					HookManager.MouseDoubleClick -= this.HookManager_MouseDoubleClick;
				}
			}
		}

		// Token: 0x14000027 RID: 39
		// (add) Token: 0x060000B1 RID: 177 RVA: 0x0000405C File Offset: 0x0000225C
		// (remove) Token: 0x060000B2 RID: 178 RVA: 0x000040A8 File Offset: 0x000022A8
		public event MouseEventHandler MouseDown
		{
			add
			{
				if (this.m_MouseDown == null)
				{
					HookManager.MouseDown += this.HookManager_MouseDown;
				}
				this.m_MouseDown = (MouseEventHandler)Delegate.Combine(this.m_MouseDown, value);
			}
			remove
			{
				this.m_MouseDown = (MouseEventHandler)Delegate.Remove(this.m_MouseDown, value);
				if (this.m_MouseDown == null)
				{
					HookManager.MouseDown -= this.HookManager_MouseDown;
				}
			}
		}

		// Token: 0x14000028 RID: 40
		// (add) Token: 0x060000B3 RID: 179 RVA: 0x000040F4 File Offset: 0x000022F4
		// (remove) Token: 0x060000B4 RID: 180 RVA: 0x00004140 File Offset: 0x00002340
		public event MouseEventHandler MouseMove
		{
			add
			{
				if (this.m_MouseMove == null)
				{
					HookManager.MouseMove += this.HookManager_MouseMove;
				}
				this.m_MouseMove = (MouseEventHandler)Delegate.Combine(this.m_MouseMove, value);
			}
			remove
			{
				this.m_MouseMove = (MouseEventHandler)Delegate.Remove(this.m_MouseMove, value);
				if (this.m_MouseMove == null)
				{
					HookManager.MouseMove -= this.HookManager_MouseMove;
				}
			}
		}

		// Token: 0x14000029 RID: 41
		// (add) Token: 0x060000B5 RID: 181 RVA: 0x0000418C File Offset: 0x0000238C
		// (remove) Token: 0x060000B6 RID: 182 RVA: 0x000041D8 File Offset: 0x000023D8
		public event EventHandler<MouseEventExtArgs> MouseMoveExt
		{
			add
			{
				if (this.m_MouseMoveExt == null)
				{
					HookManager.MouseMoveExt += this.HookManager_MouseMoveExt;
				}
				this.m_MouseMoveExt = (EventHandler<MouseEventExtArgs>)Delegate.Combine(this.m_MouseMoveExt, value);
			}
			remove
			{
				this.m_MouseMoveExt = (EventHandler<MouseEventExtArgs>)Delegate.Remove(this.m_MouseMoveExt, value);
				if (this.m_MouseMoveExt == null)
				{
					HookManager.MouseMoveExt -= this.HookManager_MouseMoveExt;
				}
			}
		}

		// Token: 0x1400002A RID: 42
		// (add) Token: 0x060000B7 RID: 183 RVA: 0x00004224 File Offset: 0x00002424
		// (remove) Token: 0x060000B8 RID: 184 RVA: 0x00004270 File Offset: 0x00002470
		public event MouseEventHandler MouseUp
		{
			add
			{
				if (this.m_MouseUp == null)
				{
					HookManager.MouseUp += this.HookManager_MouseUp;
				}
				this.m_MouseUp = (MouseEventHandler)Delegate.Combine(this.m_MouseUp, value);
			}
			remove
			{
				this.m_MouseUp = (MouseEventHandler)Delegate.Remove(this.m_MouseUp, value);
				if (this.m_MouseUp == null)
				{
					HookManager.MouseUp -= this.HookManager_MouseUp;
				}
			}
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000042B9 File Offset: 0x000024B9
		private void HookManager_KeyDown(object sender, KeyEventArgs e)
		{
			this.m_KeyDown(this, e);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000042CC File Offset: 0x000024CC
		private void HookManager_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (this.m_KeyPress != null)
			{
				this.m_KeyPress(this, e);
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000042F8 File Offset: 0x000024F8
		private void HookManager_KeyUp(object sender, KeyEventArgs e)
		{
			if (this.m_KeyUp != null)
			{
				this.m_KeyUp(this, e);
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00004324 File Offset: 0x00002524
		private void HookManager_MouseClick(object sender, MouseEventArgs e)
		{
			if (this.m_MouseClick != null)
			{
				this.m_MouseClick(this, e);
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00004350 File Offset: 0x00002550
		private void HookManager_MouseClickExt(object sender, MouseEventExtArgs e)
		{
			if (this.m_MouseClickExt != null)
			{
				this.m_MouseClickExt(this, e);
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000437C File Offset: 0x0000257C
		private void HookManager_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.m_MouseDoubleClick != null)
			{
				this.m_MouseDoubleClick(this, e);
			}
		}

		// Token: 0x060000BF RID: 191 RVA: 0x000043A8 File Offset: 0x000025A8
		private void HookManager_MouseDown(object sender, MouseEventArgs e)
		{
			if (this.m_MouseDown != null)
			{
				this.m_MouseDown(this, e);
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x000043D4 File Offset: 0x000025D4
		private void HookManager_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.m_MouseMove != null)
			{
				this.m_MouseMove(this, e);
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00004400 File Offset: 0x00002600
		private void HookManager_MouseMoveExt(object sender, MouseEventExtArgs e)
		{
			if (this.m_MouseMoveExt != null)
			{
				this.m_MouseMoveExt(this, e);
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000442C File Offset: 0x0000262C
		private void HookManager_MouseUp(object sender, MouseEventArgs e)
		{
			if (this.m_MouseUp != null)
			{
				this.m_MouseUp(this, e);
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x00004458 File Offset: 0x00002658
		protected override bool CanRaiseEvents
		{
			get
			{
				return true;
			}
		}
	}
}
