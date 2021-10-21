using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
	AudioSource audioSource;
	Rigidbody2D rb;
	
	[SerializeField] private Vector2 force;
	[SerializeField] private GameObject SmallerBubble;

	[Header("Audio")]
	[SerializeField] private AudioClip PopClip;

	[Header("Effact")]
	[SerializeField] private GameObject fireEffect;

	void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		audioSource = GetComponent<AudioSource>();

		rb.AddForce(force,ForceMode2D.Impulse);
    }

	public void SplitBalls()
	{
		if(SmallerBubble != null)
		{
			GameObject temp1 = Instantiate(SmallerBubble, rb.position + Vector2.right / 4f, Quaternion.identity); // Instantiate 4 units for the right
			GameObject temp2 = Instantiate(SmallerBubble, rb.position + Vector2.left / 4f, Quaternion.identity); // Instantiate 4 units for the left

			temp1.GetComponent<Bubble>().force = new Vector2(2f, 5f); // add force to the bubble for the left movement
			temp2.GetComponent<Bubble>().force = new Vector2(-2f, 5f); // add force to the bubble for the right movement
		}

		GameHandler.AddPoints(100);
		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "TankBullet")
		{
			audioSource.PlayOneShot(PopClip);

			GameObject effectTemp =  Instantiate(fireEffect, transform.position, Quaternion.identity);

			Destroy(effectTemp, .5f);

			SplitBalls();

		}
	}
}
