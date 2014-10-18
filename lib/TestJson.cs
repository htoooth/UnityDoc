using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class TestJson : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string jsonString = "{ \"array\": [1.44,22,33]" +  
			"\"object\": {\"key1\":\"value1\", \"key2\":256}, " +  
				"\"string\": \"The\", " +  
				"\"int\": 65536, " +  
				"\"float\": 3.1415926, " +  
				"\"bool\": true, " +  
				"\"null\": null }";  
		
		Dictionary<string, object> dict = 
			Json.Deserialize(jsonString) as Dictionary<string, object>;
		
		Assert.Test(Json.Get<long>(dict,"array.1") == 22);
		Assert.Test(Json.Get<double>(dict,"array.0") == 1.44);
		Assert.Test(Json.Get<bool>(dict,"bool") == true);
		Assert.Test(Json.Get<string>(dict,"string") == "The");
		
		Json.Set<long>(dict,"array.1",100);
		Json.Set<double>(dict,"array.0",2.44);
		Json.Set<bool>(dict,"bool",false);
		Json.Set<string>(dict,"string","Hello");
		
		Assert.Test(Json.Get<long>(dict,"array.1") == 100);
		Assert.Test(Json.Get<double>(dict,"array.0") == 2.44);
		Assert.Test(Json.Get<bool>(dict,"bool") == false);
		Assert.Test(Json.Get<string>(dict,"string") == "Hello");

		// test status to json and json to status
		var vet = new List<float>{1.0f,2.0f,3.0f};
		Dictionary<string,object> jsonObj = new Dictionary<string, object>();
		jsonObj["Name"] = "地球";
		jsonObj["Rotate"] = vet;
		jsonObj["Radius"] = vet;
		jsonObj["Factor"] = vet;
		jsonObj["Perimeter"] = 100.00f;

		var st = PlanetCfg.StatusFromJson(jsonObj);
		var jsonObj2 = PlanetCfg.JsonFromStatus(st);
		var st1 = PlanetCfg.StatusFromJson(jsonObj2);

		Debug.Log(st1);
		string jsonString1 = Json.Serialize(jsonObj);
		string jsonString2 = Json.Serialize(jsonObj2);

		Assert.Test(jsonString1 == jsonString2);
		Assert.Test(st == st1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
