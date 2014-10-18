using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(OrbitCfg))]
public class OrbitEditor : Editor {

	public override void OnInspectorGUI()
	{
		OrbitCfg myTarget = (OrbitCfg)target;
		myTarget.EarthOrbit = EditorGUILayout.FloatField("EarthOrbit", myTarget.EarthOrbit);

		serializedObject.Update();
		EditorGUIUtility.LookLikeInspector();
		SerializedProperty tps = serializedObject.FindProperty ("planets");
		EditorGUI.BeginChangeCheck();
		EditorGUILayout.PropertyField(tps, true);
		if(EditorGUI.EndChangeCheck())
			serializedObject.ApplyModifiedProperties();
		EditorGUIUtility.LookLikeControls();

		if(GUILayout.Button("Apply Every Orbit"))
		{
			for(var i = 0; i< myTarget.planets.Length; i++)
			{
				var radius = myTarget.Au[i] * myTarget.EarthOrbit;
				myTarget.planets[i].transform.localScale = new Vector3(radius, radius, radius);
			}
		}
	}



}
