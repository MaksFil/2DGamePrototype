using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	[SerializeField] private Slider _slider;
	[SerializeField] private Character _character;
	void Start()
	{
		_character._health = _slider.maxValue;
		_slider.maxValue = _character.maxHealth;
		_slider.value = _slider.maxValue;
	}
	void Update()
	{
		_slider.value = _character._health;

		if (_character._health > _character.maxHealth) _character._health = _character.maxHealth;
		if (_character._health <= 0) _character.Death();
	}
}
