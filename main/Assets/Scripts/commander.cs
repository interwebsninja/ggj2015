﻿using UnityEngine;
using System.Collections;

public class commander : MonoBehaviour 
{
	public int health;
	public string oppositionTag;
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == oppositionTag)
		{
			health --;
		}
	}

	void Update()
	{
		if (health <= 0)
		{
			Destroy(this.gameObject);
		}
	}
}
