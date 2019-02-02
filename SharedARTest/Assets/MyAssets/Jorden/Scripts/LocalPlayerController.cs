using GoogleARCore.Examples.CloudAnchors;
using System;
using UnityEngine;
using UnityEngine.Networking;

public class LocalPlayerController : NetworkBehaviour
{

    [Header("Prefabs")]
    [SerializeField]
    private GameObject StructurePrefab;

    [SerializeField]
    private GameObject AnchorPrefab;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        gameObject.name = "LocalPlayer";
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnAnchor(Vector3 position, Quaternion rotation, Component anchor)
    {
        GameObject anchorObject = Instantiate(AnchorPrefab, position, rotation);
        anchorObject.GetComponent<AnchorController>().HostLastPlacedAnchor(anchor);
        NetworkServer.Spawn(anchorObject);
    }

    [Command]
    public void CmdSpawnStructure(Vector3 position, Quaternion rotation, string cif)
    {
        GameObject structureObj = Instantiate(StructurePrefab, position, rotation);
        structureObj.GetComponent<LoadStructure>().SetCif(cif);
        NetworkServer.Spawn(structureObj);
        throw new NotImplementedException(); //TODO: Implement
    }
}
