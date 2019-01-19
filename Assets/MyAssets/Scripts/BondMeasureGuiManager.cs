using UnityEngine;
using UnityEngine.UI;

/**
 * Places the right size into the bondGui
 */
public class BondMeasureGuiManager : MonoBehaviour
{
    [SerializeField] private Text distanceText;
    [SerializeField] private GameObject bond;
    [SerializeField] private GameObject bondGui;

	void Start () {
		SetBondGuiPlace();
        SetContentBondMeasure();
	}

    private void SetContentBondMeasure()
    {
        distanceText.text = (bond.transform.localScale.z * 2) + " A";
    }

    private void SetBondGuiPlace()
    {
        bondGui.transform.localPosition = new Vector3(0f,0f,bond.transform.localScale.z);
    }
}
