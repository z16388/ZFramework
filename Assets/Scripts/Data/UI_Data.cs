// This is an automatically generated file. Please do not modify it
using System.Collections.Generic;
using System.IO;

namespace ConfigData {

public class UI_UIPackages : IConfig
{
	public int ID;
	public string PackageName;
	public string Name;

	public override void MergeFrom(BinaryReader br)
	{
		ID = br.ReadInt32();
		PackageName = br.ReadString();
		Name = br.ReadString();
	}
	public override string ToString()
	{
		return  GetID() +  "|"  + GetPackageName() +  "|"  + GetName() +  "|" ;
	}
	 public string GetID()
	{
		string str = "";
		str += ID.ToString();
		return str;
	}
	 public string GetPackageName()
	{
		string str = "";
		str += PackageName.ToString();
		return str;
	}
	 public string GetName()
	{
		string str = "";
		str += Name.ToString();
		return str;
	}
}

public class UI_Data : IConfig
{
    public List<UI_UIPackages> UIPackagesItems = new List<UI_UIPackages>();
    public int sheetCount;

    public override void MergeFrom(BinaryReader br)
    {
        sheetCount = br.ReadInt32();
        UIPackagesItems = MakeList<UI_UIPackages>(br);
    }

	private string GetUIPackagesItems()
	{
		string str = "";
		foreach (var v in UIPackagesItems)
			str += v.ToString() + "\n";
		return str;
	}


    public override string ToString()
	{
		return GetUIPackagesItems() + "\n";
	}
}
}