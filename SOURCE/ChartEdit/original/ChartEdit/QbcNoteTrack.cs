using System;
using System.Collections.Generic;
using System.Text;

namespace ChartEdit
{
	// Token: 0x0200002C RID: 44
	internal class QbcNoteTrack : List<QbcNote>
	{
		// Token: 0x0600015D RID: 349 RVA: 0x000079CC File Offset: 0x00005BCC
		public QbcNoteTrack(NoteTrack track, OffsetTransformer ot)
		{
			this._ot = ot;
			foreach (Note note in track)
			{
				if (note.Type == NoteType.Regular)
				{
					this.AddNote(note);
				}
			}
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00007A44 File Offset: 0x00005C44
		public void AddNote(Note note)
		{
			if (note.OffsetMilliseconds(this._ot) != this.LastOffset())
			{
				QbcNote item = new QbcNote
				{
					Offset = note.OffsetMilliseconds(this._ot)
				};
				base.Add(item);
			}
			int num = 1 << note.Fret;
			int num2 = note.LengthMilliseconds(this._ot);
			if (base[base.Count - 1].Length < num2)
			{
				base[base.Count - 1].Length = num2;
			}
			QbcNote qbcNote = base[base.Count - 1];
			qbcNote.FretMask |= num;
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00007B00 File Offset: 0x00005D00
		public StringBuilder AsString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.Count * 11);
			foreach (QbcNote qbcNote in this)
			{
				stringBuilder.Append(qbcNote.Offset);
				stringBuilder.Append("\r\n");
				stringBuilder.Append(qbcNote.Length);
				stringBuilder.Append("\r\n");
				stringBuilder.Append(qbcNote.FretMask);
				stringBuilder.Append("\r\n");
			}
			return stringBuilder;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00007BB0 File Offset: 0x00005DB0
		private int LastOffset()
		{
			int result;
			if (base.Count == 0)
			{
				result = -1;
			}
			else
			{
				result = base[base.Count - 1].Offset;
			}
			return result;
		}

		// Token: 0x040000D3 RID: 211
		private OffsetTransformer _ot;
	}
}
