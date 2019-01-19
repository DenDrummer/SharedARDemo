using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class will instantiate the Atoms in the QuantumScene
 */
public class QuantumInstancer {

    public int SIZE;
    private Structure structure;

    public QuantumInstancer(Structure structure,int size) {
        this.structure = structure;
        this.SIZE = size;
    }

    public void drawAlongXAxis(float zOffset, float yOffset)
    {
        int count = 0;
        while (count < SIZE)
        {
            foreach (Atom a in structure.atoms)
            {
                Vector3 positie = new Vector3((float)a.x + (structure.maxX * count), (float)a.y + yOffset, (float)a.z + zOffset);
                if (!Physics.CheckSphere(positie, (float)0.001))
                {
                    GameObject gameObject = GameObject.Instantiate(structure.atom.gameObject, positie, Quaternion.identity);
                    gameObject.name = a.element.abbreviation;
                    gameObject.transform.localScale = (gameObject.transform.localScale * a.element.atomicRadius) / 100;
                    Renderer renderer = gameObject.GetComponent<Renderer>();
                    renderer.material.color = new Color(a.element.color.r / 255, a.element.color.g / 255, a.element.color.b / 255);
                }
            }
            count++;
        }
    }

    public void drawHorizontalLayer(float yOffset)
    {
        int zCount = 0;
        while (zCount < SIZE)
        {
            drawAlongXAxis(zCount * structure.maxZ, yOffset);
            zCount++;
        }

    }

    public void drawEveryLayer()
    {
        int yCount = 0;
        while (yCount < SIZE)
        {
            drawHorizontalLayer(yCount * structure.maxY);
            yCount++;
        }
    }
}
