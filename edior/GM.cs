using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GM : MonoBehaviour {

	// Use this for initialization
	Dictionary<string,object> json;

	string address  = string.Empty;
	string addressPlanet = string.Empty;

	void Awake(){
		addressPlanet = Application.persistentDataPath + "/planet.cfg";
//		address = Application.dataPath + "/StreamingAssets/planet.cfg";
	}

	void Find(System.Action<GameObject> func){
		GameObject[] gos = GameObject.FindGameObjectsWithTag("Planet");
		foreach(var go in gos)
		{
			func(go);
		}
	}

	void LoadArchives(){
		json = PlanetCfg.OpenCfg(addressPlanet);
		Find((go)=>{
			var status = go.GetComponent<Planet>();
			var data = json[go.name] as Dictionary<string,object>;
			status.status = PlanetCfg.StatusFromJson(data);
		});
	}

	void Archives(){
		Find((go)=>{
			var status = go.GetComponent<Planet>();
			var data = PlanetCfg.JsonFromStatus(status.status);
			json[go.name] = data;
		});
		PlanetCfg.CloseCfg(addressPlanet,json);
	}

	string x = string.Empty;
	string y = string.Empty;
	string z = string.Empty;
	public GameObject planet;

	void OnGUI()
	{
		if(GUI.Button(new Rect(10f,20f,50f,50f),"load")){
			LoadArchives();
		}
		if(GUI.Button(new Rect(10f,70f,50f,50f),"save")){
			Archives();
		}

		GUI.Label(new Rect(10f,120f,20f,20f),"x:");
		x = GUI.TextField(new Rect(30f,120f,60f,20f),x);

		GUI.Label(new Rect(10f,140f,20f,20f),"y:");
		y = GUI.TextField(new Rect(30f,140f,60f,20f),y);

		GUI.Label(new Rect(10f,160f,20f,20f),"z:");
		z = GUI.TextField(new Rect(30f,160f,60f,20f),z);

		if(GUI.Button(new Rect(10f,180f,60f,20f),"update")){
			float xr = float.Parse(x);
			float yr = float.Parse(y);
			float zr = float.Parse(z);

			Planet pl = planet.GetComponent<Planet>();
			var st = pl.status;
			st.Rotate = new Vector3(xr,yr,zr);

			pl.status = st;
		}
	}
}
