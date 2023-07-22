using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.space
{
	public class asteroid_spawner: MonoBehaviour
	{
		public asteroid prefab;
		public GameObject planete_asteroid;
		public Transform parent;

		private float cooldown = -1;
		
		private void Update()
		{
			cooldown -= Time.deltaTime;
			if (cooldown < 0)
			{
				cooldown = Random.Range(0.5f, 5.0f);
				bool comeFromAsteroidPlanete = Random.Range(0, 2) == 0;
				asteroid asteroid;
				if (!comeFromAsteroidPlanete)
					asteroid = Instantiate(prefab, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized * 15, Quaternion.identity, parent);
				else
				{
					asteroid = Instantiate(prefab,
						transform.position + (planete_asteroid.transform.position - transform.position).normalized * 15,
						Quaternion.identity, parent);
					asteroid.is_special = true;
				}
				asteroid.launch(transform.position);
			}
		}
	}
}