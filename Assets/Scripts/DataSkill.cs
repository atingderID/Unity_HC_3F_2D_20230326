using UnityEngine;

[CreateAssetMenu(menuName ="Stella/Data Skill")]
public class DataSkill : ScriptableObject
{
	[Header("技能名稱")]
	public string nameSkill;
	[Header("技能每個等級的數值")]
	public float[] skillValues;
	[Header("技能圖示")]
	public Sprite iconSkill;
	//Unity儲存圖片的資料類型:sprite
	[Header("技能描述"), TextArea(3, 10)]
	public string description;

	public int lv = 1;

	private void OnDisable()
	{
		lv = 1;
	}
}
