using UnityEngine;//使用Unity 引擎的函式庫
using UnityEngine.SceneManagement; //用於例如遊戲開始以及離開遊戲等遊戲場景切換
//注意要與檔名一樣，包含大小寫
public class MenuManager : MonoBehaviour
{
	//Method=Function(包含功能的程式碼區塊)，Field(儲存變數資料的區域)，Property(讓外界讀取與複寫資料)
	//這是一個Method，會包含一個程式碼區塊，例如可以在這個區塊中放入功能..由 修飾詞 資料類型 方法名稱()組成
	//void=不會回傳任何資料類型
	public void StartGame()
	{
		SceneManager.LoadScene("遊戲畫面");
	}
	public void QuitGame()
	{
		Application.Quit();
	}
	
}
