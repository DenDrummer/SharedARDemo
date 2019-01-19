using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * Updates the distance inside the MeasureGUI of a atom
 */
public class DistanceUpdater : MonoBehaviour
{
    [SerializeField]
    private Text text;

    void Update()
    {
        text.text = Mathf.Round((UserStats.FirstLocation.position - UserStats.SecondLocation.position).magnitude * 1000f) / 1000f + "  Ångström";
    }
}
