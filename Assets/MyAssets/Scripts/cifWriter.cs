using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
/**
 * Used to write cif file of coresponding structure and starts the QuantumWorld.Scene
 */
public class cifWriter : MonoBehaviour {
    [SerializeField]
    private TextAsset cifFile;
    [SerializeField]
    private GameObject startSceneManager;

    public void ClickElement()
    {
        string path = Application.persistentDataPath + "/" + cifFile.name + ".txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, cifFile.text);
        }
        UserStats.Cif = path;
        startSceneManager.GetComponent<StartSceneManager>().enabled = true;
    }
}
