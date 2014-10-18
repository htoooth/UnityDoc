using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {

	[SerializeField]
	public PlanetStat status ;

	public bool isPause;

	void Start(){
		isPause = false;
	}

	// Update is called once per frame
	void Update () {
		if(isPause) return;
		Run();
	}

	void OnPauseGame()
	{
		isPause = true;
	}

	void OnResumeGame()
	{
		isPause = false;
	}

	void Run()
	{
		transform.Rotate(Vector3.right * Time.deltaTime * status.Rotate.x * status.Factor.x,Space.World);
		transform.Rotate(Vector3.up * Time.deltaTime * status.Rotate.y * status.Factor.y,Space.World);
		transform.Rotate(Vector3.forward * Time.deltaTime * status.Rotate.z * status.Factor.z,Space.World);
	}
}
