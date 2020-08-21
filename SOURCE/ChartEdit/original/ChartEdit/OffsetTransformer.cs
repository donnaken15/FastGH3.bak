using System;
using System.Collections.Generic;
using System.Linq;

namespace ChartEdit
{
	// Token: 0x02000022 RID: 34
	public class OffsetTransformer
	{
		// Token: 0x06000116 RID: 278 RVA: 0x00005ABC File Offset: 0x00003CBC
		public OffsetTransformer(Chart chart)
		{
			this.chart = chart;
			this.BPM.Clear();
			this.Offset.Clear();
			this.timeOffset.Clear();
			foreach (SyncTrackEntry syncTrackEntry in chart.SyncTrack)
			{
				if (syncTrackEntry.BPM != 0)
				{
					this.BPM.Add((float)syncTrackEntry.BPM / 1000f);
					this.Offset.Add(syncTrackEntry.Offset);
				}
			}
			this.CreateOffsets();
			this.songLength = this.GetTime(chart.LastIndex);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00005BB8 File Offset: 0x00003DB8
		public void CreateOffsets()
		{
			this.timeOffset.Clear();
			this.timeOffset.Add(0f);
			for (int i = 0; i < this.Offset.Count - 1; i++)
			{
				this.timeOffset.Add(this.timeOffset[i] + (float)(this.Offset[i + 1] - this.Offset[i]) / (float)this.chart.Resolution / this.BPM[i] * 60f);
			}
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00005C58 File Offset: 0x00003E58
		public int GetOffset(float CrudeOffset)
		{
			return this.GetOffset(CrudeOffset, 0f);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00005C78 File Offset: 0x00003E78
		public int GetOffset(float CrudeOffset, float extraSeconds)
		{
			float num = CrudeOffset + extraSeconds;
			int i;
			for (i = 0; i < this.Offset.Count; i++)
			{
				if (this.timeOffset[i] > num)
				{
					break;
				}
			}
			i--;
			if (i < 0)
			{
				i = 0;
			}
			return this.Offset[i] + (int)((num - this.timeOffset[i]) / 60f * this.BPM[i] * (float)this.chart.Resolution);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00005D14 File Offset: 0x00003F14
		public float GetTime(int Offset)
		{
			int i;
			for (i = 0; i < this.Offset.Count; i++)
			{
				if (this.Offset[i] > Offset)
				{
					break;
				}
			}
			if (i > 0)
			{
				i--;
			}
			return this.timeOffset[i] + (float)(Offset - this.Offset[i]) / (float)this.chart.Resolution / this.BPM[i] * 60f;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00005DAC File Offset: 0x00003FAC
		public int nearNIndex(int Offset, List<Note> Notes)
		{
			int result;
			if (Notes == null)
			{
				result = 0;
			}
			else
			{
				int num = 0;
				int num2 = Notes.Count<Note>() - 1;
				switch (num2)
				{
				case -1:
				case 0:
					result = 0;
					break;
				case 1:
				{
					int num3 = Math.Abs(Notes[0].Offset - Offset);
					int num4 = Math.Abs(Notes[1].Offset - Offset);
					if (num3 >= num4)
					{
						result = 1;
					}
					else
					{
						result = 0;
					}
					break;
				}
				default:
				{
					int num5 = num2 / 2;
					while (Notes[num5].Offset != Offset)
					{
						num5 = (num + num2) / 2;
						if (Notes[num5].Offset > Offset)
						{
							num2 = num5;
						}
						else
						{
							num = num5;
						}
						if (num2 - num <= 1)
						{
							int num6 = Math.Abs(Notes[num5].Offset - Offset);
							int num7 = Math.Abs(Notes[num5 - 1].Offset - Offset);
							int num8 = Math.Abs(Notes[num5 + 1].Offset - Offset);
							if (num6 <= num7 && num6 <= num8)
							{
								return num5;
							}
							if (num7 <= num8)
							{
								return num5 - 1;
							}
							return num5 + 1;
						}
					}
					result = num5;
					break;
				}
				}
			}
			return result;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00005F2C File Offset: 0x0000412C
		public int nearNIndex(int Offset, NoteTrack Notes)
		{
			int result;
			if (Notes == null)
			{
				result = 0;
			}
			else
			{
				int num = 0;
				int num2 = Notes.Count<Note>() - 1;
				switch (num2)
				{
				case -1:
				case 0:
					result = 0;
					break;
				case 1:
				{
					int num3 = Math.Abs(Notes[0].Offset - Offset);
					int num4 = Math.Abs(Notes[1].Offset - Offset);
					if (num3 >= num4)
					{
						result = 1;
					}
					else
					{
						result = 0;
					}
					break;
				}
				default:
				{
					int num5 = num2 / 2;
					while (Notes[num5].Offset != Offset)
					{
						num5 = (num + num2) / 2;
						if (Notes[num5].Offset > Offset)
						{
							num2 = num5;
						}
						else
						{
							num = num5;
						}
						if (num2 - num <= 1)
						{
							int num6 = Math.Abs(Notes[num5].Offset - Offset);
							int num7 = Math.Abs(Notes[num5 - 1].Offset - Offset);
							int num8 = Math.Abs(Notes[num5 + 1].Offset - Offset);
							if (num6 <= num7 && num6 <= num8)
							{
								return num5;
							}
							if (num7 <= num8)
							{
								return num5 - 1;
							}
							return num5 + 1;
						}
					}
					result = num5;
					break;
				}
				}
			}
			return result;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x000060AC File Offset: 0x000042AC
		public int nearNIndex(int Offset, NoteTrack Notes, int fret)
		{
			int result;
			if (Notes == null)
			{
				result = 0;
			}
			else
			{
				int num = 0;
				int num2 = Notes.Count(fret) - 1;
				switch (num2)
				{
				case -1:
				case 0:
					result = 0;
					break;
				case 1:
				{
					int num3 = Math.Abs(Notes[0, fret].Offset - Offset);
					int num4 = Math.Abs(Notes[1, fret].Offset - Offset);
					if (num3 >= num4)
					{
						result = 1;
					}
					else
					{
						result = 0;
					}
					break;
				}
				default:
				{
					int num5 = num2 / 2;
					while (Notes[num5, fret].Offset != Offset)
					{
						num5 = (num + num2) / 2;
						if (Notes[num5, fret].Offset > Offset)
						{
							num2 = num5;
						}
						else
						{
							num = num5;
						}
						if (num2 - num <= 1)
						{
							int num6 = Math.Abs(Notes[num5].Offset - Offset);
							int num7 = Math.Abs(Notes[num5 - 1].Offset - Offset);
							int num8 = Math.Abs(Notes[num5 + 1].Offset - Offset);
							if (num6 <= num7 && num6 <= num8)
							{
								return num5;
							}
							if (num7 <= num8)
							{
								return num5 - 1;
							}
							return num5 + 1;
						}
					}
					result = num5;
					break;
				}
				}
			}
			return result;
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00006234 File Offset: 0x00004434
		public int nearNIndexEnd(int Offset, NoteTrack Notes)
		{
			int result;
			if (Notes == null)
			{
				result = 0;
			}
			else
			{
				int num = 0;
				int num2 = Notes.Count<Note>() - 1;
				switch (num2)
				{
				case -1:
				case 0:
					result = 0;
					break;
				case 1:
				{
					int num3 = Math.Abs(Notes[0].OffsetEnd - Offset);
					int num4 = Math.Abs(Notes[1].OffsetEnd - Offset);
					if (num3 >= num4)
					{
						result = 1;
					}
					else
					{
						result = 0;
					}
					break;
				}
				default:
				{
					int num5 = num2 / 2;
					while (Notes[num5].OffsetEnd != Offset)
					{
						num5 = (num + num2) / 2;
						if (Notes[num5].OffsetEnd > Offset)
						{
							num2 = num5;
						}
						else
						{
							num = num5;
						}
						if (num2 - num <= 1)
						{
							int num6 = Math.Abs(Notes[num5].OffsetEnd - Offset);
							int num7 = Math.Abs(Notes[num5 - 1].OffsetEnd - Offset);
							int num8 = Math.Abs(Notes[num5 + 1].OffsetEnd - Offset);
							if (num6 <= num7 && num6 <= num8)
							{
								return num5;
							}
							if (num7 <= num8)
							{
								return num5 - 1;
							}
							return num5 + 1;
						}
					}
					result = num5;
					break;
				}
				}
			}
			return result;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x000063B4 File Offset: 0x000045B4
		public int nearNIndexEnd(int Offset, NoteTrack Notes, int fret)
		{
			int result;
			if (Notes == null)
			{
				result = 0;
			}
			else
			{
				int num = 0;
				int num2 = Notes.Count(fret) - 1;
				switch (num2)
				{
				case -1:
				case 0:
					result = 0;
					break;
				case 1:
				{
					int num3 = Math.Abs(Notes[0, fret].OffsetEnd - Offset);
					int num4 = Math.Abs(Notes[1, fret].OffsetEnd - Offset);
					if (num3 >= num4)
					{
						result = 1;
					}
					else
					{
						result = 0;
					}
					break;
				}
				default:
				{
					int num5 = num2 / 2;
					while (Notes[num5, fret].OffsetEnd != Offset)
					{
						num5 = (num + num2) / 2;
						if (Notes[num5, fret].OffsetEnd > Offset)
						{
							num2 = num5;
						}
						else
						{
							num = num5;
						}
						if (num2 - num <= 1)
						{
							int num6 = Math.Abs(Notes[num5, fret].OffsetEnd - Offset);
							int num7 = Math.Abs(Notes[num5 - 1, fret].OffsetEnd - Offset);
							int num8 = Math.Abs(Notes[num5 + 1, fret].OffsetEnd - Offset);
							if (num6 <= num7 && num6 <= num8)
							{
								return num5;
							}
							if (num7 <= num8)
							{
								return num5 - 1;
							}
							return num5 + 1;
						}
					}
					result = num5;
					break;
				}
				}
			}
			return result;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0000653C File Offset: 0x0000473C
		public int NextBPMIndex(int offset)
		{
			int i;
			for (i = 0; i < this.Offset.Count; i++)
			{
				if (this.Offset[i] >= offset)
				{
					return i;
				}
			}
			return i;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00006588 File Offset: 0x00004788
		public int nextNIndex(int Offset, NoteTrack Notes)
		{
			int result;
			if (Notes == null)
			{
				result = 0;
			}
			else
			{
				int i;
				for (i = this.nearNIndex(Offset, Notes); i < Notes.Count<Note>(); i++)
				{
					if (Notes[i].Offset > Offset)
					{
						return i;
					}
				}
				result = i - 1;
			}
			return result;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x000065E8 File Offset: 0x000047E8
		public int nextNIndex(int Offset, List<Note> Notes)
		{
			int result;
			if (Notes == null)
			{
				result = 0;
			}
			else
			{
				int i;
				for (i = this.nearNIndex(Offset, Notes); i < Notes.Count<Note>(); i++)
				{
					if (Notes[i].Offset > Offset)
					{
						return i;
					}
				}
				result = i - 1;
			}
			return result;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00006648 File Offset: 0x00004848
		public int PrevBPMIndex(int offset)
		{
			int i;
			for (i = 0; i < this.Offset.Count; i++)
			{
				if (this.Offset[i] >= offset)
				{
					break;
				}
			}
			return i - 1;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00006694 File Offset: 0x00004894
		public int prevNIndex(int Offset, NoteTrack Notes)
		{
			if (Notes != null)
			{
				for (int i = this.nearNIndex(Offset, Notes); i >= 0; i--)
				{
					if (Notes[i].Offset < Offset)
					{
						return i;
					}
				}
			}
			return 0;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x000066E8 File Offset: 0x000048E8
		public int prevNIndex(int Offset, List<Note> Notes)
		{
			if (Notes != null)
			{
				for (int i = this.nearNIndex(Offset, Notes); i >= 0; i--)
				{
					if (Notes[i].Offset < Offset)
					{
						return i;
					}
				}
			}
			return 0;
		}

		// Token: 0x040000A9 RID: 169
		public List<float> BPM = new List<float>();

		// Token: 0x040000AA RID: 170
		private Chart chart;

		// Token: 0x040000AB RID: 171
		public List<int> Offset = new List<int>();

		// Token: 0x040000AC RID: 172
		public float songLength;

		// Token: 0x040000AD RID: 173
		public List<float> timeOffset = new List<float>();
	}
}
