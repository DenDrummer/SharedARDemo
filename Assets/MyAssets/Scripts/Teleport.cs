using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/**
 * Give the location of the atom to the teleport player
 */
public class Teleport : MonoBehaviour {

	private TeleportPlayer teleportPlayer;
	private float heldTime = 0;

	void Start () {
		teleportPlayer = GameObject.Find("Player").GetComponent<TeleportPlayer>();
	}

	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			heldTime += Time.deltaTime;

			if(heldTime >= 3f)
			{
				teleportPlayer.Teleport(new Vector3(0, 1, -10));
				heldTime = 0;
			}
		}
		else
		{
			heldTime = 0;
		}
	}

    public void TeleportToAtom()
    {
        teleportPlayer.Teleport(transform.position);
    }
}
