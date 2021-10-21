using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	Transform player;

	public float speed = 2f;

	public bool isFiring;

	void Start()
	{
		player = FindObjectOfType<Player>().transform;

		isFiring = false;
	}

	void Update()
	{
		if (isFiring)
		{
			transform.localScale = transform.localScale + Vector3.up * Time.deltaTime * speed;
		}
		else
		{
			transform.position = player.position;
			transform.localScale = new Vector3(0.4f, 0f, 0f);

			player.GetComponentInParent<Player>().anim.SetBool("Shoot", false);
		}

	}

	public void StartShoot()
	{
		isFiring = true;
		player.GetComponentInParent<Player>().anim.SetBool("Shoot", true);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == ("Ground") || collision.gameObject.tag == ("Bubble"))
		{
			isFiring = false;
		}
	}
}
