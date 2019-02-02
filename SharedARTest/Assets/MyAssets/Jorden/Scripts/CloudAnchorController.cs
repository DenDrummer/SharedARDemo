using System;
using GoogleARCore;
using GoogleARCore.Examples.CloudAnchors;
using UnityEngine;

public class CloudAnchorController : MonoBehaviour
{
    #region ARCore
    [Header("ARCore")]

    /// <summary>
    /// The UI-controller
    /// </summary>
    [SerializeField]
    private NetworkUIController NetworkUIController;

    /// <summary>
    /// The root for ARCore-specific GameObjects in the Scene
    /// </summary>
    [SerializeField]
    private GameObject ARCoreRoot;

    /// <summary>
    /// The helper that will calculate the World Origin offset when performing a raycast or generating planes.
    /// </summary>
    [SerializeField]
    private ARCoreWorldOriginHelper ARCoreWorldOriginHelper;
    #endregion

    #region ARKit
    [Header("ARKit")]

    /// <summary>
    /// The root for ARKit-specific GameObjects in the scene.
    /// </summary>
    [SerializeField]
    private GameObject ARKitRoot;

    /// <summary>
    /// The first-person camera used to render the AR background texture for ARKit.
    /// </summary>
    [SerializeField]
    private Camera ARKitFirstPersonCamera;

    /// <summary>
    /// A helper object to ARKit functionality.
    /// </summary>
    private ARKitHelper ARKit = new ARKitHelper();
    #endregion

    #region public variables
    [Header("Other Settings")]
    [SerializeField]
    [Range(1,1000)]
    private int sleepTimeOut;

    [SerializeField]
    [Range(0.1f,5f)]
    private float quitDelay;

    [SerializeField]
    private string defaultCif;
    #endregion

    #region private variables
    /// <summary>
    /// Indicates whether the Origin of the new World Coordinate System, i.e. the Cloud Anchor, was placed.
    /// </summary>
    private bool originPlaced = false;

    /// <summary>
    /// Indicates whether the Anchor was already instantiated.
    /// </summary>
    private bool AnchorAlreadyInstantiated = false;

    /// <summary>
    /// Indicates whether the Cloud Anchor finished hosting.
    /// </summary>
    private bool AnchorFinishedHosting = false;

    /// <summary>
    /// True if the app is in the process of quitting due to an ARCore connection error, otherwise false.
    /// </summary>
    private bool IsQuitting = false;

    /// <summary>
    /// The last placed anchor.
    /// </summary>
    private Component LastPlacedAnchor = null;

    /// <summary>
    /// The current cloud anchor mode.
    /// </summary>
    private AnchorMode CurrentMode = AnchorMode.Scanning;
    #endregion

    /// <summary>
    /// The Unity Start() method.
    /// </summary>
    void Start()
    {
        //gameObject.name = "Cloud Anchor Controller";
        ResetStatus();
    }

    /// <summary>
    /// Resets internal status.
    /// </summary>
    private void ResetStatus()
    {
        CurrentMode = AnchorMode.Scanning;
        if (LastPlacedAnchor != null)
        {
            Destroy(LastPlacedAnchor.gameObject);
        }

        LastPlacedAnchor = null;
    }

    // Update is called once per frame
    void Update()
    {
        #region App Lifecycle
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        var newSleepTimeout = SleepTimeout.NeverSleep;
        if (Session.Status != SessionStatus.Tracking)
        {
            newSleepTimeout = sleepTimeOut;
        }
        Screen.sleepTimeout = newSleepTimeout;

        if (IsQuitting)
        {
            return;
        }

        //Quit if ARCore was unable to connect
        // and give Unity some time for the toast to appear.
        if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
        {
            ShowToast("Camera permission is needed to run this application.");
            IsQuitting = true;
            Invoke("Quit", 0.5f);
        }
        else if (Session.Status.IsError())
        {
            ShowToast("ARCore encountered a problem connecting. Please restart the app.");
            IsQuitting = true;
            Invoke("Quit", 0.5f);
        }
        #endregion

        if (CurrentMode.Equals(AnchorMode.Scanning))
        {
            return;
        }

        if (CurrentMode.Equals(AnchorMode.Resolving) && !originPlaced)
        {
            return;
        }

        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        if (Application.platform != RuntimePlatform.IPhonePlayer)
        {
            TrackableHit hit;
            if (ARCoreWorldOriginHelper.Raycast(
                touch.position.x,
                touch.position.y,
                TrackableHitFlags.PlaneWithinPolygon,
                out hit))
            {
                LastPlacedAnchor = hit.Trackable.CreateAnchor(hit.Pose);
            }
        }
        else
        {
            Pose hitPose;
            if (ARKit.RaycastPlane(
                ARKitFirstPersonCamera,
                touch.position.x,
                touch.position.y,
                out hitPose))
            {
                LastPlacedAnchor = ARKit.CreateAnchor(hitPose);
            }
        }

        if (LastPlacedAnchor!=null)
        {
            if (CanPlaceStructures())
            {
                //TODO: check if a cif file is given.
                string cif = "";
                if (!(cif == null || cif.Equals("")))
                {
                    InstantiateStructure(cif);
                }
                else
                {
                    InstantiateStructure(defaultCif);
                }
            }
            else if (!originPlaced && CurrentMode.Equals(AnchorMode.Hosting))
            {
                SetWorldOrigin(LastPlacedAnchor.transform);
                InstantiateAnchor();
                OnAnchorInstantiated(true);
            }
        }
    }

    private void OnAnchorInstantiated(bool isHost)
    {
        if (AnchorAlreadyInstantiated)
        {
            return;
        }

        AnchorAlreadyInstantiated = true;
        NetworkUIController.OnAnchorInstantiated(isHost);
    }

    private void InstantiateAnchor()
    {
        GameObject.Find("LocalPlayer")
            .GetComponent<LocalPlayerController>()
            .SpawnAnchor(
                Vector3.zero,
                Quaternion.identity,
                LastPlacedAnchor);
    }

    private void SetWorldOrigin(Transform anchorTransform)
    {
        if (originPlaced)
        {
            Debug.LogWarning("The World Origin can only be set once.");
            return;
        }
        originPlaced = true;
        if (!Application.platform.Equals(RuntimePlatform.IPhonePlayer))
        {
            ARCoreWorldOriginHelper.SetWorldOrigin(anchorTransform);
        }
        else
        {
            ARKit.SetWorldOrigin(anchorTransform);
        }
    }

    private void InstantiateStructure(string cif)
    {
        GameObject.Find("LocalPlayer")
            .GetComponent<LocalPlayerController>()
            .CmdSpawnStructure(
                LastPlacedAnchor.transform.position,
                LastPlacedAnchor.transform.rotation,
                cif);
    }

    private bool CanPlaceStructures()
    {
        switch (CurrentMode)
        {
            case AnchorMode.Hosting:
                return originPlaced && AnchorFinishedHosting;
            case AnchorMode.Resolving:
                return originPlaced;
            default:
                return false;
        }
    }

    private void Quit()
    {
        Application.Quit(); 
    }

    private void ShowToast(string msg)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>(
                    "makeText",
                    unityActivity,
                    msg,
                    0);
                toastObject.Call("show");
            }));
        }
    }
}
