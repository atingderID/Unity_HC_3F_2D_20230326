using UnityEngine;

//使用繼承概念，class名稱要使用父程式的名稱
[CreateAssetMenu(menuName ="Stella/HealthDataEnemy")]
public class HealthDataEnemy : HealthData
{
	[Header("經驗值物件")]
	public GameObject prefabExp;
	[Header("掉落經驗值機率"), Range(0, 1)]
	public float dropprobability;
}
