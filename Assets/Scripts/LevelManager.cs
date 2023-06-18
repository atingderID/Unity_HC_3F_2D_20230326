﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

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

	[Header("升級面板")]
	public GameObject goLevelUp;
	[Header("技能選取區塊1~3")]
	public GameObject[] goChooseSkills;
	[Header("全部技能")]
	public DataSkill[] dataskills;

	public List<DataSkill> randomSkill = new List<DataSkill>();

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
		//print($"<color=yellow>當前經驗值:{exp}</color>");
		
		//如果經驗值>=當前等級需求並且等級<等級上限 就升級
		if (exp >= expNeeds[lv - 1] && lv<lvMax)
		{
			exp -= expNeeds[lv - 1];
			//計算多出來的經驗
			lv++;
			//等級提升
			textLv.text = $"Lv{lv}";
			//更新等級介面
			LevelUp();
		}

		textExp.text = $"{exp}/{expNeeds[lv - 1]}";
		imgExp.fillAmount = exp / expNeeds[lv - 1];

		
	}

	private void LevelUp()
	{
		goLevelUp.SetActive(true);
		//遊戲物件標題的勾勾勾起
		randomSkill = dataskills.Where(x => x.lv < 5).ToList();
		//x.lv<5為條件:挑出所有等級小於5的技能
		randomSkill = randomSkill.OrderBy(x => Random.Range(0, 999)).ToList();
		//洗牌，Random.Range(0,999)為重新排序,數字夠大即可達到隨機效果

		for (int i = 0; i < 3; i++)
		{
			goChooseSkills[i].transform.Find("技能名稱").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = randomSkill[i].nameSkill;
			goChooseSkills[i].transform.Find("技能描述").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = randomSkill[i].description;
			goChooseSkills[i].transform.Find("技能等級").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "等級Lv"+randomSkill[i].lv;

			goChooseSkills[i].transform.Find("技能圖片").GetComponent<Image>().sprite = randomSkill[i].iconSkill;
		}
	}

	public void ClickSkillButton(int number)
	{
		print("玩家按下的技能是:" + randomSkill[number].nameSkill);

		//該技能等級+1
		randomSkill[number].lv++;
		//按下技能升級
		if (randomSkill[number].nameSkill == "移動速度") UpdateMoveSpeed(number);
		if (randomSkill[number].nameSkill == "武器攻擊") UpdateWeaponAttack();
		if (randomSkill[number].nameSkill == "武器間隔") UpdateWeaponInterval();
		if (randomSkill[number].nameSkill == "玩家血量") UpdatePlayerHealth();
		if (randomSkill[number].nameSkill == "經驗值範圍") UpdateExpRange();

	}
	[Header("控制系統:企鵝")]
	public ControlSystem controlSystem;

	public void UpdateMoveSpeed(int number)
	{
		//取得玩家選取技能的等級
		int lv = randomSkill[number].lv;
		//控制系統 的 移動速度=玩家選取技能的該等級數值
		controlSystem.moveSpeed = randomSkill[number].skillValues[lv - 1];
	}
	public void UpdateWeaponAttack()
	{

	}
	public void UpdateWeaponInterval()
	{

	}
	public void UpdatePlayerHealth()
	{

	}
	public void UpdateExpRange()
	{

	}
}

