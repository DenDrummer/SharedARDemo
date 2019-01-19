using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/**
 * Used to calculate the bonds of all elements and than display the closest one
 */
public class BondManager : MonoBehaviour
{
    private GameObject[] atoms;
    [SerializeField] private Transform BondRef;
    private GameObject[] atomsParent;
    private Color[] colors;
    private int AmountOfClosestBonds;

    void Start ()
    {
        AmountOfClosestBonds = UserStats.Bonds;
        atoms = GameObject.FindGameObjectsWithTag("atom");
        colors = new Color[5];
        colors[0] = Color.blue;
        colors[1] = Color.yellow;
        colors[2] = Color.black;
        colors[3] = Color.red;
        colors[4] = Color.green;
	    MakeBonds();
	}

    void MakeBonds()
	{
	    float distance = 100f;
	    HashSet<float> distances = new HashSet<float>();
	    float[] distancesArray;
	    List<BondDistances> bonds = new List<BondDistances>();        
        foreach (var atom in atoms)
	    {
	        foreach (var atom2 in atoms)
	        {
	            float dis = Vector3.Distance(atom.transform.position, atom2.transform.position);
                bonds.Add(new BondDistances(dis,atom.GetComponent<Transform>(),atom2.GetComponent<Transform>()));
	            distances.Add((float)Math.Round(dis * 10f)/10f);
	        }
	    }
	    distancesArray = distances.ToArray();
        Array.Sort(distancesArray);
        for (int i = 0; i < AmountOfClosestBonds; i++)
	    {
            foreach (var bondDistanceBond in bonds.FindAll(b => Math.Abs(b.distance - distancesArray[i+1]) < 0.1))
	        {
                GameObject gameObject = GameObject.Instantiate(BondRef.gameObject, transform.position, Quaternion.identity);
                Transform bondTransform = gameObject.GetComponentInChildren<Transform>();
                gameObject.transform.GetChild(0).localScale = new Vector3(1f, 1f, bondDistanceBond.distance /2);
                gameObject.transform.position = bondDistanceBond.atomFirst.transform.position;
                gameObject.transform.LookAt(bondDistanceBond.atomSecond.transform);
                gameObject.transform.SetParent(bondDistanceBond.atomFirst);
	            gameObject.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color = colors[i];

	        }
	    }
    }
}
