using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom{

    public Element element { get; set; }
    public double x { get; set; }
    public double y { get; set; }
    public double z { get; set; }
    

    public Atom(double x,double y,double z) {
        this.x = x;
        this.y = y;
        this.z = z;       
    }

    public Atom(double x, double y, double z,string elementAbb)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        
        element = AllElements.getElement(elementAbb);
    }
}
