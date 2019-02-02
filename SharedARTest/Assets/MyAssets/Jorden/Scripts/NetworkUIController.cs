using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

[RequireComponent(typeof(CustomNetworkManager))]
public class NetworkUIController : MonoBehaviour
{
    private CustomNetworkManager NetworkMgr;

    [Header("UI elements")]
    [SerializeField]
    private GameObject CurrentRoomLabel;

    [Header("Settings")]
    [SerializeField]
    [Range(1,10)]
    private int MatchAmmount;

    void Awake()
    {
        // for first x existing rooms
        for (int i = 0; i < MatchAmmount; i++)
        {
            //TODO: instantiate room row UI
            //TODO: add room row to roomButton
        }

        // get the network manager
        NetworkMgr = GetComponent<CustomNetworkManager>();
        NetworkMgr.StartMatchMaker();
        NetworkMgr.matchMaker.ListMatches(
            0,
            MatchAmmount,
            string.Empty,
            false,
            0,
            0,
            OnMatchList);
    }

    private void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> responseData)
    {
        NetworkMgr.OnMatchList(success, extendedInfo, responseData);
        if (!success)
        {
            //TODO: show error indicating that it could not list matches
            string errorText = $"Could not list matches: {extendedInfo}";
            return;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void OnAnchorInstantiated(bool isHost)
    {
        throw new NotImplementedException(); //TODO: Implement
    }
}
