using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/**
 * Overseeing class that instantiates structures and other controllers
 */
public class GameController : MonoBehaviour {
    [SerializeField]
    private Transform atom;
    List<Atom> atoms=new List<Atom>();
    Structure structure;
    [SerializeField]
    private GameObject bondController;
    [SerializeField]
    private QuantumInstancer quantumInstancer;
    private CifConverter cifConverter;
    [SerializeField]
    private GameObject InformationController;

    [SerializeField] private Text debugGui;

    [SerializeField] private GameObject exitButtons;
    [SerializeField] private GameObject enterButtons;

    void Start() {
        cifConverter = new CifConverter(atom);
        DrawFromCifConverter();
        //DrawFromHardCoded();
        bondController.GetComponent<BondManager>().enabled = true;
        InformationController.GetComponent<InformationGuiManager>().enabled = true;
    }

    //Draws hardcoded austenite frame
    void DrawFromHardCoded()
    {
        atoms.Add(new Atom(0, 0, 0, "Ni"));
        atoms.Add(new Atom(3.0149999, 0, 0, "Ni"));
        atoms.Add(new Atom(0, 3.0149999, 0, "Ni"));
        atoms.Add(new Atom(0, 0, 3.0149999, "Ni"));
        atoms.Add(new Atom(3.0149999, 3.0149999, 0, "Ni"));
        atoms.Add(new Atom(3.0149999, 0, 3.0149999, "Ni"));
        atoms.Add(new Atom(0, 3.0149999, 3.0149999, "Ni"));
        atoms.Add(new Atom(3.0149999 / 2, 3.0149999 / 2, 3.0149999 / 2, "Ti"));
        atoms.Add(new Atom(3.0149999, 3.0149999, 3.0149999, "Ni"));
        structure = new Structure(atoms, (float)3.0149999, atom);
        quantumInstancer = new QuantumInstancer(structure, 5);
        quantumInstancer.drawEveryLayer();
    }

    //Draws from .cif file
    void DrawFromCifConverter()
    {
        structure = cifConverter.getStructure(UserStats.Cif);
        quantumInstancer = new QuantumInstancer(structure, UserStats.Size);
        quantumInstancer.drawEveryLayer();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void SetDebugText(String debug)
    {
        debugGui.text = debug;
    }

    public List<GameObject> GetExitButtons()
    {
        List<GameObject> buttons = new List<GameObject>();
        foreach (Transform Button in exitButtons.transform)
        {
            buttons.Add(Button.gameObject);
        }
        return buttons;
    }

    public List<GameObject> GetEnterButtons()
    {
        List<GameObject> buttons = new List<GameObject>();
        foreach (Transform enterButton in enterButtons.transform)
        {
            buttons.Add(enterButton.gameObject);
        }
        return buttons;
    }
}

