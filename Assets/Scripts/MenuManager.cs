using UnityEngine;//�ϥ�Unity �������禡�w
using UnityEngine.SceneManagement; //�Ω�Ҧp�C���}�l�H�����}�C�����C����������
//�`�N�n�P�ɦW�@�ˡA�]�t�j�p�g
public class MenuManager : MonoBehaviour
{
	//Method=Function(�]�t�\�઺�{���X�϶�)�AField(�x�s�ܼƸ�ƪ��ϰ�)�AProperty(���~��Ū���P�Ƽg���)
	//�o�O�@��Method�A�|�]�t�@�ӵ{���X�϶��A�Ҧp�i�H�b�o�Ӱ϶�����J�\��..�� �׹��� ������� ��k�W��()�զ�
	public void StartGame()
	{
		SceneManager.LoadScene("�C���e��");
	}
	public void QuitGame()
	{
		Application.Quit();
	}
	
}
