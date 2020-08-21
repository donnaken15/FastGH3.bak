using System;
using System.Collections.Generic;
using System.Linq;

namespace ChartEdit
{
	// Token: 0x0200002A RID: 42
	public class NoteTrack : List<Note>
	{
		// Token: 0x0600013C RID: 316 RVA: 0x000069E9 File Offset: 0x00004BE9
		public NoteTrack()
		{
			this.noteList = new List<List<Note>>();
			this.SpecialList = new List<Note>();
			this.EventList = new List<Note>();
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00006A15 File Offset: 0x00004C15
		public NoteTrack(string name)
		{
			this.noteList = new List<List<Note>>();
			this.SpecialList = new List<Note>();
			this.EventList = new List<Note>();
			this.Name = name;
			this.SetDetails(name);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00006A54 File Offset: 0x00004C54
		public void AssignProperty(int fret)
		{
			bool isANote = true;
			bool flipsHOPO = false;
			bool forcesHOPO = false;
			bool forcesStrum = false;
			bool forcesTapping = false;
			int pointValue = 50;
			foreach (Note note in this)
			{
				if (note.Fret == fret)
				{
					note.IsANote = isANote;
					note.FlipsHOPO = flipsHOPO;
					note.ForcesHOPO = forcesHOPO;
					note.ForcesStrum = forcesStrum;
					note.ForcesTapping = forcesTapping;
					note.PointValue = pointValue;
				}
			}
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00006B04 File Offset: 0x00004D04
		public new int Count(int fret)
		{
			int result;
			if (fret > this.noteList.Count - 1)
			{
				result = 0;
			}
			else
			{
				result = this.noteList[fret].Count<Note>();
			}
			return result;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00006B44 File Offset: 0x00004D44
		public void Evaluate(Chart chart)
		{
			this.SetHopoLogic();
			this.EvaluateNoteness();
			this.EvaluateChords();
			this.EvaluateHOPO(chart.Resolution / 3, 1, this.Count<Note>());
			this.EvaluateFlipping();
			this.EvaluateTapping();
			this.EvaluateSP();
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00006B94 File Offset: 0x00004D94
		public void Evaluate(Chart chart, int start, int start2, int end)
		{
			while (end < this.Count<Note>() - 1)
			{
				if (!base[end].IsChord)
				{
					break;
				}
				end++;
			}
			this.SetHopoLogic();
			this.EvaluateNoteness(start, end);
			this.EvaluateChords(start2, end);
			this.EvaluateHOPO(chart.Resolution / 3, start2, end);
			this.EvaluateFlipping(start, end);
			this.EvaluateTapping(start, end);
			this.EvaluateSP(start, end);
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00006C1B File Offset: 0x00004E1B
		public void EvaluateChords()
		{
			this.EvaluateChords(1, this.Count<Note>());
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00006C2C File Offset: 0x00004E2C
		public void EvaluateChords(int start, int end)
		{
			for (int i = start; i < end; i++)
			{
				if (base[i].IsANote)
				{
					for (int j = i - 1; j > 0; j--)
					{
						if (base[j].IsANote)
						{
							if (base[j].Offset == base[i].Offset)
							{
								base[i].IsChord = true;
								base[j].IsChord = true;
							}
							else
							{
								base[i].IsChord = false;
							}
							break;
						}
					}
				}
				else
				{
					base[i].IsChord = false;
				}
			}
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00006CF4 File Offset: 0x00004EF4
		public void EvaluateFlipping()
		{
			this.EvaluateFlipping(0, this.Count<Note>());
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00006D08 File Offset: 0x00004F08
		public void EvaluateFlipping(int start, int end)
		{
			for (int i = start; i < end; i++)
			{
				if (base[i].FlipsHOPO)
				{
					for (int j = i - 1; j > 0; j--)
					{
						if (base[j].Offset != base[i].Offset)
						{
							break;
						}
						base[j].IsHopo = !base[j].IsHopo;
					}
					for (int k = i + 1; k < this.Count<Note>(); k++)
					{
						if (base[k].Offset != base[i].Offset)
						{
							break;
						}
						base[k].IsHopo = !base[k].IsHopo;
					}
				}
				if (base[i].ForcesHOPO)
				{
					for (int l = i - 1; l > 0; l--)
					{
						if (base[l].Offset != base[i].Offset)
						{
							break;
						}
						base[l].IsHopo = true;
					}
					for (int m = i + 1; m < this.Count<Note>(); m++)
					{
						if (base[m].Offset != base[i].Offset)
						{
							break;
						}
						base[m].IsHopo = true;
					}
				}
				if (base[i].ForcesStrum)
				{
					for (int n = i - 1; n > 0; n--)
					{
						if (base[n].Offset != base[i].Offset)
						{
							break;
						}
						base[n].IsHopo = false;
					}
					for (int num = i + 1; num < this.Count<Note>(); num++)
					{
						if (base[num].Offset != base[i].Offset)
						{
							break;
						}
						base[num].IsHopo = false;
					}
				}
			}
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00006F65 File Offset: 0x00005165
		public void EvaluateHOPO()
		{
			this.EvaluateHOPO(64, 1, this.Count<Note>());
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00006F78 File Offset: 0x00005178
		public void EvaluateHOPO(int threshold, int start, int end)
		{
			for (int i = start; i < end; i++)
			{
				if (base[i].IsChord)
				{
					base[i].IsHopo = false;
				}
				else
				{
					int num = i - 1;
					while (!base[num].IsANote | base[num].Offset == base[i].Offset)
					{
						if (num == 0)
						{
							break;
						}
						num--;
					}
					if (base[i].Offset - base[num].Offset > threshold)
					{
						base[i].IsHopo = false;
					}
					else
					{
						string hopoLogic = this.HopoLogic;
						if (hopoLogic != null)
						{
							if (hopoLogic == "gh1" || hopoLogic == "gh2" || hopoLogic == "rockband" || hopoLogic == "rockband2")
							{
								int j = num;
								while (j > 0)
								{
									if (base[num].Offset == base[j].Offset)
									{
										if (base[i].Fret != base[j].Fret)
										{
											base[i].IsHopo = true;
											j--;
											continue;
										}
										base[i].IsHopo = false;
									}
									else
									{
										base[i].IsHopo = true;
									}
									break;
								}
								goto IL_201;
							}
							if (hopoLogic == "none")
							{
								base[i].IsHopo = false;
								goto IL_201;
							}
						}
						if (base[i].Fret != base[num].Fret || base[num].IsChord)
						{
							base[i].IsHopo = true;
						}
						else
						{
							base[i].IsHopo = false;
						}
					}
				}
				IL_201:;
			}
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00007195 File Offset: 0x00005395
		public void EvaluateNoteness()
		{
			this.EvaluateNoteness(0, this.Count<Note>());
		}

		// Token: 0x06000149 RID: 329 RVA: 0x000071A8 File Offset: 0x000053A8
		public void EvaluateNoteness(int start, int end)
		{
			for (int i = start; i < end; i++)
			{
				if (base[i].Type != NoteType.Regular)
				{
					base[i].IsANote = false;
				}
			}
		}

		// Token: 0x0600014A RID: 330 RVA: 0x000071EC File Offset: 0x000053EC
		public void EvaluateSP()
		{
			int num = 0;
			List<int> list = new List<int>();
			int num2 = 0;
			for (int i = 0; i < this.Count<Note>(); i++)
			{
				if (base[i].Offset != num2)
				{
					list.Clear();
					num2 = base[i].Offset;
				}
				list.Add(i);
				if (base[i].Type == NoteType.Special & base[i].SpecialFlag == 2)
				{
					num = base[i].OffsetEnd;
					foreach (int index in list)
					{
						base[index].IsInSP = true;
					}
					list.Clear();
				}
				else if (base[i].Offset < num)
				{
					base[i].IsInSP = true;
				}
				else
				{
					base[i].IsInSP = false;
				}
			}
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00007324 File Offset: 0x00005524
		public void EvaluateSP(int start, int end)
		{
			int num = -1;
			for (int i = num + 1; i < this.SpecialList.Count<Note>(); i++)
			{
				if (this.SpecialList[i].SpecialFlag == 2 && this.SpecialList[i].OffsetEnd > base[start].Offset)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				for (int j = start; j < end; j++)
				{
					base[j].IsInSP = false;
				}
			}
			else
			{
				for (int k = start; k < end; k++)
				{
					if (base[k].Offset >= this.SpecialList[num].Offset)
					{
						if (base[k].Offset < this.SpecialList[num].OffsetEnd)
						{
							base[k].IsInSP = true;
						}
						else
						{
							base[k].IsInSP = false;
							for (int l = num + 1; l < this.SpecialList.Count<Note>(); l++)
							{
								if (this.SpecialList[l].SpecialFlag == 2 && this.SpecialList[l].OffsetEnd > base[k].Offset)
								{
									num = l;
									break;
								}
							}
						}
					}
					else
					{
						base[k].IsInSP = false;
					}
				}
			}
		}

		// Token: 0x0600014C RID: 332 RVA: 0x000074DB File Offset: 0x000056DB
		public void EvaluateTapping()
		{
			this.EvaluateTapping(0, this.Count<Note>());
		}

		// Token: 0x0600014D RID: 333 RVA: 0x000074EC File Offset: 0x000056EC
		public void EvaluateTapping(int start, int end)
		{
			for (int i = start; i < end; i++)
			{
				if (base[i].ForcesTapping)
				{
					for (int j = i - 1; j > 0; j--)
					{
						if (base[j].Offset != base[i].Offset)
						{
							break;
						}
						base[j].IsTapping = true;
					}
					for (int k = i + 1; k < this.Count<Note>(); k++)
					{
						if (base[k].Offset != base[i].Offset)
						{
							break;
						}
						base[k].IsTapping = true;
					}
				}
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x000075B4 File Offset: 0x000057B4
		public void FillNoteList(int fret)
		{
			while (this.HighestFret <= fret)
			{
				this.HighestFret++;
				this.noteList.Add(new List<Note>());
				this.noteList.Last<List<Note>>().Clear();
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00007608 File Offset: 0x00005808
		public void GenerateFretList()
		{
			this.noteList.Clear();
			this.SpecialList.Clear();
			this.EventList.Clear();
			this.HighestFret = this.highestFret() + 1;
			for (int i = 0; i < this.HighestFret; i++)
			{
				this.noteList.Add(new List<Note>());
			}
			foreach (Note note in this)
			{
				switch (note.Type)
				{
				case NoteType.Regular:
					this.noteList[note.Fret].Add(note);
					break;
				case NoteType.Special:
					this.SpecialList.Add(note);
					break;
				case NoteType.Event:
					this.EventList.Add(note);
					break;
				}
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00007708 File Offset: 0x00005908
		private int highestFret()
		{
			int num = 0;
			foreach (Note note in this)
			{
				if (note.Fret > num)
				{
					num = note.Fret;
				}
			}
			return num;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000777C File Offset: 0x0000597C
		public List<Note> NoteList(int fret)
		{
			List<Note> result;
			if (fret >= this.noteList.Count<List<Note>>())
			{
				result = null;
			}
			else
			{
				result = this.noteList[fret];
			}
			return result;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x000077B4 File Offset: 0x000059B4
		private void SetDetails(string entry)
		{
			int num = 0;
			for (int i = 1; i < entry.Length; i++)
			{
				if (char.IsUpper(entry[i]))
				{
					num = i;
					break;
				}
			}
			this.Difficulty = entry.Substring(0, num);
			this.Instrument = entry.Substring(num, entry.Length - num);
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00007818 File Offset: 0x00005A18
		public void SetHopoLogic()
		{
			this.HopoLogic = Globals.Instance.GameProperties[0].TrackProperties[this.stripDifficulty(this.Name)].HopoLogic;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0000784C File Offset: 0x00005A4C
		public void SetProperties(bool isANote, bool flipsHOPO, bool forcesHOPO, bool forcesStrum, int pointValue)
		{
			foreach (Note note in this)
			{
				note.IsANote = isANote;
				note.FlipsHOPO = flipsHOPO;
				note.ForcesHOPO = forcesHOPO;
				note.ForcesStrum = forcesStrum;
				note.PointValue = pointValue;
			}
		}

		// Token: 0x06000155 RID: 341 RVA: 0x000078C8 File Offset: 0x00005AC8
		private string stripDifficulty(string entry)
		{
			int startIndex = 0;
			for (int i = 1; i < entry.Length; i++)
			{
				if (char.IsUpper(entry[i]))
				{
					startIndex = i;
					break;
				}
			}
			return entry.Substring(startIndex);
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000156 RID: 342 RVA: 0x00007914 File Offset: 0x00005B14
		// (set) Token: 0x06000157 RID: 343 RVA: 0x0000792B File Offset: 0x00005B2B
		public string Difficulty { get; set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000158 RID: 344 RVA: 0x00007934 File Offset: 0x00005B34
		// (set) Token: 0x06000159 RID: 345 RVA: 0x0000794B File Offset: 0x00005B4B
		public string Instrument { get; set; }

		// Token: 0x1700003D RID: 61
		public Note this[int index, int fret]
		{
			get
			{
				Note result;
				if (fret > this.HighestFret - 1)
				{
					result = null;
				}
				else if (this.noteList[fret].Count<Note>() <= index)
				{
					result = null;
				}
				else
				{
					result = this.noteList[fret][index];
				}
				return result;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600015B RID: 347 RVA: 0x000079AC File Offset: 0x00005BAC
		// (set) Token: 0x0600015C RID: 348 RVA: 0x000079C3 File Offset: 0x00005BC3
		public string Name { get; set; }

		// Token: 0x040000C7 RID: 199
		private OffsetTransformer _ot;

		// Token: 0x040000C8 RID: 200
		public List<Note> EventList;

		// Token: 0x040000C9 RID: 201
		public int HighestFret;

		// Token: 0x040000CA RID: 202
		public string HopoLogic;

		// Token: 0x040000CB RID: 203
		public List<List<Note>> noteList;

		// Token: 0x040000CC RID: 204
		public List<Note> SpecialList;
	}
}
