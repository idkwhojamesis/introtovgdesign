using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
	public GameObject explosionPrefab;

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "bullet2Tag")
		{
			Destroy(other.gameObject);
			Invoke("Explode", 0.2f);
			Debug.Log("hit");
		}
	}

	void Explode()
	{
		Instantiate(explosionPrefab, transform.position, transform.rotation);
		Destroy(gameObject);
		Debug.Log("explode");
	}
}
