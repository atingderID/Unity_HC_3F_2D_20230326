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

	public Transform player;

	private void Awake()
	{
		player = GameObject.Find("企鵝主角").transform;
	}
	private void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
	}
}
