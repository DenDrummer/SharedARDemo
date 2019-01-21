using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Allows the player to move freely
 */
public class MoveController : MonoBehaviour {

    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject Camera;
    [SerializeField]
    private float MoveSpeed;

    private bool moving;

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (UserStats.State.Equals(State.FreeMove) || moving)
            {
                moving = !moving;
            }
        }
        if (moving)
        {
            Player.transform.position += Camera.transform.forward.normalized * Time.deltaTime * MoveSpeed;
        }
	}
}
