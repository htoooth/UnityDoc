using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MiniJSON;
using System.IO;
using System;


static public class PlanetCfg{

	public static Dictionary<string,object> OpenCfg(string path)
	{
		string jsonData = File.ReadAllText(path);
		Dictionary<string,object> json =
			Json.Deserialize(jsonData) as Dictionary<string,object>;
		return json;
	}

	public static void CloseCfg(string path,Dictionary<string,object> json)
	{
		string jsonstring = JsonFormatter.FormatJson(Json.Serialize(json));
		File.WriteAllText(path,jsonstring);
	}

	public static PlanetStat StatusFromJson(Dictionary<string,object> json)
	{
		PlanetStat result ;

		Func<object,float> d2f = x=> Convert.ToSingle((double)x);
		Func<List<object>,Vector3> convert =  
			node => new Vector3(d2f(node[0]),d2f(node[1]),d2f(node[2]));

		result.Name = json["Name"] as string;
		result.Rotate = convert(json["Rotate"] as List<object>);
		result.Radius = convert(json["Radius"] as List<object>);
		result.Factor = convert(json["Factor"] as List<object>);
		result.Perimeter =d2f(json["Perimeter"]);
		return result;
	}

	public static Dictionary<string,object> JsonFromStatus(PlanetStat status)
	{
		Dictionary<string,object> result = new Dictionary<string, object>();
		System.Func<Vector3,List<float>> convert =
			vct => new List<float>{vct.x,vct.y,vct.z};

		result["Name"] = status.Name;
		result["Rotate"] = convert(status.Rotate);
		result["Radius"] = convert(status.Radius);
		result["Factor"] = convert(status.Factor);
		result["Perimeter"] = status.Perimeter;

		return result;
	}

	public static void PrintJson(object json)
	{
		var jsonobj = json as Dictionary<string, object>;
		Debug.Log(JsonFormatter.FormatJson(Json.Serialize(jsonobj)));
	}
}
