using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	[SerializeField] private Slider slider;

	private static float health;
	public static void AdjustHealthValue(float adjust)
	{
		health += adjust;
	}
	void Start()
	{
		health = slider.maxValue;
	}
	void Update()
	{
		slider.value = health;
	}
}
