using System;

namespace LitJson
{
	// Token: 0x02000008 RID: 8
	internal class JSONLazyCreator : JSONNode
	{
		// Token: 0x0600005E RID: 94 RVA: 0x00003D23 File Offset: 0x00002123
		public JSONLazyCreator(JSONNode aNode)
		{
			this.m_Node = aNode;
			this.m_Key = null;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00003D39 File Offset: 0x00002139
		public JSONLazyCreator(JSONNode aNode, string aKey)
		{
			this.m_Node = aNode;
			this.m_Key = aKey;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003D4F File Offset: 0x0000214F
		private void Set(JSONNode aVal)
		{
			if (this.m_Key == null)
			{
				this.m_Node.Add(aVal);
			}
			else
			{
				this.m_Node.Add(this.m_Key, aVal);
			}
			this.m_Node = null;
		}

		// Token: 0x17000016 RID: 22
		public override JSONNode this[int aIndex]
		{
			get
			{
				return new JSONLazyCreator(this);
			}
			set
			{
				this.Set(new JSONArray
				{
					value
				});
			}
		}

		// Token: 0x17000017 RID: 23
		public override JSONNode this[string aKey]
		{
			get
			{
				return new JSONLazyCreator(this, aKey);
			}
			set
			{
				this.Set(new JSONClass
				{
					{
						aKey,
						value
					}
				});
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003DE0 File Offset: 0x000021E0
		public override void Add(JSONNode aItem)
		{
			this.Set(new JSONArray
			{
				aItem
			});
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00003E04 File Offset: 0x00002204
		public override void Add(string aKey, JSONNode aItem)
		{
			this.Set(new JSONClass
			{
				{
					aKey,
					aItem
				}
			});
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00003E26 File Offset: 0x00002226
		public static bool operator ==(JSONLazyCreator a, object b)
		{
			return b == null || object.ReferenceEquals(a, b);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00003E37 File Offset: 0x00002237
		public static bool operator !=(JSONLazyCreator a, object b)
		{
			return !(a == b);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00003E43 File Offset: 0x00002243
		public override bool Equals(object obj)
		{
			return obj == null || object.ReferenceEquals(this, obj);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00003E54 File Offset: 0x00002254
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00003E5C File Offset: 0x0000225C
		public override string ToString()
		{
			return string.Empty;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003E63 File Offset: 0x00002263
		public override string ToString(string aPrefix)
		{
			return string.Empty;
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00003E6C File Offset: 0x0000226C
		// (set) Token: 0x0600006E RID: 110 RVA: 0x00003E88 File Offset: 0x00002288
		public override int AsInt
		{
			get
			{
				JSONData aVal = new JSONData(0);
				this.Set(aVal);
				return 0;
			}
			set
			{
				JSONData aVal = new JSONData(value);
				this.Set(aVal);
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00003EA4 File Offset: 0x000022A4
		// (set) Token: 0x06000070 RID: 112 RVA: 0x00003EC8 File Offset: 0x000022C8
		public override float AsFloat
		{
			get
			{
				JSONData aVal = new JSONData(0f);
				this.Set(aVal);
				return 0f;
			}
			set
			{
				JSONData aVal = new JSONData(value);
				this.Set(aVal);
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00003EE4 File Offset: 0x000022E4
		// (set) Token: 0x06000072 RID: 114 RVA: 0x00003F10 File Offset: 0x00002310
		public override double AsDouble
		{
			get
			{
				JSONData aVal = new JSONData(0.0);
				this.Set(aVal);
				return 0.0;
			}
			set
			{
				JSONData aVal = new JSONData(value);
				this.Set(aVal);
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00003F2C File Offset: 0x0000232C
		// (set) Token: 0x06000074 RID: 116 RVA: 0x00003F48 File Offset: 0x00002348
		public override bool AsBool
		{
			get
			{
				JSONData aVal = new JSONData(false);
				this.Set(aVal);
				return false;
			}
			set
			{
				JSONData aVal = new JSONData(value);
				this.Set(aVal);
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00003F64 File Offset: 0x00002364
		public override JSONArray AsArray
		{
			get
			{
				JSONArray jsonarray = new JSONArray();
				this.Set(jsonarray);
				return jsonarray;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000076 RID: 118 RVA: 0x00003F80 File Offset: 0x00002380
		public override JSONClass AsObject
		{
			get
			{
				JSONClass jsonclass = new JSONClass();
				this.Set(jsonclass);
				return jsonclass;
			}
		}

		// Token: 0x0400000C RID: 12
		private JSONNode m_Node;

		// Token: 0x0400000D RID: 13
		private string m_Key;
	}
}
