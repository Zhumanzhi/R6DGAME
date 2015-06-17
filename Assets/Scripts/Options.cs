using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour
{
	public enum State
	{
		Default,
		Marked,
		Vehicle,
		Damaged,
		Miss,
		Fogged}
	;
	public enum OverlayState
	{
		Default,
		RedHover,
		GreenHover,
		BlickHover}
	;

	public static int dimensions = 7;
	public static int board_size = 100;
	public static float margin = 0.5f;
	public static float hex_size = board_size / (2 * dimensions - 1) - margin;


}
