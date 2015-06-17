using UnityEngine;
using System.Collections;

public class Hexagon : MonoBehaviour
{




	private HPosition hPos;
	//private HVehicle hVeh = null;
	private Options.State CurrentState;
	private Options.OverlayState CurrentOverlayState;

	public void ChangeStateTo (Options.State s)
	{
		CurrentState = s;

		//действия по изменению визуального отображения

	}

	public void ChangeOverlayStateTo (Options.OverlayState os)
	{
		CurrentOverlayState = os;

		//действия по изменению визуального отображения

	}

	public Options.State GetState ()
	{

		return CurrentState;
	}

	public Options.OverlayState GetOverlayState ()
	{
		
		return CurrentOverlayState;
	}


	// Use this for initialization
	void Start ()
	{
		ChangeStateTo (Options.State.Default);
		ChangeOverlayStateTo (Options.OverlayState.Default);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
