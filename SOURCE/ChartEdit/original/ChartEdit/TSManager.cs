using System;
using System.Collections.Generic;

namespace ChartEdit
{
	// Token: 0x02000018 RID: 24
	public class TSManager
	{
		// Token: 0x060000D0 RID: 208 RVA: 0x00004748 File Offset: 0x00002948
		public TSManager(Chart chart)
		{
			this.chart = chart;
			this.DetectTimeSignatures(chart.SyncTrack);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00004774 File Offset: 0x00002974
		public void DetectTimeSignatures(SyncTrackSection sT)
		{
			this.beat.Clear();
			this.tSInd = new List<int>();
			for (int i = 0; i < sT.Count; i++)
			{
				if (sT[i].Type == SyncType.TimeSignature)
				{
					this.tSInd.Add(i);
				}
			}
			for (int i = 0; i < this.tSInd.Count; i++)
			{
				int timeSignature = sT[this.tSInd[i]].TimeSignature;
				int offset = sT[this.tSInd[i]].Offset;
				if (this.tSInd.Count == i + 1)
				{
					this.beat.Add(beatType.Measure);
					this.lastTSOffset = offset;
					this.lastTS = timeSignature;
					break;
				}
				int offset2 = sT[this.tSInd[i + 1]].Offset;
				for (int j = offset; j < offset2; j += this.chart.HalfResolution)
				{
					int num = j - offset;
					if (num % (this.chart.Resolution * timeSignature) == 0)
					{
						this.beat.Add(beatType.Measure);
					}
					else if (num % this.chart.Resolution == 0)
					{
						this.beat.Add(beatType.Beat);
					}
					else if (num % this.chart.HalfResolution == 0)
					{
						this.beat.Add(beatType.HalfBeat);
					}
					else if (num % this.chart.QuarterResolution == 0)
					{
						this.beat.Add(beatType.QuarterBeat);
					}
					else if (num % this.chart.EighthResolution == 0)
					{
						this.beat.Add(beatType.EighthBeat);
					}
					else if (num % this.chart.SixteenthResolution == 0)
					{
						this.beat.Add(beatType.SixteenthBeat);
					}
					else
					{
						this.beat.Add(beatType.NotABeat);
					}
				}
			}
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x000049D4 File Offset: 0x00002BD4
		public int NearestSnapPointBeat(int snapResolution, int offset)
		{
			SyncTrackSection syncTrack = this.chart.SyncTrack;
			int num = 0;
			if (offset > this.lastTSOffset)
			{
				num = this.lastTSOffset;
			}
			else
			{
				foreach (int index in this.tSInd)
				{
					if (syncTrack[index].Offset < offset)
					{
						num = syncTrack[index].Offset;
					}
				}
			}
			num += (offset - num) / snapResolution * snapResolution;
			int num2 = 0;
			while (Math.Abs(offset - (num + num2)) <= Math.Abs(offset - (num + num2 - snapResolution)))
			{
				num2 += snapResolution;
			}
			return num + num2 - snapResolution;
		}

		// Token: 0x1700001D RID: 29
		public beatType this[int offset]
		{
			get
			{
				if (!(offset % this.chart.HalfResolution != 0 | offset < 0))
				{
					if (offset / this.chart.HalfResolution < this.beat.Count)
					{
						return this.beat[offset / this.chart.HalfResolution];
					}
					int num = offset - this.lastTSOffset;
					if (num % (this.chart.Resolution * this.lastTS) == 0)
					{
						return beatType.Measure;
					}
					if (num % this.chart.Resolution == 0)
					{
						return beatType.Beat;
					}
					if (num % this.chart.HalfResolution == 0)
					{
						return beatType.HalfBeat;
					}
					if (num % this.chart.QuarterResolution == 0)
					{
						return beatType.QuarterBeat;
					}
					if (num % this.chart.EighthResolution == 0)
					{
						return beatType.EighthBeat;
					}
					if (num % this.chart.SixteenthResolution == 0)
					{
						return beatType.SixteenthBeat;
					}
				}
				return beatType.NotABeat;
			}
		}

		// Token: 0x04000077 RID: 119
		private List<beatType> beat = new List<beatType>();

		// Token: 0x04000078 RID: 120
		private Chart chart;

		// Token: 0x04000079 RID: 121
		private int lastTS;

		// Token: 0x0400007A RID: 122
		private int lastTSOffset;

		// Token: 0x0400007B RID: 123
		private List<int> tSInd;
	}
}
