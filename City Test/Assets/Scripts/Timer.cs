using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {


	AudioSource audioSrc;
	public AudioClip bgMusic;
	private GUIStyle style = new GUIStyle();
	public float timer = 30.0f;
	bool isOver;


	// Use this for initialization
	void Start () {
		audioSrc = GetComponent<AudioSource>();
		audioSrc.Play();
	}
	
	// Update is called once per frame
	void Update () {
		timer-=Time.deltaTime;

		if(timer>0)
		{
			//ActualTime.text = timer.ToString("F");
		}
		else
		{
			Time.timeScale = 0;
			isOver = true;

			if(Input.GetKeyDown(KeyCode.R))
			{
				Time.timeScale = 1;
				Application.LoadLevel(Application.loadedLevel);
			}
		
		}

	}

	void OnGUI()
	{
		style.fontSize = 40;

		if(isOver)
			GUI.Label(new Rect(1300,20,100,20),"Game Over!",style);

		GUI.Label(new Rect(300,20,100,20),"Time",style);
		GUI.Label(new Rect(300,60,100,20),timer.ToString(),style);

	}

}
