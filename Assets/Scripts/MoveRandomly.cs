using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomly : MonoBehaviour {

    private Vector3 StartPosition;
    private Vector3 Destination;
    private float MoveSpeed;

	// Use this for initialization
	private void Awake()
    {
        StartPosition = gameObject.transform.position;
        StartCoroutine(ChangeDirection());
	}

    private IEnumerator ChangeDirection()
    {
        Vector3 startPosition = new Vector3(StartPosition.x, StartPosition.y, StartPosition.z);
        Destination = startPosition += new Vector3(Random.Range(-15, 15), Random.Range(-7, 20));
        MoveSpeed = Random.Range(5, 15);
        yield return new WaitForSeconds(Random.Range(2, 5));
        StartCoroutine(ChangeDirection());
    }
	
	// Update is called once per frame
	private void Update ()
    {
        Vector3 position = gameObject.transform.position;
        gameObject.transform.position = Vector3.MoveTowards(position, Destination, MoveSpeed * Time.deltaTime);	
	}
}
