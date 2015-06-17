using UnityEngine;
using System.Collections;

public class HPosition:MonoBehaviour
{

	private int sector;
	private int ring;
	private int offset;
	private int SZ = Options.board_size;
	private int DIM = Options.dimensions;
	private bool valid;
	private int[] degOffsets = {0, 60, 120, 180, 240, 300, 360};
	//private string str = "ABCDEF";


//	void SetPos (char c, params int[] iArr)
//	{
//
//		if (!char.IsLetter(c)) {
//			HNumberPosition (iArr [0], iArr [1], iArr [2]);
//		} else
//		if (cArr [0].GetType () == typeof(char)) {
//			HCharPosition (cArr [0], iArr [0], iArr [1]);
//		}
//
//	}

	public int[] GetPos ()
	{

		int[] ret = {0,0,0};
		ret [0] = sector;
		ret [1] = ring;
		ret [2] = offset;
		Debug.Log (ret [0].ToString () + "  " + ret [1].ToString () + "  " + ret [2].ToString ());
		return ret;
	}

	public Vector3 GetXYZ ()
	{
		int[] pos = {0,0,0};

		int SZR = (int)(SZ / 2);
		float dOfst, dOfstNext;     //начальный и конечный угол сектора
		Vector2 point = new Vector2 (0, 0), pointNext = new Vector2 (0, 0); //позиции наиболее удаленных хексов от центра
		Vector2 zero = new Vector2 (0, 0);



		if (valid)
			pos = GetPos ();

		dOfst = degOffsets [pos [0]] * Mathf.Deg2Rad;
		dOfstNext = degOffsets [pos [0] + 1] * Mathf.Deg2Rad;

		point.Set (SZR * Mathf.Cos (dOfst), SZR * Mathf.Sin (dOfst));
		pointNext.Set (SZR * Mathf.Cos (dOfstNext), SZR * Mathf.Sin (dOfstNext));

		//аппроксимируем
		point = Vector2.Lerp (zero, point, pos [1] / (DIM - 1));
		pointNext = Vector2.Lerp (zero, pointNext, pos [1] / (DIM - 1)); //разобраться с индексами!!!

		//аппроксимируем между ними
		point = Vector2.Lerp (point, pointNext, (pos [2] - 1) / pos [1]);

		Vector3 ret = new Vector3 (point.x, point.y, 0);

		return ret;

	}
	public bool HIntSet (int x, int y, int z)
	{


		valid = true;
		if (x >= 1 && x <= 6)
			sector = x;
		else
			valid = false;
		if (valid && y >= 1 && y <= DIM)
			ring = y;
		else
			valid = false;
		if (valid && z >= 1 && z <= y)
			offset = z;
		else
			valid = false;

		return valid;

	}

	public bool HCharSet (char cc, int y, int z)
	{

		int _x = 0;
		valid = true;

		switch (cc) {

		case 'A':
			_x = 1;
			break;
		case 'B':
			_x = 2;
			break;
		case 'C':
			_x = 3;
			break;
		case 'D':
			_x = 4;
			break;
		case 'E':
			_x = 5;
			break;
		case 'F':
			_x = 6;
			break;
		default:
			valid = false;
			break; 
		}

		if (valid)
			return this.HIntSet (_x, y, z);
		else
			return false;

	}

	public bool Valid ()
	{
		return valid;
	}
}
