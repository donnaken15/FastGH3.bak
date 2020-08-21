using System;
using System.Collections.Generic;

namespace ChartEdit
{
	// Token: 0x0200000C RID: 12
	public class SyncTrackSection : List<SyncTrackEntry>
	{
		// Token: 0x0600007D RID: 125 RVA: 0x000035BC File Offset: 0x000017BC
		public bool ContainsOffset(int offset)
		{
			foreach (SyncTrackEntry syncTrackEntry in this)
			{
				if (syncTrackEntry.Offset == offset)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003628 File Offset: 0x00001828
		public SyncTrackEntry GetByIndex(int index)
		{
			return base[index];
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00003644 File Offset: 0x00001844
		public SyncTrackEntry GetByOffset(int offset)
		{
			foreach (SyncTrackEntry syncTrackEntry in this)
			{
				if (syncTrackEntry.Offset == offset)
				{
					return syncTrackEntry;
				}
			}
			return null;
		}

		// Token: 0x0400005A RID: 90
		public const string SectionName = "SyncTrack";
	}
}
