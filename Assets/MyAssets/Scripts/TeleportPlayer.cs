using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Used to teleport the player to a specific atom.
 */
public class TeleportPlayer : MonoBehaviour {

    List<GameObject> gameObjects = new List<GameObject>();

    public void Teleport(Vector3 position)
    {
        gameObjects.ForEach(g => g.SetActive(true));
        gameObjects.Clear();

        transform.position = position;
        Debug.Log(position);

        Collider[] colliders = Physics.OverlapSphere(position,0.5f);
        new List<Collider>(colliders).ForEach(c => gameObjects.Add(c.gameObject));
        gameObjects.ForEach(g => g.SetActive(false));
    }
}
