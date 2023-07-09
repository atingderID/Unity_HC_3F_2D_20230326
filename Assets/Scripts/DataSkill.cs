using UnityEngine;

[CreateAssetMenu(menuName ="Stella/Data Skill")]
public class DataSkill : ScriptableObject
{
	[Header("�ޯ�W��")]
	public string nameSkill;
	[Header("�ޯ�C�ӵ��Ū��ƭ�")]
	public float[] skillValues;
	[Header("�ޯ�ϥ�")]
	public Sprite iconSkill;
	//Unity�x�s�Ϥ����������:sprite
	[Header("�ޯ�y�z"), TextArea(3, 10)]
	public string description;

	public int lv = 1;

	private void OnDisable()
	{
		lv = 1;
	}
}
