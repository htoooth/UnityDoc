using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(Planet))]
[CanEditMultipleObjects]
public class PlanetEditor : Editor {

	public override void OnInspectorGUI()
	{

		Planet myTarge = (Planet)target;
		DrawDefaultInspector();
		if(GUILayout.Button("Reset This Planet"))
		{
			GetIintStat(myTarge);
		}

	}

	void GetIintStat(Planet target){
		var json = PlanetCfg.OpenCfg(Application.dataPath + "/StreamingAssets/planet.cfg");
		var data = json[target.gameObject.name] as Dictionary<string,object>;
		target.status = PlanetCfg.StatusFromJson(data);
	}
}
