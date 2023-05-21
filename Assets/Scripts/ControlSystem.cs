using UnityEngine;

public class ControlSystem : MonoBehaviour
{
	//流程: 開一個新的程式，把程式丟到場景中的角色或空物件上
	//宣告一個函式變數，讓物件上的程式依照函式類型提供一個空格(欄位資料)，空格中要記得拉它需要讀取的物件過去
	//不同的欄位類型的變數有不同的函數(不確定是否可以如此稱呼例如 Rigidbody2D有velocity)
	//ctrl+K+D可以快速整理縮排

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
		MoveandAnimation();
	}

	private void MoveandAnimation()
	{
		float h = Input.GetAxis("Horizontal");
		//取得水平軸向的值，Unity預設水平軸向為A、D以及左右方向鍵。取得玩家案鍵請放Update事件中
		float v = Input.GetAxis("Vertical");
		rig.velocity = new Vector3(h, v, 0) * moveSpeed;

		//print(Input.GetKeyDown(KeyCode.A));

		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
		}
		if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			transform.eulerAngles = new Vector3(0, 180, 0);
		}
		//動畫參數ani控制主角，parRun則是控制走路動畫，h是水平移動，所以往右邊移動就會出現走路動畫
		ani.SetBool(parRun, h != 0 || v != 0);
	}
}
