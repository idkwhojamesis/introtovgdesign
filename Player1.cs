using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public GameObject bulletPF, enemyPF;
    public AudioSource Gunfire;
    Camera eyes2;
    private int bulletCount;
    GameObject ob1;
     float enemyMove = 4f;
     float enemyMoveTime = 4f;
     float enemyMoveTimeLeft;

    public float bulletUp = .5f, bulletFwd=.75f, bulletSp=20f;
    // Start is called before the first frame update
    void Start()
    {
       print("Start");
       eyes2 = Camera.main;
       ob1 = (GameObject)Instantiate(enemyPF, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
	{
		bulletCount++;
		if (bulletCount % 4 == 0)
		{
			GameObject nb = (GameObject)Instantiate(bulletPF, transform.position + bulletFwd * transform.forward + bulletUp * transform.up, transform.rotation);
			nb.GetComponent<Rigidbody>().velocity = eyes2.transform.forward * bulletSp;
			Gunfire.Play();
		}
	}
	if (Input.GetKeyDown(KeyCode.M))
	{
		Vector3 pos = new Vector3(Random.Range(0f, 25f), 0.55f, Random.Range(30f, 25f));
		ob1 = (GameObject)Instantiate(enemyPF, pos, Quaternion.identity);
		enemyMove = enemyMoveTime;
	}
	enemyMoveTimeLeft -= Time.deltaTime;
	if (enemyMoveTimeLeft <= 0f)
	{
		enemyMoveTimeLeft = enemyMoveTime;
		enemyMove *= -1f;
	}
	ob1.GetComponent<Rigidbody>().velocity = transform.right * enemyMove;
    }
}
