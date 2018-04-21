using UnityEngine;
using System.Collections;

public class MouseOver : MonoBehaviour {
	public static bool mouseOver = false;

	void OnMouseOver(){
		mouseOver = true;
	}
	void OnMouseExit (){
		mouseOver = false;
	}
}