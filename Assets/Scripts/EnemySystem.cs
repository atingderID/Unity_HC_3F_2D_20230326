using System.Threading;
using UnityEngine;

/// <summary>
/// 敵人系統
/// 1. 追蹤玩家方向
/// 2. 翻面
/// </summary>
public class EnemySystem : MonoBehaviour
{
	[Header("追蹤速度"), Range(0, 100)]
	public float moveSpeed = 0.01f;
	[Header("敵人資料")]
	public HealthDataEnemy data;

	private Transform player;
	private float timer;

	//繪製圖示事件:圖示只有在Unity編輯器內看到
	private void OnDrawGizmos()
	{
		//1.決定圖示顏色
		//Color(紅,綠,藍,透明度)
		//常見於應用在格鬥遊戲，標示出不同部位的碰撞器
		Gizmos.color = new Color(1, 0.3f, 0.2f, 0.5f);
		//2. 繪製各種圖式:例如圓形
		//在此物件的座標是半徑為data.attackRange的圓形
		Gizmos.DrawSphere(transform.position, data.attackRange);
	}

	private void Awake()
	{
		player = GameObject.Find("企鵝主角").transform;
	}
	private void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
		
		float distance = Vector3.Distance(transform.position, player.position);
		if (distance<data.attackRange) Attack();
		if (transform.position.x > player.position.x) transform.eulerAngles = new Vector3(0, 0, 0);
		if (transform.position.x < player.position.x) transform.eulerAngles = new Vector3(0, 180, 0);

	}

	private void Attack()
	{
		timer += Time.deltaTime;
		//print($"<color=#99ff66>計時器:{timer}</color>");
		//如果計時器大於敵人資料內的攻擊間隔
		if(timer>data.attackInterval)
		{
			//就攻擊
			print("<color=#9966ff>攻擊玩家!</color>");
			//並且計時器歸零
			timer = 0;
		}
	}
}
