using UnityEngine;
using System.Collections;

public class control_script : MonoBehaviour {
	public GameObject rock;
	public GameObject missile;
	public GameObject earth;
	GameObject trown_rock;
	GameObject missile_shot;
	float mousex;
	float mousey;
	Vector3 mouseposition;
	Vector3 mouseposition2;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Escape))Application.Quit();
		if(earth)
		{
		if (Input.GetMouseButtonDown(0))Down();
		if (Input.GetMouseButtonUp(0))
		{
			Up();
			}}
		else Application.Quit();
	}

	void Down()
	{
		Debug.Log("Down");
		mousex = (Input.mousePosition.x);
		mousey = (Input.mousePosition.y);
		Vector3 mouseposition= Camera.main.ScreenToWorldPoint(new Vector3 (mousex,mousey,2f));
		trown_rock = (Instantiate(rock,mouseposition, Quaternion.identity)) as GameObject;
	}
	void Up()
	{
		Debug.Log("Up");
		mousex = (Input.mousePosition.x);
		mousey = (Input.mousePosition.y);
		Vector3 mouseposition2= Camera.main.ScreenToWorldPoint(new Vector3 (mousex,mousey,2f));
		trown_rock.rigidbody.isKinematic=false;
		trown_rock.transform.LookAt(mouseposition2);
		trown_rock.rigidbody.velocity=trown_rock.transform.forward*5;
		if(TrajectoryWithinSafetyZone(trown_rock.transform.position,trown_rock.rigidbody.velocity))
		   {
			Debug.Log("shoot");
			missile_shot = (Instantiate(missile, earth.transform.position +new Vector3(0f,0f,-0.348083f), Quaternion.identity)) as GameObject;
			missile_shot.transform.LookAt(trown_rock.transform.position);
			missile_shot.rigidbody.velocity=CalculateMissileVelocity(trown_rock.transform.position,trown_rock.rigidbody.velocity);
		}
		else Debug.Log("safe");

	}
	bool TrajectoryWithinSafetyZone(Vector3 asteroidPosition, Vector3 asteroidVelocity)
	{ 
		RaycastHit hit;
		if(Physics.SphereCast(trown_rock.transform.position,0.6f,trown_rock.transform.TransformDirection(Vector3.forward) ,out hit  , Mathf.Infinity))
		{
			return true;
		}else{
			return false;
		}

	}
	Vector3 CalculateMissileVelocity(Vector3 asteroidPosition, Vector3 asteroidVelocity)
	{
		return missile_shot.rigidbody.velocity=missile_shot.transform.forward*5;
	}
}
