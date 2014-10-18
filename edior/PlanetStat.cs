using UnityEngine;
using System.Collections;

[System.Serializable]
public struct PlanetStat {
	public string Name ;
	public Vector3 Rotate;
	public Vector3 Radius;
	public Vector3 Factor;
	public float Perimeter;

	public static bool operator ==(PlanetStat st1,PlanetStat st2)
	{
		if(st1.Name != st2.Name) return false;
		if(st1.Radius != st2.Radius) return false;
		if(st1.Rotate != st2.Rotate) return false;
		if(st1.Factor != st2.Factor) return false;
		if(st1.Perimeter != st2.Perimeter) return false;
		return true;
	}

	public static bool operator !=(PlanetStat st1,PlanetStat st2)
	{
		return !(st1 == st2);
	}
}
