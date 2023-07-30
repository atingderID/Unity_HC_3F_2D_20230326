using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class LevelManager : MonoBehaviour
{
	#region 資料
	[Header("等級與經驗值介面")]
	//要用程式修改UI上的文字
	public TextMeshProUGUI textLv;
	public TextMeshProUGUI textExp;
	public Image imgExp;
	[Header("等級上限"),Range(0,500)]
	public int lvMax = 100;

	private int lv = 1;
	private float exp;
	

	public float[] expNeeds = { 100, 200, 300 };
	//使用陣列儲存每次升級需要的經驗值

	[Header("升級面板")]
	public GameObject goLevelUp;
	[Header("技能選取區塊1~3")]
	public GameObject[] goChooseSkills;
	[Header("全部技能")]
	public DataSkill[] dataskills;

	public List<DataSkill> randomSkill = new List<DataSkill>();
	#endregion

	#region 經驗值系統
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
		//時間暫停
		Time.timeScale = 0;

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
		AudioClip sound = SoundManager.instance.btnLevelUp;
		SoundManager.instance.PlaySound(sound, 0.7f, 1.3f);
	}

	public void ClickSkillButton(int number)
	{
		print("玩家按下的技能是:" + randomSkill[number].nameSkill);

		//該技能等級+1
		randomSkill[number].lv++;
		//按下技能升級
		if (randomSkill[number].nameSkill == "移動速度") UpdateMoveSpeed(number);
		if (randomSkill[number].nameSkill == "武器攻擊") UpdateWeaponAttack(number);
		if (randomSkill[number].nameSkill == "武器間隔") UpdateWeaponInterval(number);
		if (randomSkill[number].nameSkill == "玩家血量") UpdatePlayerHealth(number);
		if (randomSkill[number].nameSkill == "經驗值範圍") UpdateExpRange(number);

		Time.timeScale = 1;
		//選取技能後恢復時間並關閉頁面
		goLevelUp.SetActive(false);
		AudioClip sound = SoundManager.instance.btnUpdateSkill;
		SoundManager.instance.PlaySound(sound, 0.7f, 1.3f);
	}
	#endregion

	#region 升級系統
	[Header("控制系統:企鵝")]
	public ControlSystem controlSystem;
	[Header("武器系統:企鵝")]
	public WeaponSystem weaponSystem;
	[Header("玩家血量")]
	public HealthData dataHealth;
	[Header("經驗物件:櫻桃經驗值")]
	public CircleCollider2D expCherry;
	[Header("武器:刺球")]
	public Weapon weaponThorn;

	private void Awake()
	{
		controlSystem.moveSpeed = dataskills[3].skillValues[0];//dataskills[在dataskills的編號]
		weaponThorn.attack = dataskills[0].skillValues[0];
		weaponSystem.interval = dataskills[1].skillValues[0];
		dataHealth.hp = dataskills[2].skillValues[0];
		expCherry.radius = dataskills[4].skillValues[0];
	}

	public void UpdateMoveSpeed(int number)
	{
		//取得玩家選取技能的等級
		int lv = randomSkill[number].lv;
		//控制系統 的 移動速度=玩家選取技能的該等級數值
		controlSystem.moveSpeed = randomSkill[number].skillValues[lv - 1];
	}

	

	public void UpdateWeaponAttack(int number)
	{
		int lv = randomSkill[number].lv;
		weaponThorn.attack = randomSkill[number].skillValues[lv - 1];
	}
	public void UpdateWeaponInterval(int number)
	{
		int lv = randomSkill[number].lv;
		weaponSystem.interval = randomSkill[number].skillValues[lv - 1];
	}
	public void UpdatePlayerHealth(int number)
	{
		int lv = randomSkill[number].lv;
		dataHealth.hp = randomSkill[number].skillValues[lv - 1];
	}
	public void UpdateExpRange(int number)
	{
		int lv = randomSkill[number].lv;
		expCherry.radius = randomSkill[number].skillValues[lv - 1];
	}
	#endregion
}

