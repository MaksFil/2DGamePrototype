using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	[SerializeField] private Slider _slider;
	[SerializeField] private Character _character;

	private static float health;
	void Start()
	{
		health = _slider.maxValue;
		_slider.maxValue = _character.maxHealth;
		_slider.value = _slider.maxValue;
	}
	void Update()
	{
		_slider.value = health;

		if (health > _character.maxHealth)
		{
			health = _character.maxHealth;
		}
	}
}
