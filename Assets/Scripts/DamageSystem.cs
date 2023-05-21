using UnityEngine;

public class DamageSystem : MonoBehaviour
{
	//使用HealthData中的血量資料
	[Header("血量資料")]
	public HealthData data;
	//碰撞事件OCE，判斷碰撞的物體為何
	private void OnCollisionEnter2D(Collision2D collision)
	{
		//print(collision.gameObject);
		if (collision.gameObject.name.Contains("武器"))
		{
			print("ㄚㄚㄚㄚ我被打到了");
		}
	}
}
