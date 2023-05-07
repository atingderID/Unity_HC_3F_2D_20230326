using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
	[Header("生成間隔"),Range(0,10)]
	public float interval = 3.5f;

	[Header("怪物預製物")]
	public GameObject prefabEnemy;

	private void SpawnEnemy()
	{
		//生成物件的功能(生成物件，生成座標，生成角度)
		Instantiate(prefabEnemy, transform.position, transform.rotation);
	}

	private void Awake()
	{
		//重複呼叫功能的方式("要重複呼叫的方法",幾秒後開始,間隔幾秒)
		InvokeRepeating("SpawnEnemy",0,interval);
	}
}
