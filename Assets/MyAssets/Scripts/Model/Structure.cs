using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure{
    public Transform atom;
    public List<Atom> atoms = new List<Atom>();
    private const int maxRadius= 240;
    public float maxX;
    public float maxY;
    public float maxZ;
    

    public Structure(List<Atom> atoms,float maxKubus,Transform atom) {
        this.atom=atom;
        this.atoms = atoms;
        maxX = maxKubus;
        maxY = maxKubus;
        maxZ = maxKubus;
    }
}
