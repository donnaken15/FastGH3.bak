using System;
using System.IO;
using System.Text;

namespace ChartEdit
{
	// Token: 0x02000031 RID: 49
	internal class QbArrayWriter : IChartWriter
	{
		// Token: 0x06000172 RID: 370 RVA: 0x00007E3C File Offset: 0x0000603C
		public void Save(Chart chart, string fileName)
		{
			this._ot = new OffsetTransformer(chart);
			foreach (NoteTrack noteTrack in chart.NoteTracks)
			{
				string str = noteTrack.Name + ".array.txt";
				using (StreamWriter streamWriter = new StreamWriter(fileName + "." + str))
				{
					StringBuilder value = new QbcNoteTrack(noteTrack, this._ot).AsString();
					streamWriter.Write(value);
				}
			}
		}

		// Token: 0x040000E1 RID: 225
		private OffsetTransformer _ot;
	}
}
