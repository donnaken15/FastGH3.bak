using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ChartEdit.Properties
{
	// Token: 0x0200003A RID: 58
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x0600017B RID: 379 RVA: 0x00008004 File Offset: 0x00006204
		internal Resources()
		{
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600017C RID: 380 RVA: 0x00008010 File Offset: 0x00006210
		// (set) Token: 0x0600017D RID: 381 RVA: 0x00008027 File Offset: 0x00006227
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600017E RID: 382 RVA: 0x00008030 File Offset: 0x00006230
		internal static Bitmap play_sm
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("play_sm", Resources.resourceCulture);
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600017F RID: 383 RVA: 0x0000805C File Offset: 0x0000625C
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Resources.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("ChartEdit.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000180 RID: 384 RVA: 0x000080A8 File Offset: 0x000062A8
		internal static Bitmap tool_arpeggiator
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("tool_arpeggiator", Resources.resourceCulture);
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000181 RID: 385 RVA: 0x000080D4 File Offset: 0x000062D4
		internal static Bitmap tool_note
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("tool_note", Resources.resourceCulture);
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000182 RID: 386 RVA: 0x00008100 File Offset: 0x00006300
		internal static Bitmap tool_pattern
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("tool_pattern", Resources.resourceCulture);
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000183 RID: 387 RVA: 0x0000812C File Offset: 0x0000632C
		internal static Bitmap tool_pointer
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("tool_pointer", Resources.resourceCulture);
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000184 RID: 388 RVA: 0x00008158 File Offset: 0x00006358
		internal static Bitmap tool_selection
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("tool_selection", Resources.resourceCulture);
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000185 RID: 389 RVA: 0x00008184 File Offset: 0x00006384
		internal static Bitmap tool_tremolo
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("tool_tremolo", Resources.resourceCulture);
			}
		}

		// Token: 0x04000126 RID: 294
		private static CultureInfo resourceCulture;

		// Token: 0x04000127 RID: 295
		private static ResourceManager resourceMan;
	}
}
