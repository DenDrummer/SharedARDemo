using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropboxLink : MonoBehaviour {

    [SerializeField]
    private Text KristalNaamText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadStructure()
    {
        string content = DropBoxFileHandler.GetFileContent(KristalNaamText.text);
        //TODO: send content to where it needs to be
        Debug.Log(content);
    }
}
