using UnityEngine;
using System.Collections;

public class AffectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision coll)
	{
		Debug.Log(coll.gameObject.name);
		if(coll.gameObject.tag=="People")
			Debug.Log ("Collided with other people!");
	}

}
