using UnityEngine;
using System.Collections;

public class OrbitCfg : MonoBehaviour {

	// Use this for initialization
	public GameObject[] planets;
	public float[] Au = new float[]{
		0.38709f, 0.72332f, 
		1.00000f, 1.52367f,
		5.20426f, 9.58201f, 
		19.1892f, 30.0709f};

	public float EarthOrbit = 100;

	void Start () {
		for(var i = 0; i< planets.Length; i++)
		{
			var radius = Au[i] * EarthOrbit;
			planets[i].transform.localScale = new Vector3(radius, radius, radius);
		}

	}
}
