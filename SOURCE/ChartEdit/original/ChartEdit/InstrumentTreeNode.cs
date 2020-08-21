using System;
using System.Windows.Forms;

namespace ChartEdit
{
	// Token: 0x02000024 RID: 36
	public class InstrumentTreeNode : TreeNode
	{
		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00006744 File Offset: 0x00004944
		// (set) Token: 0x06000128 RID: 296 RVA: 0x0000675B File Offset: 0x0000495B
		public string Instrument { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000129 RID: 297 RVA: 0x00006764 File Offset: 0x00004964
		// (set) Token: 0x0600012A RID: 298 RVA: 0x0000677B File Offset: 0x0000497B
		public string RealInstrument { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600012B RID: 299 RVA: 0x00006784 File Offset: 0x00004984
		// (set) Token: 0x0600012C RID: 300 RVA: 0x0000679B File Offset: 0x0000499B
		public Chart RootChart { get; set; }
	}
}
