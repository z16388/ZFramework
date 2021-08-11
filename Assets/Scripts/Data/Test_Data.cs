// This is an automatically generated file. Please do not modify it
using System.Collections.Generic;
using System.IO;

namespace ConfigData {

public class Test_TestBase : IConfig
{
	public int ID;
	public bool Boolean;
	public string String;
	public float FloatData;
	public int[] Zu;
	public int[][] MA;

	public override void MergeFrom(BinaryReader br)
	{
		ID = br.ReadInt32();
		Boolean = br.ReadBoolean();
		String = br.ReadString();
		FloatData = br.ReadSingle();
		Zu = ReadInt32Array(br);
		MA = ReadInt32ArrayMtp(br);
	}
	public override string ToString()
	{
		return  GetID() +  "|"  + GetBoolean() +  "|"  + GetString() +  "|"  + GetFloatData() +  "|"  + GetZu() +  "|"  + GetMA() +  "|" ;
	}
	 public string GetID()
	{
		string str = "";
		str += ID.ToString();
		return str;
	}
	 public string GetBoolean()
	{
		string str = "";
		str += Boolean.ToString();
		return str;
	}
	 public string GetString()
	{
		string str = "";
		str += String.ToString();
		return str;
	}
	 public string GetFloatData()
	{
		string str = "";
		str += FloatData.ToString();
		return str;
	}
	 public string GetZu()
	{
		string str = "";
		foreach (var v in Zu)
			str += v.ToString() + " ";
		return str;
	}
	 public string GetMA()
	{
		string str = "";
		foreach (var d in MA)
		{str += "[";
			foreach (var v in d)
				str += v.ToString() + " ";
			str += "]";
		}
		return str;
	}

	protected override int GetKey()
	{
		return ID;
	}
}

public class Test_TestMM : IConfig
{
	public int Group;
	public int ID;
	public bool Boolean;
	public string String;
	public float FloatData;
	public int[] Zu;
	public int[][] MA;

	public override void MergeFrom(BinaryReader br)
	{
		Group = br.ReadInt32();
		ID = br.ReadInt32();
		Boolean = br.ReadBoolean();
		String = br.ReadString();
		FloatData = br.ReadSingle();
		Zu = ReadInt32Array(br);
		MA = ReadInt32ArrayMtp(br);
	}
	public override string ToString()
	{
		return  GetGroup() +  "|"  + GetID() +  "|"  + GetBoolean() +  "|"  + GetString() +  "|"  + GetFloatData() +  "|"  + GetZu() +  "|"  + GetMA() +  "|" ;
	}
	 public string GetGroup()
	{
		string str = "";
		str += Group.ToString();
		return str;
	}
	 public string GetID()
	{
		string str = "";
		str += ID.ToString();
		return str;
	}
	 public string GetBoolean()
	{
		string str = "";
		str += Boolean.ToString();
		return str;
	}
	 public string GetString()
	{
		string str = "";
		str += String.ToString();
		return str;
	}
	 public string GetFloatData()
	{
		string str = "";
		str += FloatData.ToString();
		return str;
	}
	 public string GetZu()
	{
		string str = "";
		foreach (var v in Zu)
			str += v.ToString() + " ";
		return str;
	}
	 public string GetMA()
	{
		string str = "";
		foreach (var d in MA)
		{str += "[";
			foreach (var v in d)
				str += v.ToString() + " ";
			str += "]";
		}
		return str;
	}

	protected override int GetKey()
	{
		return ID;
	}

	protected override int GetDicKey()
	{
		return Group;
	}
}

public class Test_TestR : IConfig
{
	public int ID;
	public bool Boolean;
	public string String;
	public float FloatData;
	public int[] Zu;
	public int[][] MA;

	public override void MergeFrom(BinaryReader br)
	{
		ID = br.ReadInt32();
		Boolean = br.ReadBoolean();
		String = br.ReadString();
		FloatData = br.ReadSingle();
		Zu = ReadInt32Array(br);
		MA = ReadInt32ArrayMtp(br);
	}
	public override string ToString()
	{
		return  GetID() +  "|"  + GetBoolean() +  "|"  + GetString() +  "|"  + GetFloatData() +  "|"  + GetZu() +  "|"  + GetMA() +  "|" ;
	}
	 public string GetID()
	{
		string str = "";
		str += ID.ToString();
		return str;
	}
	 public string GetBoolean()
	{
		string str = "";
		str += Boolean.ToString();
		return str;
	}
	 public string GetString()
	{
		string str = "";
		str += String.ToString();
		return str;
	}
	 public string GetFloatData()
	{
		string str = "";
		str += FloatData.ToString();
		return str;
	}
	 public string GetZu()
	{
		string str = "";
		foreach (var v in Zu)
			str += v.ToString() + " ";
		return str;
	}
	 public string GetMA()
	{
		string str = "";
		foreach (var d in MA)
		{str += "[";
			foreach (var v in d)
				str += v.ToString() + " ";
			str += "]";
		}
		return str;
	}
}

public class Test_TestMR : IConfig
{
	public int Group;
	public int ID;
	public bool Boolean;
	public string String;
	public float FloatData;
	public int[] Zu;
	public int[][] MA;

	public override void MergeFrom(BinaryReader br)
	{
		Group = br.ReadInt32();
		ID = br.ReadInt32();
		Boolean = br.ReadBoolean();
		String = br.ReadString();
		FloatData = br.ReadSingle();
		Zu = ReadInt32Array(br);
		MA = ReadInt32ArrayMtp(br);
	}
	public override string ToString()
	{
		return  GetGroup() +  "|"  + GetID() +  "|"  + GetBoolean() +  "|"  + GetString() +  "|"  + GetFloatData() +  "|"  + GetZu() +  "|"  + GetMA() +  "|" ;
	}
	 public string GetGroup()
	{
		string str = "";
		str += Group.ToString();
		return str;
	}
	 public string GetID()
	{
		string str = "";
		str += ID.ToString();
		return str;
	}
	 public string GetBoolean()
	{
		string str = "";
		str += Boolean.ToString();
		return str;
	}
	 public string GetString()
	{
		string str = "";
		str += String.ToString();
		return str;
	}
	 public string GetFloatData()
	{
		string str = "";
		str += FloatData.ToString();
		return str;
	}
	 public string GetZu()
	{
		string str = "";
		foreach (var v in Zu)
			str += v.ToString() + " ";
		return str;
	}
	 public string GetMA()
	{
		string str = "";
		foreach (var d in MA)
		{str += "[";
			foreach (var v in d)
				str += v.ToString() + " ";
			str += "]";
		}
		return str;
	}

	protected override int GetKey()
	{
		return ID;
	}

	protected override int GetDicKey()
	{
		return Group;
	}
}

public class Test_Data : IConfig
{
    public Dictionary<int, Test_TestBase> TestBaseItems = new Dictionary<int, Test_TestBase>();
	public Dictionary<int, Dictionary<int, Test_TestMM>> TestMMItems = new Dictionary<int, Dictionary<int, Test_TestMM>>();
	public List<Test_TestR> TestRItems = new List<Test_TestR>();
	public Dictionary<int, List<Test_TestMR>> TestMRItems = new Dictionary<int, List<Test_TestMR>>();
    public int sheetCount;

    public override void MergeFrom(BinaryReader br)
    {
        sheetCount = br.ReadInt32();
        TestBaseItems = MakeDictionary<Test_TestBase>(br);
		TestMMItems = MakeMDictionary<Test_TestMM>(br);
		TestRItems = MakeList<Test_TestR>(br);
		TestMRItems = MakeMRDictionary<Test_TestMR>(br);
    }

	private string GetTestBaseItems()
	{
		string str = "";
		foreach (var v in TestBaseItems.Values)
			str += v.ToString() + "\n";
		return str;
	}
	private string GetTestMMItems()
	{
		string str = "";
		foreach (var t in TestMMItems.Values)
			foreach (var v in t.Values)
				str += v.ToString() + "\n";
		return str;
	}
	private string GetTestRItems()
	{
		string str = "";
		foreach (var v in TestRItems)
			str += v.ToString() + "\n";
		return str;
	}
	private string GetTestMRItems()
	{
		string str = "";
		foreach (var t in TestMRItems.Values)
			foreach (var v in t)
				str += v.ToString() + "\n";
		return str;
	}


    public override string ToString()
	{
		return GetTestBaseItems() + "\n" + GetTestMMItems() + "\n" + GetTestRItems() + "\n" + GetTestMRItems() + "\n";
	}
}
}