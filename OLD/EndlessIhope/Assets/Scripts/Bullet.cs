using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private float speed = 11.0f;

	private Vector3 direction;
	//свойство для доступа к полю направления
	public Vector3 Direction {set { direction = value;}}

	private SpriteRenderer sprite;

	private void Awake()
	{
		sprite = GetComponentInChildren<SpriteRenderer> ();

	}

	private void Update()
	{
		transform.position = Vector3.MoveTowards (transform.position, transform.position + direction, speed * Time.deltaTime);	
	}
}
