using UnityEngine;

public class Weapon : MonoBehaviour
{
	[Header("剛體")]
	public Rigidbody2D rig;
	//Vector是儲存(x,y)的二元陣列欄位類型
	[Header("武器力道")]
	public Vector2 power;

	private void Awake()
	{
		rig.AddForce(power);
	}
}
