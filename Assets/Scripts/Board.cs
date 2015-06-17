using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour
{

	// Use this for initialization
	void Awake ()
	{
		float sz = Options.board_size;
		transform.localScale = new Vector3 (sz, sz, sz);
		transform.LookAt (Vector3.zero);

		transform.localPosition += transform.forward * 20f;
	}

	void Start ()
	{

		//размещение хексов с yeld return
	}

}
