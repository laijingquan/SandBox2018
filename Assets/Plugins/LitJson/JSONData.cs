using System;
using System.IO;

namespace LitJson
{
	// Token: 0x02000007 RID: 7
	public class JSONData : JSONNode
	{
		// Token: 0x06000054 RID: 84 RVA: 0x00003BA3 File Offset: 0x00001FA3
		public JSONData(string aData)
		{
			this.m_Data = aData;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00003BB2 File Offset: 0x00001FB2
		public JSONData(float aData)
		{
			this.AsFloat = aData;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00003BC1 File Offset: 0x00001FC1
		public JSONData(double aData)
		{
			this.AsDouble = aData;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00003BD0 File Offset: 0x00001FD0
		public JSONData(bool aData)
		{
			this.AsBool = aData;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00003BDF File Offset: 0x00001FDF
		public JSONData(int aData)
		{
			this.AsInt = aData;
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00003BEE File Offset: 0x00001FEE
		// (set) Token: 0x0600005A RID: 90 RVA: 0x00003BF6 File Offset: 0x00001FF6
		public override string Value
		{
			get
			{
				return this.m_Data;
			}
			set
			{
				this.m_Data = value;
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00003BFF File Offset: 0x00001FFF
		public override string ToString()
		{
			return this.ToString(string.Empty);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00003C0C File Offset: 0x0000200C
		public override string ToString(string aPrefix)
		{
			return aPrefix + JSONNode.Escape(this.m_Data) + aPrefix;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00003C20 File Offset: 0x00002020
		public override void Serialize(BinaryWriter aWriter)
		{
			JSONData jsondata = new JSONData(string.Empty);
			jsondata.AsInt = this.AsInt;
			if (jsondata.m_Data == this.m_Data)
			{
				aWriter.Write(4);
				aWriter.Write(this.AsInt);
				return;
			}
			jsondata.AsFloat = this.AsFloat;
			if (jsondata.m_Data == this.m_Data)
			{
				aWriter.Write(7);
				aWriter.Write(this.AsFloat);
				return;
			}
			jsondata.AsDouble = this.AsDouble;
			if (jsondata.m_Data == this.m_Data)
			{
				aWriter.Write(5);
				aWriter.Write(this.AsDouble);
				return;
			}
			jsondata.AsBool = this.AsBool;
			if (jsondata.m_Data == this.m_Data)
			{
				aWriter.Write(6);
				aWriter.Write(this.AsBool);
				return;
			}
			aWriter.Write(3);
			aWriter.Write(this.m_Data);
		}

		// Token: 0x0400000B RID: 11
		private string m_Data;
	}
}
