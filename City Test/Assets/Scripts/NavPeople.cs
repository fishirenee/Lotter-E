using UnityEngine;
using System.Collections;

public class NavPeople : MonoBehaviour {

	public Transform[] wayPoints;
	private NavMeshAgent navComponent;
	public Material[] myMaterial;
	private int currentWayPoint = 0;
	private int maxwayPoint;
	public float minwaypointDist = 4.5f;
	private bool hasPower;
	public bool hasCollided;

	// Use this for initialization
	void Start () {
		currentWayPoint = Random.Range(0,4);
		navComponent = GetComponent<NavMeshAgent>();
		maxwayPoint = wayPoints.Length - 1;
		gameObject.GetComponent<Renderer>().material = myMaterial[0];
		//isAffected = false;		//default is false but was giving weird warnings
		this.hasCollided =  false;

	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 templocalPosition;
		Vector3 tempwaypointPosition;

		templocalPosition = transform.position;
		tempwaypointPosition = wayPoints[currentWayPoint].position;


		if(Vector3.Distance(templocalPosition,tempwaypointPosition) <= minwaypointDist)
		{
			if(currentWayPoint == maxwayPoint)
			{	
				currentWayPoint = 0;
			}	
			else
				currentWayPoint = Random.Range(0,4);
		}

		navComponent.SetDestination(wayPoints[currentWayPoint].position);
	}


	public void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.name == "Field")
		{	
			this.hasPower = true;
			if(FieldScript.NumberOfPeopleAffected > 0)
			{	
				FieldScript.NumberOfPeopleAffected--;
				gameObject.GetComponent<Renderer>().material = myMaterial[1];
				StartCoroutine(WaitingToo());
			}
		}
	}

	public void OnCollisionEnter(Collision coll)
	{
		if(this.hasPower)
			if(coll.gameObject.tag=="People")
			{	
				if(FieldScript.NumberOfPeopleAffected <= 20)
				{	

					if(coll.gameObject.GetComponent<NavPeople>().hasPower == false)
					{
						FieldScript.NumberOfPeopleAffected++;
						coll.gameObject.GetComponent<NavPeople>().hasPower = true;
						coll.gameObject.GetComponent<Renderer>().material = myMaterial[1];
						StartCoroutine(Waiting(coll));
					}
				}
		}
	}

	IEnumerator WaitingToo()
	{
		yield return new WaitForSeconds(3.5f);
		gameObject.GetComponent<Renderer>().material = myMaterial[2];
	}

	IEnumerator Waiting(Collision coll)													//Change color to orange after sometime
	{
		yield return new WaitForSeconds(4.5f);
		coll.gameObject.GetComponent<Renderer>().material = myMaterial[2];
		Destroy(gameObject.GetComponent<CapsuleCollider>());
		this.hasPower = false;
	}
	




}
