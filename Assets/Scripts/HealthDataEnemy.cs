using UnityEngine;

//�ϥ��~�ӷ����Aclass�W�٭n�ϥΤ��{�����W��
[CreateAssetMenu(menuName ="Stella/HealthDataEnemy")]
public class HealthDataEnemy : HealthData
{
	[Header("�g��Ȫ���")]
	public GameObject prefabExp;
	[Header("�����g��Ⱦ��v"), Range(0, 1)]
	public float dropprobability;
	[Header("�����O"),Range(0,1000)]
	public float attack = 20;
	[Header("�������j"),Range(0,5)]
	public float attackInterval = 2.5f;
	[Header("�����Z��"),Range(0,10)]
	public float attackRange = 3;
}
