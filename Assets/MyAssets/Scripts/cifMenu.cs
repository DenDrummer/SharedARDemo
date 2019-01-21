using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

/**
 * To select cif file
 */
public class cifMenu : MonoBehaviour {
    private string path;
    private ArrayList files = new ArrayList();
    private int page = 0;
    private GameObject next;
    private GameObject previous;
    private GameObject list;
    private GameObject noCifText;

	void Start () {
        next = this.transform.Find("Next").gameObject;
        previous = this.transform.Find("Previous").gameObject;
        list = this.transform.Find("List").gameObject;
        noCifText = this.transform.Find("NoCifText").gameObject;
        path = Application.persistentDataPath;
        foreach (string file in Directory.GetFiles(path))
        {
            if (file.EndsWith(".cif"))
            {
                files.Add(file);
            }
        }
        if (files.Count == 0)
        {
            list.SetActive(false);
            next.SetActive(false);
            noCifText.SetActive(true);
            noCifText.GetComponent<Text>().text = "No cif files were found. Add them in " + path;
        }
        else
        {
            SetCifButtons();
            if (files.Count <= 5)
            {
                next.SetActive(false);
            }
        }
	}
	
    public void NextPage() {
        ++page;
        if (files.Count <= ((page+1)*5))
        {
            next.SetActive(false);
        }
        previous.SetActive(true);
        SetCifButtons();
    }

    public void PreviousPage() {
        --page;
        if (page == 0)
        {
            previous.SetActive(false);
        }
        next.SetActive(true);
        SetCifButtons();
    }

    private void SetCifButtons()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject button = list.transform.Find("Button" + i).gameObject;
            if (files.Count > page*5 + i)
            {
                string file = files[page * 5 + i].ToString().Remove(0, path.Length + 1);
                button.GetComponentInChildren<Text>().text = file.Substring(0,file.LastIndexOf('.'));
                button.SetActive(true);
            }
            else
            {
                button.SetActive(false);
            }
        }
    }

    public void SetCif(int button)
    {
        UserStats.Cif = (string)files[page*5+button];
    }
}
