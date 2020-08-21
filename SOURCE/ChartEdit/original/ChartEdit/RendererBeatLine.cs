using System;

namespace ChartEdit
{
	// Token: 0x0200002F RID: 47
	public class RendererBeatLine
	{
		// Token: 0x0600016F RID: 367 RVA: 0x00007DF0 File Offset: 0x00005FF0
		public RendererBeatLine(beatType beatType, float y)
		{
			this.BeatType = beatType;
			this.Y = y;
		}

		// Token: 0x040000DB RID: 219
		public beatType BeatType;

		// Token: 0x040000DC RID: 220
		public float Y;
	}
}
