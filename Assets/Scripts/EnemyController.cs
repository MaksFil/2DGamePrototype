using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	void FixedUpdate () {
		transform.Translate(0.1f, 0, 0);
	}
}
