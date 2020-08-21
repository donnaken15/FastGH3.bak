using System.Linq;

namespace ChartEdit
{
    // Token: 0x0200000F RID: 15
    public class Optimizer
	{
		// Token: 0x06000088 RID: 136 RVA: 0x00003724 File Offset: 0x00001924
		public Optimizer(NoteTrack nt)
		{
			foreach (Note note in nt)
			{
				if (note.IsANote)
				{
					this.addNote(note);
				}
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000037D0 File Offset: 0x000019D0
		private void addNote(Note n)
		{
			if (this.notes.Count<Note>() == 0)
			{
				this.count++;
				Note note = new Note();
				this.copyNote(note, n);
				this.notes.Add(note);
			}
			else if (n.Offset == this.notes.Last<Note>().Offset)
			{
				Note note2 = this.notes.Last<Note>();
				note2.PointValue += n.PointValue * this.mult(this.count);
			}
			else
			{
				this.count++;
				Note note3 = new Note();
				this.copyNote(note3, n);
				note3.PointValue *= this.mult(this.count);
				note3.TickValue *= this.mult(this.count);
				this.notes.Add(note3);
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000038D4 File Offset: 0x00001AD4
		private int calculateBaseScore()
		{
			int num = 0;
			foreach (Note note in this.notes)
			{
				num += note.PointValue;
				num += note.TickValue;
			}
			return num;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003944 File Offset: 0x00001B44
		private void copyNote(Note newnote, Note n)
		{
			newnote.Length = n.Length;
			newnote.Offset = n.Offset;
			newnote.OffsetEnd = n.OffsetEnd;
			newnote.PointValue = n.PointValue;
			newnote.TickValue = 25 * n.Length / 192;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000399C File Offset: 0x00001B9C
		private int mult(int c)
		{
			int result;
			if (c >= 30)
			{
				result = 4;
			}
			else if (c >= 20)
			{
				result = 3;
			}
			else if (c >= 10)
			{
				result = 2;
			}
			else
			{
				result = 1;
			}
			return result;
		}

		// Token: 0x0400005F RID: 95
		private int count = 0;

		// Token: 0x04000060 RID: 96
		private NoteTrack notes = new NoteTrack();

		// Token: 0x04000061 RID: 97
		private NoteTrack spNotes;
	}
}
