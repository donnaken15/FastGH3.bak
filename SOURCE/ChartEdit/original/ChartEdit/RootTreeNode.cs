using System;
using System.Windows.Forms;

namespace ChartEdit
{
	// Token: 0x02000016 RID: 22
	public class RootTreeNode : TreeNode
	{
		// Token: 0x060000CA RID: 202 RVA: 0x000045BC File Offset: 0x000027BC
		public RootTreeNode(string text)
		{
			base.Text = text;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x000045D0 File Offset: 0x000027D0
		public InstrumentTreeNode FindOrCreateInstrument(string ins)
		{
			foreach (object obj in base.Nodes)
			{
				InstrumentTreeNode instrumentTreeNode = (InstrumentTreeNode)obj;
				if (instrumentTreeNode.RealInstrument == ins)
				{
					return instrumentTreeNode;
				}
			}
			InstrumentTreeNode instrumentTreeNode2 = new InstrumentTreeNode
			{
				Instrument = ins,
				RealInstrument = ins,
				Text = Globals.Instance.ReplaceKey(ins)
			};
			base.Nodes.Add(instrumentTreeNode2);
			return instrumentTreeNode2;
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000CC RID: 204 RVA: 0x00004694 File Offset: 0x00002894
		// (set) Token: 0x060000CD RID: 205 RVA: 0x000046AB File Offset: 0x000028AB
		public Chart RootChart { get; set; }
	}
}
