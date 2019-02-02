using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadStructure : MonoBehaviour
{
    #region prefabs
    [Header("Prefabs")]
    [SerializeField]
    private GameObject Atom;

    [SerializeField]
    private GameObject Bond;
    #endregion

    #region private vars
    private string cif/* = "defaultlocation/default.cif"*/;
    #endregion

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetCif(string cif)
    {
        this.cif = cif;
    }
}
