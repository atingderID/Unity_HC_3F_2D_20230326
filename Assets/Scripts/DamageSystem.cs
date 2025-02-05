﻿using TMPro;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
	//使用HealthData中的血量資料
	[Header("血量資料")]
	public HealthData data;
	[Header("畫布傷害值")]
	public GameObject prefabDamage;
	//設定成private的參數並不會出現在欄位裡面
	//要解決data資料不會還原的問題，我們自己設定一個hp,awake時讀取data中的滿血血量，扣血量從自己的hp扣，就不會修改到data
	protected float hp;
	//今天如果將HealthDataEnemy同樣寫成public讓它出現在資料面板中使用拖拉的方式也是可行的，但缺點是今天如果有大量的角色，每個都要拉會麻煩，因此使用程式自動去抓
	protected float hpMax;

	public void Awake()
	{
		hp = data.hp;
		hpMax = hp;
	}

	public virtual void GetDamage(float damage)
	{
		hp -= damage;
		//print("剩下的血量:" + hp);
		GameObject tempDamage=Instantiate(prefabDamage, transform.position,Quaternion.identity);
		//Quaternion是零度角
		tempDamage.transform.Find("文字傷害值").GetComponent<TextMeshProUGUI>().text = damage.ToString();
		Destroy(tempDamage, 1.5f);
		//1.5秒後刪除物件
		if (hp <= 0) Dead();
	}
	protected virtual void Dead()
	{
	
	}
	
}
