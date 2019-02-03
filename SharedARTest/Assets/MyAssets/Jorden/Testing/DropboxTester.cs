using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropboxTester : MonoBehaviour {

    [SerializeField]
    RectTransform Content;

    [SerializeField]
    GameObject ButtonPrefab;

	// Use this for initialization
	void Start () {
        DropBoxFileHandler.login();

        List<KeyValuePair<string, string>> structures = DropBoxFileHandler.GetFiles();
        //Debug.Log($"rectangle height: {Content.rect.height}");

        Vector3 rowLocation = new Vector3(0, -50, 0);
        int i = 0;
        foreach (KeyValuePair<string, string> structure in structures)
        {
            GameObject button = Instantiate(ButtonPrefab, rowLocation, Quaternion.identity, Content);
            if (i==0)
            {
                Content.sizeDelta += new Vector2(0, 50);
            }
            else
            {
                Content.sizeDelta += new Vector2(0, 40);
            }
            rowLocation += new Vector3(0, -40, 0);
            Content.sizeDelta += new Vector2(0, 50);
            rowLocation += new Vector3(0, -40, 0);
            button.GetComponentInChildren<Text>().text = structure.Key;
        }
        //Debug.Log($"rectangle height: {Content.rect.height}");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
