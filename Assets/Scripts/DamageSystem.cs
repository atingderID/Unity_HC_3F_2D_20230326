using UnityEngine;

public class DamageSystem : MonoBehaviour
{
	//使用HealthData中的血量資料
	[Header("血量資料")]
	public HealthData data;
	//設定成private的參數並不會出現在欄位裡面
	//要解決data資料不會還原的問題，我們自己設定一個hp,awake時讀取data中的滿血血量，扣血量從自己的hp扣，就不會修改到data
	private float hp;
	//今天如果將HealthDataEnemy同樣寫成public讓它出現在資料面板中使用拖拉的方式也是可行的，但缺點是今天如果有大量的角色，每個都要拉會麻煩，因此使用程式自動去抓
	private HealthDataEnemy dataEnemy;

	public void Awake()
	{
		hp = data.hp;
		//
		dataEnemy = (HealthDataEnemy)data;
	}
	//碰撞事件OCE，判斷碰撞的物體為何
	private void OnCollisionEnter2D(Collision2D collision)
	{
		//print(collision.gameObject);
		if (collision.gameObject.name.Contains("武器"))
		{
			//print("ㄚㄚㄚㄚ我被打到了");
			GetDamage();
		}
	}
	private void GetDamage()
	{
		hp -= 50;
		print("剩下的血量:" + hp);

		if (hp <= 0) Dead();
	}
	private void Dead()
	{
		Destroy(gameObject);
		DropExp();
	}
	private void DropExp()
	{
		//print("這隻怪物的掉落經驗機率:" + dataEnemy.dropprobability);
		if (Random.value<=dataEnemy.dropprobability)
		{
			Instantiate(dataEnemy.prefabExp, transform.position, transform.rotation);
		}
	}
}
