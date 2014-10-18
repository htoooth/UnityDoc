using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(PlanetStat))]
[CanEditMultipleObjects]
public class StatusEditor : Editor {

	public SerializedProperty rotate,factor,name,radius,perimeter;

	void OnEnable()
	{
		rotate = serializedObject.FindProperty("rotate");
		factor = serializedObject.FindProperty("factor"); 
		name = serializedObject.FindProperty("name");
		radius = serializedObject.FindProperty("radius");
		perimeter = serializedObject.FindProperty("perimeter");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		if(!factor.hasMultipleDifferentValues)
		{
			factor.vector3Value = EditorGUILayout.Vector3Field("Factor",factor.vector3Value);
		}

		serializedObject.ApplyModifiedProperties();
	}
}
