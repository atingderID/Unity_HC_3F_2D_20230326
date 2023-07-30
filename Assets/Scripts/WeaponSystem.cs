using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
	//欄位資料
	[Header("生成間隔"), Range(0, 10)]
	public float interval = 3.5f;
	[Header("武器預製物")]
	public GameObject prefabWeapon;
	[Header("武器生成位置")]
	public Transform pointWeapon;

	private void SpwanWeapon()
	{
		Instantiate(prefabWeapon, pointWeapon.position, pointWeapon.rotation);
		AudioClip sound = SoundManager.instance.playeeShoot;
		SoundManager.instance.PlaySound(sound, 0.7f, 2);
	}
	private void Awake()
	{
		InvokeRepeating("SpwanWeapon", 0, interval);
	}
}
