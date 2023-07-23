using UnityEngine;

public class tptp : MonoBehaviour
{
	public GameObject tp;
	public Transform ship;

	private void OnTriggerEnter2D(Collider2D other)
	{
		tp.SetActive(true);
		ship.position = new Vector3(-3.03999996f, 2f, 0f);
		ship.rotation = new Quaternion(0, 0, 0.0f, -0.319455832f);
	}
}
