using UnityEngine;

//�ϥ��~�ӷ����Aclass�W�٭n�ϥΤ��{�����W��
[CreateAssetMenu(menuName ="Stella/HealthDataEnemy")]
public class HealthDataEnemy : HealthData
{
	[Header("�g��Ȫ���")]
	public GameObject prefabExp;
	[Header("�����g��Ⱦ��v"), Range(0, 1)]
	public float dropprobability;
}
