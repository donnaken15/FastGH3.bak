using System;
using System.Windows.Forms;

namespace ChartEdit
{
	// Token: 0x02000019 RID: 25
	public class TrackTreeNode : TreeNode
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x00004BF4 File Offset: 0x00002DF4
		// (set) Token: 0x060000D5 RID: 213 RVA: 0x00004C0B File Offset: 0x00002E0B
		public Chart RootChart { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x00004C14 File Offset: 0x00002E14
		// (set) Token: 0x060000D7 RID: 215 RVA: 0x00004C2B File Offset: 0x00002E2B
		public NoteTrack Track { get; set; }
	}
}
