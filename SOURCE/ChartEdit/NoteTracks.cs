using System;
using System.Collections.Generic;

namespace ChartEdit
{
	// Token: 0x02000010 RID: 16
	public class NoteTracks : List<NoteTrack>
	{
		// Token: 0x0600008D RID: 141 RVA: 0x000039DC File Offset: 0x00001BDC
		public bool ContainsTrack(string name)
		{
			foreach (NoteTrack noteTrack in this)
			{
				if (noteTrack.Name == name)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x17000019 RID: 25
		public NoteTrack this[string name]
		{
			get
			{
				foreach (NoteTrack noteTrack in this)
				{
					if (noteTrack.Name == name)
					{
						return noteTrack;
					}
				}
				return null;
			}
		}
	}
}
