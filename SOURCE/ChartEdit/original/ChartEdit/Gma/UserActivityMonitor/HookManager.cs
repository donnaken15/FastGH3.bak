using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Gma.UserActivityMonitor
{
	// Token: 0x02000006 RID: 6
	public static class HookManager
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000037 RID: 55 RVA: 0x0000263B File Offset: 0x0000083B
		// (remove) Token: 0x06000038 RID: 56 RVA: 0x00002659 File Offset: 0x00000859
		public static event KeyEventHandler KeyDown
		{
			add
			{
				HookManager.EnsureSubscribedToGlobalKeyboardEvents();
				HookManager.s_KeyDown = (KeyEventHandler)Delegate.Combine(HookManager.s_KeyDown, value);
			}
			remove
			{
				HookManager.s_KeyDown = (KeyEventHandler)Delegate.Remove(HookManager.s_KeyDown, value);
				HookManager.TryUnsubscribeFromGlobalKeyboardEvents();
			}
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000039 RID: 57 RVA: 0x00002677 File Offset: 0x00000877
		// (remove) Token: 0x0600003A RID: 58 RVA: 0x00002695 File Offset: 0x00000895
		public static event KeyPressEventHandler KeyPress
		{
			add
			{
				HookManager.EnsureSubscribedToGlobalKeyboardEvents();
				HookManager.s_KeyPress = (KeyPressEventHandler)Delegate.Combine(HookManager.s_KeyPress, value);
			}
			remove
			{
				HookManager.s_KeyPress = (KeyPressEventHandler)Delegate.Remove(HookManager.s_KeyPress, value);
				HookManager.TryUnsubscribeFromGlobalKeyboardEvents();
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600003B RID: 59 RVA: 0x000026B3 File Offset: 0x000008B3
		// (remove) Token: 0x0600003C RID: 60 RVA: 0x000026D1 File Offset: 0x000008D1
		public static event KeyEventHandler KeyUp
		{
			add
			{
				HookManager.EnsureSubscribedToGlobalKeyboardEvents();
				HookManager.s_KeyUp = (KeyEventHandler)Delegate.Combine(HookManager.s_KeyUp, value);
			}
			remove
			{
				HookManager.s_KeyUp = (KeyEventHandler)Delegate.Remove(HookManager.s_KeyUp, value);
				HookManager.TryUnsubscribeFromGlobalKeyboardEvents();
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600003D RID: 61 RVA: 0x000026EF File Offset: 0x000008EF
		// (remove) Token: 0x0600003E RID: 62 RVA: 0x0000270D File Offset: 0x0000090D
		public static event MouseEventHandler MouseClick
		{
			add
			{
				HookManager.EnsureSubscribedToGlobalMouseEvents();
				HookManager.s_MouseClick = (MouseEventHandler)Delegate.Combine(HookManager.s_MouseClick, value);
			}
			remove
			{
				HookManager.s_MouseClick = (MouseEventHandler)Delegate.Remove(HookManager.s_MouseClick, value);
				HookManager.TryUnsubscribeFromGlobalMouseEvents();
			}
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600003F RID: 63 RVA: 0x0000272B File Offset: 0x0000092B
		// (remove) Token: 0x06000040 RID: 64 RVA: 0x00002749 File Offset: 0x00000949
		public static event EventHandler<MouseEventExtArgs> MouseClickExt
		{
			add
			{
				HookManager.EnsureSubscribedToGlobalMouseEvents();
				HookManager.s_MouseClickExt = (EventHandler<MouseEventExtArgs>)Delegate.Combine(HookManager.s_MouseClickExt, value);
			}
			remove
			{
				HookManager.s_MouseClickExt = (EventHandler<MouseEventExtArgs>)Delegate.Remove(HookManager.s_MouseClickExt, value);
				HookManager.TryUnsubscribeFromGlobalMouseEvents();
			}
		}

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000041 RID: 65 RVA: 0x00002768 File Offset: 0x00000968
		// (remove) Token: 0x06000042 RID: 66 RVA: 0x000027F0 File Offset: 0x000009F0
		public static event MouseEventHandler MouseDoubleClick
		{
			add
			{
				HookManager.EnsureSubscribedToGlobalMouseEvents();
				if (HookManager.s_MouseDoubleClick == null)
				{
					Timer timer = new Timer
					{
						Interval = HookManager.GetDoubleClickTime(),
						Enabled = false
					};
					HookManager.s_DoubleClickTimer = timer;
					HookManager.s_DoubleClickTimer.Tick += HookManager.DoubleClickTimeElapsed;
					HookManager.MouseUp += HookManager.OnMouseUp;
				}
				HookManager.s_MouseDoubleClick = (MouseEventHandler)Delegate.Combine(HookManager.s_MouseDoubleClick, value);
			}
			remove
			{
				if (HookManager.s_MouseDoubleClick != null)
				{
					HookManager.s_MouseDoubleClick = (MouseEventHandler)Delegate.Remove(HookManager.s_MouseDoubleClick, value);
					if (HookManager.s_MouseDoubleClick == null)
					{
						HookManager.MouseUp -= HookManager.OnMouseUp;
						HookManager.s_DoubleClickTimer.Tick -= HookManager.DoubleClickTimeElapsed;
						HookManager.s_DoubleClickTimer = null;
					}
				}
				HookManager.TryUnsubscribeFromGlobalMouseEvents();
			}
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000043 RID: 67 RVA: 0x00002867 File Offset: 0x00000A67
		// (remove) Token: 0x06000044 RID: 68 RVA: 0x00002885 File Offset: 0x00000A85
		public static event MouseEventHandler MouseDown
		{
			add
			{
				HookManager.EnsureSubscribedToGlobalMouseEvents();
				HookManager.s_MouseDown = (MouseEventHandler)Delegate.Combine(HookManager.s_MouseDown, value);
			}
			remove
			{
				HookManager.s_MouseDown = (MouseEventHandler)Delegate.Remove(HookManager.s_MouseDown, value);
				HookManager.TryUnsubscribeFromGlobalMouseEvents();
			}
		}

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000045 RID: 69 RVA: 0x000028A3 File Offset: 0x00000AA3
		// (remove) Token: 0x06000046 RID: 70 RVA: 0x000028C1 File Offset: 0x00000AC1
		public static event MouseEventHandler MouseMove
		{
			add
			{
				HookManager.EnsureSubscribedToGlobalMouseEvents();
				HookManager.s_MouseMove = (MouseEventHandler)Delegate.Combine(HookManager.s_MouseMove, value);
			}
			remove
			{
				HookManager.s_MouseMove = (MouseEventHandler)Delegate.Remove(HookManager.s_MouseMove, value);
				HookManager.TryUnsubscribeFromGlobalMouseEvents();
			}
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000047 RID: 71 RVA: 0x000028DF File Offset: 0x00000ADF
		// (remove) Token: 0x06000048 RID: 72 RVA: 0x000028FD File Offset: 0x00000AFD
		public static event EventHandler<MouseEventExtArgs> MouseMoveExt
		{
			add
			{
				HookManager.EnsureSubscribedToGlobalMouseEvents();
				HookManager.s_MouseMoveExt = (EventHandler<MouseEventExtArgs>)Delegate.Combine(HookManager.s_MouseMoveExt, value);
			}
			remove
			{
				HookManager.s_MouseMoveExt = (EventHandler<MouseEventExtArgs>)Delegate.Remove(HookManager.s_MouseMoveExt, value);
				HookManager.TryUnsubscribeFromGlobalMouseEvents();
			}
		}

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000049 RID: 73 RVA: 0x0000291B File Offset: 0x00000B1B
		// (remove) Token: 0x0600004A RID: 74 RVA: 0x00002939 File Offset: 0x00000B39
		public static event MouseEventHandler MouseUp
		{
			add
			{
				HookManager.EnsureSubscribedToGlobalMouseEvents();
				HookManager.s_MouseUp = (MouseEventHandler)Delegate.Combine(HookManager.s_MouseUp, value);
			}
			remove
			{
				HookManager.s_MouseUp = (MouseEventHandler)Delegate.Remove(HookManager.s_MouseUp, value);
				HookManager.TryUnsubscribeFromGlobalMouseEvents();
			}
		}

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x0600004B RID: 75 RVA: 0x00002957 File Offset: 0x00000B57
		// (remove) Token: 0x0600004C RID: 76 RVA: 0x00002975 File Offset: 0x00000B75
		public static event MouseEventHandler MouseWheel
		{
			add
			{
				HookManager.EnsureSubscribedToGlobalMouseEvents();
				HookManager.s_MouseWheel = (MouseEventHandler)Delegate.Combine(HookManager.s_MouseWheel, value);
			}
			remove
			{
				HookManager.s_MouseWheel = (MouseEventHandler)Delegate.Remove(HookManager.s_MouseWheel, value);
				HookManager.TryUnsubscribeFromGlobalMouseEvents();
			}
		}

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x0600004D RID: 77 RVA: 0x00002993 File Offset: 0x00000B93
		// (remove) Token: 0x0600004E RID: 78 RVA: 0x000029AA File Offset: 0x00000BAA
		private static event KeyEventHandler s_KeyDown;

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x0600004F RID: 79 RVA: 0x000029C1 File Offset: 0x00000BC1
		// (remove) Token: 0x06000050 RID: 80 RVA: 0x000029D8 File Offset: 0x00000BD8
		private static event KeyPressEventHandler s_KeyPress;

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x06000051 RID: 81 RVA: 0x000029EF File Offset: 0x00000BEF
		// (remove) Token: 0x06000052 RID: 82 RVA: 0x00002A06 File Offset: 0x00000C06
		private static event KeyEventHandler s_KeyUp;

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x06000053 RID: 83 RVA: 0x00002A1D File Offset: 0x00000C1D
		// (remove) Token: 0x06000054 RID: 84 RVA: 0x00002A34 File Offset: 0x00000C34
		private static event MouseEventHandler s_MouseClick;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x06000055 RID: 85 RVA: 0x00002A4B File Offset: 0x00000C4B
		// (remove) Token: 0x06000056 RID: 86 RVA: 0x00002A62 File Offset: 0x00000C62
		private static event EventHandler<MouseEventExtArgs> s_MouseClickExt;

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x06000057 RID: 87 RVA: 0x00002A79 File Offset: 0x00000C79
		// (remove) Token: 0x06000058 RID: 88 RVA: 0x00002A90 File Offset: 0x00000C90
		private static event MouseEventHandler s_MouseDoubleClick;

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x06000059 RID: 89 RVA: 0x00002AA7 File Offset: 0x00000CA7
		// (remove) Token: 0x0600005A RID: 90 RVA: 0x00002ABE File Offset: 0x00000CBE
		private static event MouseEventHandler s_MouseDown;

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x0600005B RID: 91 RVA: 0x00002AD5 File Offset: 0x00000CD5
		// (remove) Token: 0x0600005C RID: 92 RVA: 0x00002AEC File Offset: 0x00000CEC
		private static event MouseEventHandler s_MouseMove;

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x0600005D RID: 93 RVA: 0x00002B03 File Offset: 0x00000D03
		// (remove) Token: 0x0600005E RID: 94 RVA: 0x00002B1A File Offset: 0x00000D1A
		private static event EventHandler<MouseEventExtArgs> s_MouseMoveExt;

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x0600005F RID: 95 RVA: 0x00002B31 File Offset: 0x00000D31
		// (remove) Token: 0x06000060 RID: 96 RVA: 0x00002B48 File Offset: 0x00000D48
		private static event MouseEventHandler s_MouseUp;

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x06000061 RID: 97 RVA: 0x00002B5F File Offset: 0x00000D5F
		// (remove) Token: 0x06000062 RID: 98 RVA: 0x00002B76 File Offset: 0x00000D76
		private static event MouseEventHandler s_MouseWheel;

		// Token: 0x06000063 RID: 99
		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
		private static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);

		// Token: 0x06000064 RID: 100 RVA: 0x00002B8D File Offset: 0x00000D8D
		private static void DoubleClickTimeElapsed(object sender, EventArgs e)
		{
			HookManager.s_DoubleClickTimer.Enabled = false;
			HookManager.s_PrevClickedButton = MouseButtons.None;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00002BA4 File Offset: 0x00000DA4
		private static void EnsureSubscribedToGlobalKeyboardEvents()
		{
			if (HookManager.s_KeyboardHookHandle == 0)
			{
				HookManager.s_KeyboardDelegate = new HookManager.HookProc(HookManager.KeyboardHookProc);
				HookManager.s_KeyboardHookHandle = HookManager.SetWindowsHookEx(13, HookManager.s_KeyboardDelegate, IntPtr.Zero, 0);
				if (HookManager.s_KeyboardHookHandle == 0)
				{
					throw new Win32Exception(Marshal.GetLastWin32Error());
				}
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00002C08 File Offset: 0x00000E08
		private static void EnsureSubscribedToGlobalMouseEvents()
		{
			if (HookManager.s_MouseHookHandle == 0)
			{
				HookManager.s_MouseDelegate = new HookManager.HookProc(HookManager.MouseHookProc);
				HookManager.s_MouseHookHandle = HookManager.SetWindowsHookEx(14, HookManager.s_MouseDelegate, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
				if (HookManager.s_MouseHookHandle == 0)
				{
					throw new Win32Exception(Marshal.GetLastWin32Error());
				}
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00002C78 File Offset: 0x00000E78
		private static void ForceUnsunscribeFromGlobalKeyboardEvents()
		{
			if (HookManager.s_KeyboardHookHandle != 0)
			{
				int num = HookManager.UnhookWindowsHookEx(HookManager.s_KeyboardHookHandle);
				HookManager.s_KeyboardHookHandle = 0;
				HookManager.s_KeyboardDelegate = null;
				if (num == 0)
				{
					throw new Win32Exception(Marshal.GetLastWin32Error());
				}
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00002CC4 File Offset: 0x00000EC4
		private static void ForceUnsunscribeFromGlobalMouseEvents()
		{
			if (HookManager.s_MouseHookHandle != 0)
			{
				int num = HookManager.UnhookWindowsHookEx(HookManager.s_MouseHookHandle);
				HookManager.s_MouseHookHandle = 0;
				HookManager.s_MouseDelegate = null;
				if (num == 0)
				{
					throw new Win32Exception(Marshal.GetLastWin32Error());
				}
			}
		}

		// Token: 0x06000069 RID: 105
		[DllImport("user32")]
		public static extern int GetDoubleClickTime();

		// Token: 0x0600006A RID: 106
		[DllImport("user32")]
		private static extern int GetKeyboardState(byte[] pbKeyState);

		// Token: 0x0600006B RID: 107
		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
		private static extern short GetKeyState(int vKey);

		// Token: 0x0600006C RID: 108 RVA: 0x00002D10 File Offset: 0x00000F10
		private static int KeyboardHookProc(int nCode, int wParam, IntPtr lParam)
		{
			bool flag = false;
			if (nCode >= 0)
			{
				HookManager.KeyboardHookStruct keyboardHookStruct = (HookManager.KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(HookManager.KeyboardHookStruct));
				if (HookManager.s_KeyDown != null && (wParam == 256 || wParam == 260))
				{
					KeyEventArgs keyEventArgs = new KeyEventArgs((Keys)keyboardHookStruct.VirtualKeyCode);
					HookManager.s_KeyDown(null, keyEventArgs);
					flag = keyEventArgs.Handled;
				}
				if (HookManager.s_KeyPress != null && wParam == 256)
				{
					bool flag2 = (HookManager.GetKeyState(16) & 128) == 128;
					bool flag3 = HookManager.GetKeyState(20) != 0;
					byte[] array = new byte[256];
					HookManager.GetKeyboardState(array);
					byte[] array2 = new byte[2];
					if (HookManager.ToAscii(keyboardHookStruct.VirtualKeyCode, keyboardHookStruct.ScanCode, array, array2, keyboardHookStruct.Flags) == 1)
					{
						char c = (char)array2[0];
						if ((flag3 ^ flag2) && char.IsLetter(c))
						{
							c = char.ToUpper(c);
						}
						KeyPressEventArgs keyPressEventArgs = new KeyPressEventArgs(c);
						HookManager.s_KeyPress(null, keyPressEventArgs);
						flag = (flag || keyPressEventArgs.Handled);
					}
				}
				if (HookManager.s_KeyUp != null && (wParam == 257 || wParam == 261))
				{
					KeyEventArgs keyEventArgs2 = new KeyEventArgs((Keys)keyboardHookStruct.VirtualKeyCode);
					HookManager.s_KeyUp(null, keyEventArgs2);
					flag = (flag || keyEventArgs2.Handled);
				}
			}
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				result = HookManager.CallNextHookEx(HookManager.s_KeyboardHookHandle, nCode, wParam, lParam);
			}
			return result;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00002EE0 File Offset: 0x000010E0
		private static int MouseHookProc(int nCode, int wParam, IntPtr lParam)
		{
			if (nCode >= 0)
			{
				HookManager.MouseLLHookStruct mouseLLHookStruct = (HookManager.MouseLLHookStruct)Marshal.PtrToStructure(lParam, typeof(HookManager.MouseLLHookStruct));
				MouseButtons buttons = MouseButtons.None;
				short num = 0;
				int num2 = 0;
				bool flag = false;
				bool flag2 = false;
				switch (wParam)
				{
				case 513:
					flag = true;
					buttons = MouseButtons.Left;
					num2 = 1;
					break;
				case 514:
					flag2 = true;
					buttons = MouseButtons.Left;
					num2 = 1;
					break;
				case 515:
					buttons = MouseButtons.Left;
					num2 = 2;
					break;
				case 516:
					flag = true;
					buttons = MouseButtons.Right;
					num2 = 1;
					break;
				case 517:
					flag2 = true;
					buttons = MouseButtons.Right;
					num2 = 1;
					break;
				case 518:
					buttons = MouseButtons.Right;
					num2 = 2;
					break;
				case 522:
					num = (short)(mouseLLHookStruct.MouseData >> 16 & 65535);
					break;
				}
				MouseEventExtArgs mouseEventExtArgs = new MouseEventExtArgs(buttons, num2, mouseLLHookStruct.Point.X, mouseLLHookStruct.Point.Y, (int)num);
				if (HookManager.s_MouseUp != null && flag2)
				{
					HookManager.s_MouseUp(null, mouseEventExtArgs);
				}
				if (HookManager.s_MouseDown != null && flag)
				{
					HookManager.s_MouseDown(null, mouseEventExtArgs);
				}
				if (HookManager.s_MouseClick != null && num2 > 0)
				{
					HookManager.s_MouseClick(null, mouseEventExtArgs);
				}
				if (HookManager.s_MouseClickExt != null && num2 > 0)
				{
					HookManager.s_MouseClickExt(null, mouseEventExtArgs);
				}
				if (HookManager.s_MouseDoubleClick != null && num2 == 2)
				{
					HookManager.s_MouseDoubleClick(null, mouseEventExtArgs);
				}
				if (HookManager.s_MouseWheel != null && num != 0)
				{
					HookManager.s_MouseWheel(null, mouseEventExtArgs);
				}
				if ((HookManager.s_MouseMove != null || HookManager.s_MouseMoveExt != null) && (HookManager.m_OldX != mouseLLHookStruct.Point.X || HookManager.m_OldY != mouseLLHookStruct.Point.Y))
				{
					HookManager.m_OldX = mouseLLHookStruct.Point.X;
					HookManager.m_OldY = mouseLLHookStruct.Point.Y;
					if (HookManager.s_MouseMove != null)
					{
						HookManager.s_MouseMove(null, mouseEventExtArgs);
					}
					if (HookManager.s_MouseMoveExt != null)
					{
						HookManager.s_MouseMoveExt(null, mouseEventExtArgs);
					}
				}
				if (mouseEventExtArgs.Handled)
				{
					return -1;
				}
			}
			return HookManager.CallNextHookEx(HookManager.s_MouseHookHandle, nCode, wParam, lParam);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003184 File Offset: 0x00001384
		private static void OnMouseUp(object sender, MouseEventArgs e)
		{
			if (e.Clicks >= 1)
			{
				if (e.Button.Equals(HookManager.s_PrevClickedButton))
				{
					if (HookManager.s_MouseDoubleClick != null)
					{
						HookManager.s_MouseDoubleClick(null, e);
					}
					HookManager.s_DoubleClickTimer.Enabled = false;
					HookManager.s_PrevClickedButton = MouseButtons.None;
				}
				else
				{
					HookManager.s_DoubleClickTimer.Enabled = true;
					HookManager.s_PrevClickedButton = e.Button;
				}
			}
		}

		// Token: 0x0600006F RID: 111
		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int SetWindowsHookEx(int idHook, HookManager.HookProc lpfn, IntPtr hMod, int dwThreadId);

		// Token: 0x06000070 RID: 112
		[DllImport("user32")]
		private static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);

		// Token: 0x06000071 RID: 113 RVA: 0x0000320C File Offset: 0x0000140C
		private static void TryUnsubscribeFromGlobalKeyboardEvents()
		{
			if (HookManager.s_KeyDown == null && HookManager.s_KeyUp == null && HookManager.s_KeyPress == null)
			{
				HookManager.ForceUnsunscribeFromGlobalKeyboardEvents();
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003244 File Offset: 0x00001444
		private static void TryUnsubscribeFromGlobalMouseEvents()
		{
			if (HookManager.s_MouseClick == null && HookManager.s_MouseDown == null && HookManager.s_MouseMove == null && HookManager.s_MouseUp == null && HookManager.s_MouseClickExt == null && HookManager.s_MouseMoveExt == null && HookManager.s_MouseWheel == null)
			{
				HookManager.ForceUnsunscribeFromGlobalMouseEvents();
			}
		}

		// Token: 0x06000073 RID: 115
		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int UnhookWindowsHookEx(int idHook);

		// Token: 0x04000022 RID: 34
		private const byte VK_CAPITAL = 20;

		// Token: 0x04000023 RID: 35
		private const byte VK_NUMLOCK = 144;

		// Token: 0x04000024 RID: 36
		private const byte VK_SHIFT = 16;

		// Token: 0x04000025 RID: 37
		private const int WH_KEYBOARD = 2;

		// Token: 0x04000026 RID: 38
		private const int WH_KEYBOARD_LL = 13;

		// Token: 0x04000027 RID: 39
		private const int WH_MOUSE = 7;

		// Token: 0x04000028 RID: 40
		private const int WH_MOUSE_LL = 14;

		// Token: 0x04000029 RID: 41
		private const int WM_KEYDOWN = 256;

		// Token: 0x0400002A RID: 42
		private const int WM_KEYUP = 257;

		// Token: 0x0400002B RID: 43
		private const int WM_LBUTTONDBLCLK = 515;

		// Token: 0x0400002C RID: 44
		private const int WM_LBUTTONDOWN = 513;

		// Token: 0x0400002D RID: 45
		private const int WM_LBUTTONUP = 514;

		// Token: 0x0400002E RID: 46
		private const int WM_MBUTTONDBLCLK = 521;

		// Token: 0x0400002F RID: 47
		private const int WM_MBUTTONDOWN = 519;

		// Token: 0x04000030 RID: 48
		private const int WM_MBUTTONUP = 520;

		// Token: 0x04000031 RID: 49
		private const int WM_MOUSEMOVE = 512;

		// Token: 0x04000032 RID: 50
		private const int WM_MOUSEWHEEL = 522;

		// Token: 0x04000033 RID: 51
		private const int WM_RBUTTONDBLCLK = 518;

		// Token: 0x04000034 RID: 52
		private const int WM_RBUTTONDOWN = 516;

		// Token: 0x04000035 RID: 53
		private const int WM_RBUTTONUP = 517;

		// Token: 0x04000036 RID: 54
		private const int WM_SYSKEYDOWN = 260;

		// Token: 0x04000037 RID: 55
		private const int WM_SYSKEYUP = 261;

		// Token: 0x04000038 RID: 56
		private static int m_OldX;

		// Token: 0x04000039 RID: 57
		private static int m_OldY;

		// Token: 0x0400003A RID: 58
		private static Timer s_DoubleClickTimer;

		// Token: 0x0400003B RID: 59
		private static HookManager.HookProc s_KeyboardDelegate;

		// Token: 0x0400003C RID: 60
		private static int s_KeyboardHookHandle;

		// Token: 0x0400003D RID: 61
		private static HookManager.HookProc s_MouseDelegate;

		// Token: 0x0400003E RID: 62
		private static int s_MouseHookHandle;

		// Token: 0x0400003F RID: 63
		private static MouseButtons s_PrevClickedButton;

		// Token: 0x02000007 RID: 7
		// (Invoke) Token: 0x06000075 RID: 117
		private delegate int HookProc(int nCode, int wParam, IntPtr lParam);

		// Token: 0x02000008 RID: 8
		private struct KeyboardHookStruct
		{
			// Token: 0x0400004B RID: 75
			public int VirtualKeyCode;

			// Token: 0x0400004C RID: 76
			public int ScanCode;

			// Token: 0x0400004D RID: 77
			public int Flags;

			// Token: 0x0400004E RID: 78
			public int Time;

			// Token: 0x0400004F RID: 79
			public int ExtraInfo;
		}

		// Token: 0x02000009 RID: 9
		private struct MouseLLHookStruct
		{
			// Token: 0x04000050 RID: 80
			public HookManager.Point Point;

			// Token: 0x04000051 RID: 81
			public int MouseData;

			// Token: 0x04000052 RID: 82
			public int Flags;

			// Token: 0x04000053 RID: 83
			public int Time;

			// Token: 0x04000054 RID: 84
			public int ExtraInfo;
		}

		// Token: 0x0200000A RID: 10
		private struct Point
		{
			// Token: 0x04000055 RID: 85
			public int X;

			// Token: 0x04000056 RID: 86
			public int Y;
		}
	}
}
