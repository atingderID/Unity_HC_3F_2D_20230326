using UnityEngine;

public class PlayerUI : MonoBehaviour
{
	private Transform player;

	private void Awake()
	{
		player = GameObject.Find("���Z�D��").transform;
	}
	private void Update()
	{
		transform.position = player.position;
	}
}
