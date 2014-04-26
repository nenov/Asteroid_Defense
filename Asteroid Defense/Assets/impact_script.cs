using UnityEngine;
using System.Collections;

public class impact_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) 
	{
		Debug.Log("collision");
		Destroy(gameObject);
		Destroy(other.gameObject);
	}

}
