using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHandler : MonoBehaviour
{
	Player player;
	Bullet bullet;

	[Header("PowerUps")]
	[SerializeField] private List<GameObject> Items = new List<GameObject>();
	[SerializeField] private List<Transform> Points = new List<Transform>();

	[Header("Boost")]
	[SerializeField] private float boostTime;

	[Header("Shild")]
	public bool isShildOn = false;
	[SerializeField] private GameObject shildObj;
	[SerializeField] private float shildTime;

	[Header("Weapon")]
	[SerializeField] private float weaponTime;

	private void Start()
	{
		StartCoroutine(SpawnObjectWithDelay());
	}

	///  FasterGun /////////////////////////////////////////
	public void AddFasterGun()
	{
		bullet = FindObjectOfType<Bullet>();
	
		bullet.speed = 5;

		StartCoroutine(ReduseFasterGun());
	}

	IEnumerator ReduseFasterGun()
	{
		yield return new WaitForSeconds(weaponTime);

		bullet.speed = 3;

		StopCoroutine(ReduseFasterGun());
	}

	///  SHILD /////////////////////////////////////////
	public void AddShild()
	{
		shildObj.SetActive(true);
		isShildOn = true;

		StartCoroutine(ReduseShild());
	}

	IEnumerator ReduseShild()
	{
		yield return new WaitForSeconds(shildTime);

		shildObj.SetActive(false);
		isShildOn = false;

		StopCoroutine(ReduseShild());
	}

	///  BOOST /////////////////////////////////////////

	public void AddBoost()
	{
		player = FindObjectOfType<Player>();

		player.moveSpeed = 10;

		StartCoroutine(RedusBoost());
	}

	
	IEnumerator RedusBoost()
	{
		yield return new WaitForSeconds(boostTime);

		player.moveSpeed = 5;

		StopCoroutine(RedusBoost());
	}

	///  Spawn /////////////////////////////////////////

	public void SpawnObject()
	{
		StartCoroutine(SpawnObjectWithDelay());
	}

	IEnumerator SpawnObjectWithDelay()
	{
		yield return new WaitForSeconds(10);

		Instantiate(Items[Random.Range(0, Items.Capacity)], Points[Random.Range(0, Points.Capacity)].position, Quaternion.identity);

		StopCoroutine(SpawnObjectWithDelay());
	}
}

public enum PowerUps
{
	BOOST,
	SHILD,
	FasterGun,
}
