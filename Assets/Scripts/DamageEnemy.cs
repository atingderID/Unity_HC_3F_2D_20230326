using UnityEngine;

public class DamageEnemy : DamageSystem
{
	private HealthDataEnemy dataEnemy;
	private void Start()
	{
		dataEnemy = (HealthDataEnemy)data;
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		//print(collision.gameObject);
		if (collision.gameObject.name.Contains("武器"))
		{
			float attack = collision.gameObject.GetComponent<Weapon>().attack;
			//print("ㄚㄚㄚㄚ我被打到了");
			GetDamage(attack);
		}
	}

	public override void GetDamage(float damage)
	{
		base.GetDamage(damage);
		AudioClip sound = SoundManager.instance.enemyHit;
		SoundManager.instance.PlaySound(sound, 0.7f, 1.3f);
	}

	protected override void Dead()
	{
		Destroy(gameObject);
		DropExp();
		AudioClip sound = SoundManager.instance.enemyDead;
		SoundManager.instance.PlaySound(sound, 0.7f, 1.3f);
	}
	private void DropExp()
	{
		//print("這隻怪物的掉落經驗機率:" + dataEnemy.dropprobability);
		if (Random.value <= dataEnemy.dropprobability)
		{
			Instantiate(dataEnemy.prefabExp, transform.position, transform.rotation);
		}
	}
}
