using UnityEngine;

[CreateAssetMenu(menuName ="Stella/Data Health")]
public class HealthData : ScriptableObject
{
	[Header("血量"), Range(1, 5000)]
	public float hp = 500;
}
