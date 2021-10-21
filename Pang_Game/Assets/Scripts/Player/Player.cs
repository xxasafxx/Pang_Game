using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	PickUpHandler pickUpHandler;
	AudioSource audioSource;
	Rigidbody2D rb;
	GameHandler handler;
	public Animator anim;

	[Header("Audio")]
	[SerializeField] private AudioClip gameOverClip;

	[Header("Movement")]
	public float moveSpeed = 5f;
	private bool isLeft = false;
	private bool isRight = false;

	[Header("Effact")]
	[SerializeField] private GameObject gameOverEffect;

	[Header("Health")]
	[SerializeField] private int curHealth = 3;

	void Start()
    {
		pickUpHandler = FindObjectOfType<PickUpHandler>();
		handler = FindObjectOfType<GameHandler>();
		audioSource = GetComponent<AudioSource>();

		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();

		gameOverEffect.SetActive(false);
	}

	private void Update()
	{
		if (isLeft == true)
		{
			MoveLeft();
		}
		else if (isRight == true)
		{
			MoveRight();
		}
	}

	private void MoveLeft()
	{
		rb.velocity = new Vector2(-moveSpeed, 0);
		anim.SetBool("Left", true);
		anim.SetBool("Shoot", false);
	}

	private void MoveRight()
	{
		rb.velocity = new Vector2(moveSpeed, 0);
		anim.SetBool("Right", true);
		anim.SetBool("Shoot", false);
	}

	public void PointerDownLeft()
	{
		isLeft = true;
		MoveLeft();
	}

	public void PointerDownRight()
	{
		isRight = true;
		MoveRight();
	}

	public void StopMove()
	{
		isLeft = false;
		isRight = false;
		anim.SetBool("Left", false);
		anim.SetBool("Right", false);

		rb.velocity = Vector2.zero;
	}


	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(pickUpHandler.isShildOn == false)
		{
			if (collision.gameObject.tag == "Bubble")
			{
				curHealth--;

				Destroy(GameObject.Find("Life_Holder").transform.GetChild(0).gameObject);


				if (curHealth <= 0)
				{

					gameOverEffect.SetActive(true);
					audioSource.PlayOneShot(gameOverClip);

					handler.ChackUI();

					Destroy(gameObject, 1);
				}
			}
		}
		
	}
	
}
