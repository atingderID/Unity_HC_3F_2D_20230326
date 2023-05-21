using UnityEngine;

[CreateAssetMenu(menuName ="Stella/HealthDataEnemy")]
public class HealthDataEnemy : HealthData
{
	[Header("經驗值物件")]
	public GameObject prefabExp;
	[Header("掉落經驗值機率"), Range(0, 1)]
	public float dropprobability;
}
