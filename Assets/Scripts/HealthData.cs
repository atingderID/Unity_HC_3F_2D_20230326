using UnityEngine;
//血量如果儲存在各個場景中的物件很難管理，需要調整就要一個一個進入物件調整，因此我們利用ScriptableObject(腳本化物件)，將所有資料儲存在專案中(類似prefab)，就可以更好的管理
//在清單中新增一個資料夾(選項名稱/子選項)
[CreateAssetMenu(menuName ="Stella/Data Health")]
public class HealthData : ScriptableObject
{
	[Header("血量"), Range(1, 5000)]
	public float hp = 500;
}
