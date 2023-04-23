using UnityEngine;

public class ControlSystem : MonoBehaviour
{
	//流程: 開一個新的程式，把程式丟到場景中的角色或空物件上
	//宣告一個函式變數，讓物件上的程式依照函式類型提供一個空格，空格中要記得拉它需要讀取的物件過去
	//函數會給變數一些功能(不確定是否可以如此稱呼例如 Rigidbody2D有velocity)

	[Header("移動速度")]
	[Range(0.5f,99.9f)]
	public float moveSpeed = 3.5f;

	[Header("2D剛體")]
	public Rigidbody2D rig;

	[Header("動畫控制器")]
	public Animator ani;

	public string parRun = "開關跑步";

	private void Awake()
	{
		//print("試試看");
		//print($"{1 + 2 + 3}");
	}

	private void Start()
	{
		//print("<color=red>這是開始事件</color>");
	}

	private void Update()
	{
		float h = Input.GetAxis("Horizontal");
		//取得水平軸向的值，Unity預設水平軸向為A、D以及左右方向鍵。取得玩家案鍵請放Update事件中
		float v = Input.GetAxis("Vertical");
		rig.velocity = new Vector3(h, v, 0)*moveSpeed;
	}
}
