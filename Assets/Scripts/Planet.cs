using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{

	public Transform board;

	private GameObject PlayerBoard1, PlayerBoard2;
	private Vector3 tempPos;
	//private Transform tempTrans;

	void Awake ()
	{
		//board.transform.localScale = new Vector3 (sz, sz, sz);


		tempPos = GameObject.Find ("BasePoint1").transform.position;
		PlayerBoard1 = Instantiate (board, tempPos, Quaternion.identity) as GameObject; 

		tempPos = GameObject.Find ("BasePoint2").transform.position;
		PlayerBoard2 = Instantiate (board, tempPos, Quaternion.identity) as GameObject;


		
	}
}
