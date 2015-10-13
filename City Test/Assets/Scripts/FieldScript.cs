using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FieldScript : MonoBehaviour {


	AudioSource src;
	public AudioClip clip;
	private GUIStyle styl = new GUIStyle();
	public GameObject Field;
	public static int NumberOfPeopleAffected = 0;

	// Use this for initialization
	void Start () {
		Field.SetActive(false);
		src= GetComponent<AudioSource>();
		
	}


	void Update()
	{
		if(Input.GetKey(KeyCode.Mouse0))
		{	
			Field.SetActive(true);
			src.PlayOneShot(clip);
		}
		else
			Field.SetActive(false);


		if(NumberOfPeopleAffected==20)
		{	

			Time.timeScale = 0;
		}
	}

	void OnGUI()
	{
		styl.fontSize = 40;
		GUI.Label(new Rect(700,30,200,400),"People Affected",styl);
		GUI.Label(new Rect(700,70,200,400),NumberOfPeopleAffected.ToString(),styl);
	}
}
