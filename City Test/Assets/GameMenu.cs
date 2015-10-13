using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {

	public bool isQuit;


	void OnMouseEnter()
	{
		gameObject.GetComponent<Renderer>().material.color = Color.red;
	}

	void OnMouseExit()
	{
		gameObject.GetComponent<Renderer>().material.color = Color.white;
	}


	void OnMouseUp()
	{
		if(isQuit==true)
			Application.Quit();
		else
			Application.LoadLevel("iso-buildings");

	}

}
