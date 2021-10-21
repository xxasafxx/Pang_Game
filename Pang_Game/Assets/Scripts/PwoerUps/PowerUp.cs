using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
	public PowerUps powerUps;
	PickUpHandler pickUp;

	void Start()
	{
		pickUp = FindObjectOfType<PickUpHandler>();
		pickUp.SpawnObject();

		Destroy(gameObject, 4);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			pickUp.SpawnObject();

			if (this.gameObject.GetComponent<PowerUp>().powerUps == PowerUps.BOOST)
			{
				pickUp.AddBoost();
			}
			else if (this.gameObject.GetComponent<PowerUp>().powerUps == PowerUps.SHILD)
			{
				pickUp.AddShild();
			}
			else if (this.gameObject.GetComponent<PowerUp>().powerUps == PowerUps.FasterGun)
			{
				pickUp.AddFasterGun();
			}

			Destroy(gameObject);
		}
	}
}
