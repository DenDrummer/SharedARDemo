using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * Places the correct information of the element into the interface of the atom
 */
public class AtomGuiDetails : MonoBehaviour {
    private Element element;
    [SerializeField]
    Text InfoContent;
    [SerializeField]
    Text Title;

    void Start()
    {
        element = AllElements.getElement(transform.name);
        //Debug.Log("transform.name" + transform.name);
        //Debug.Log("element  " + element.abbreviation);
        SetGuiText();
    }

    void SetGuiText()
    {
        Title.text = transform.name;
        InfoContent.text = 
            "Atomic number: "+element.atomicNumber+
            "\nName: "+element.name +
            "\nAbbreviation: " + element.abbreviation +
            "\nMass: " + element.mass +
            "\nAtomicRadius: " + element.atomicRadius;
}
}
