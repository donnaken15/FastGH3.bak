using System;
using System.Windows.Forms;

namespace ChartEdit
{
	// Token: 0x0200000D RID: 13
	public class SectionTreeNode : TreeNode
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000081 RID: 129 RVA: 0x000036B8 File Offset: 0x000018B8
		// (set) Token: 0x06000082 RID: 130 RVA: 0x000036CF File Offset: 0x000018CF
		public EventsSectionEntry EventSection { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000083 RID: 131 RVA: 0x000036D8 File Offset: 0x000018D8
		// (set) Token: 0x06000084 RID: 132 RVA: 0x000036EF File Offset: 0x000018EF
		public Chart RootChart { get; set; }
	}
}
