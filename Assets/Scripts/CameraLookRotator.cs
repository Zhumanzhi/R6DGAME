using UnityEngine;
using System.Collections;

public class CameraLookRotator : MonoBehaviour
{

	public GameObject[] rotatorPoints;
	private int lookIndex = 0;
	private float speed = 2;
	private Vector3 targetStart;	// Use this for initialization
	private Vector3 targetEnd;
	private bool started = true;
	private bool moving = false;
	private int camSwitch = 0;
	private float speedFactor = 1.0f;
	private bool camMoving = false;
	private GameObject cam;
	private Vector3 FarCamPos = new Vector3 (0, 0, 1000);
	private Vector3 NearCamPos = new Vector3 (0, 0, 600);
	private Vector3 distance, camStart, camEnd;

	void Awake ()
	{


	}

	void Start ()
	{

		lookIndex = 0;
		targetStart = rotatorPoints [lookIndex].transform.position; 
		transform.LookAt (targetStart, Vector3.up);
		lookIndex = 1;
		targetEnd = rotatorPoints [lookIndex].transform.position;

		cam = GameObject.Find ("Camera");

		Debug.Log ("Starting");

		camSwitch = -1;
	}
	
	// Update is called once per frame
	void Update ()
	{


		if (Input.GetKeyDown (KeyCode.Space) && !started && !moving && !camMoving) { 
			if (!started) {
				switch (lookIndex) {
				case 1:
					targetStart = rotatorPoints [lookIndex].transform.position;
					lookIndex = 2;
					break;
				case 2:
					targetStart = rotatorPoints [lookIndex].transform.position;
					lookIndex = 1;
					break;

				}
			}
				
				
			targetEnd = rotatorPoints [lookIndex].transform.position;
			moving = true;
			camSwitch = 1;
						
		} 

		targetStart = Vector3.Lerp (targetStart, targetEnd, Time.deltaTime * speed * 0.5f);
		transform.LookAt (targetStart, Vector3.up);

		distance = targetStart - targetEnd;
		if (distance.magnitude < 50) {
			if (started) {
				started = false;
				Debug.Log ("Starting Finished");
			}
			if (moving) {
				moving = false;
				Debug.Log ("Select Finished");
				//camSwitch=-1;
			}
		}
		if ((distance.magnitude < 350) && moving && !camMoving) {
		
			camSwitch = -1;
		}


	}

	void LateUpdate ()
	{
		switch (camSwitch) {

		case 1:
			camStart = NearCamPos;
			camEnd = FarCamPos;
			camSwitch = 0;
			camMoving = true;
			speedFactor = 5;
			break;
		case -1:
			camStart = FarCamPos;
			camEnd = NearCamPos;
			camSwitch = 0;
			camMoving = true; 
			speedFactor = 1;
			break;
		}

			
		camStart = Vector3.Lerp (camStart, camEnd, Time.deltaTime * speedFactor);
		cam.transform.localPosition = camStart;

		var dist = new Vector3 ();
		dist = camStart - camEnd;
		if (dist.magnitude < 30)
			camMoving = false;
	}

}
