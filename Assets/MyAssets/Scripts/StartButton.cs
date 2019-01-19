using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Used to manage a click event in the start scene.
 */
public class StartButton : MonoBehaviour {
    [SerializeField]
    private GameObject startSceneManager;

    public void StartClick()
    {
        if (!UserStats.Cif.Equals(""))
        {
            startSceneManager.GetComponent<StartSceneManager>().enabled = true;
        }
    }
}
