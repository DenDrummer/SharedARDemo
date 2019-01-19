using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * To change between the size, the bonds and to select a cif
 */
public class MenuControle : MonoBehaviour {
    [SerializeField]
    private GameObject bondsMenu;
    [SerializeField]
    private GameObject sizeMenu;
    [SerializeField]
    private GameObject cifList;
    [SerializeField]
    private GameObject bondsButton;
    [SerializeField]
    private GameObject sizeButton;

    public void SizeClick()
    {
        if (sizeMenu.activeSelf)
        {
            sizeMenu.SetActive(false);
            cifList.SetActive(true);
            sizeButton.GetComponentInChildren<Text>().text = "Size";
        }
        else
        {
            sizeMenu.SetActive(true);
            cifList.SetActive(false);
            bondsMenu.SetActive(false);
            sizeButton.GetComponentInChildren<Text>().text = "Close";
            bondsButton.GetComponentInChildren<Text>().text = "Bonds";
        }
    }

    public void BondsClick()
    {
        if (bondsMenu.activeSelf)
        {
            bondsMenu.SetActive(false);
            cifList.SetActive(true);
            bondsButton.GetComponentInChildren<Text>().text = "Bonds";
        }
        else
        {
            bondsMenu.SetActive(true);
            cifList.SetActive(false);
            sizeMenu.SetActive(false);
            bondsButton.GetComponentInChildren<Text>().text = "Close";
            sizeButton.GetComponentInChildren<Text>().text = "Size";
        }
    }
}
