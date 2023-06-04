using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
	[Header("等級與經驗值介面")]
	//要用程式修改UI上的文字
	public TextMeshProUGUI textLv;
	public TextMeshProUGUI textExp;
	public Image imgExp;
	[Header("等級上限"),Range(0,500)]
	public int lvMax = 100;

	private int lv = 1;
	private float exp;
	private float expNeed = 100;
	//每次升級需要的經驗值

	public float[] expNeeds = { 100, 200, 300 };
	//使用陣列儲存每次升級需要的經驗值

	[ContextMenu("更新經驗值需求表")]
	//在Unity中LevelManager上按右鍵就會出現，程式有改就要按一次
	private void UpdateExpNeeds()
	{
		expNeeds = new float[lvMax];
		for(int i=0;i< lvMax; i++)
		{
			expNeeds[i] = (i+1) * 100;
		}
	}

	/// <summary>
	/// 獲得經驗值
	/// </summary>
	/// <param name="getExp">取得經驗值浮點數</param>
	public void GetExp(float getExp)
	{
		exp += getExp;
		//exp=getExp+exp
		print($"<color=yellow>當前經驗值:{exp}</color>");
		
		//如果經驗值>=當前等級需求並且等級<等級上限 就升級
		if (exp >= expNeeds[lv - 1] && lv<lvMax)
		{
			exp = expNeeds[lv - 1];
			//計算多出來的經驗
			lv++;
			//等級提升
			textLv.text = $"Lv{lv}";
			//更新等級介面
		}

		textExp.text = $"{exp}/{expNeeds[lv - 1]}";
		imgExp.fillAmount = exp / expNeeds[lv - 1];

		
	}
}

