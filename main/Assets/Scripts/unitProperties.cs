﻿using UnityEngine;
using System.Collections;

public class unitProperties : MonoBehaviour 
{
	public Vector3 currentVelocity;
	public bool isPlayer;
	public bool useNewVelocity = false;
	public bool hostile;
	public string oppositionTag;
	public string unitType;
	public float unitHealth;
	public float penaltyMulti;
	public int reward;
	
	void Update () 
	{
		rigidbody.velocity = currentVelocity;
		if (unitHealth <=0)
		{
			Destroy(this.gameObject);
			if (this.gameObject.tag == "Enemy")
			{
				GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>().gold += reward;
			}
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Boundary")
		{
			Destroy(this.gameObject);
		}
		if (other.gameObject.tag == "PlayerCharacter")
		{
			unitHealth--;
			other.gameObject.GetComponent<playerCharacter>().health --;
		}
		if (other.gameObject.tag == oppositionTag)
		{
			if(unitType == other.gameObject.GetComponent<unitProperties>().unitType)
			{
				unitHealth --;
				other.gameObject.GetComponent<unitProperties>().unitHealth--;
			}
			else
			{
				if(victoryCheck(unitType, other.gameObject.GetComponent<unitProperties>().unitType))
				{
					other.gameObject.GetComponent<unitProperties>().unitHealth--;
					other.gameObject.GetComponent<unitProperties>().currentVelocity = other.gameObject.GetComponent<unitProperties>().currentVelocity / penaltyMulti;
				}
				else
				{
					unitHealth --;
				}
			}
		}

	}


	bool victoryCheck(string type, string oppositionType)
	{
		if(type == "warrior")
		{
			if (oppositionType == "mage")
			{
				return true;
			}
			if (oppositionType == "defender")
			{
				return false;
			}
		}
		if(type == "mage")
		{
			if (oppositionType == "warrior")
			{
				return false;
			}
			if (oppositionType == "defender")
			{
				return true;
			}
		}
		if(type == "defender")
		{
			if (oppositionType == "mage")
			{
				return false;
			}
			if (oppositionType == "warrior")
			{
				return true;
			}
		}
		return false;
	}
}
