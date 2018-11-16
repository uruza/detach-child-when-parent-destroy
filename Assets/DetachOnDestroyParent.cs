
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[DisallowMultipleComponent]
public class DetachOnDestroyParent : MonoBehaviour
{
    public delegate void SignalDetachChild();
    public SignalDetachChild signalDetachChild;

    private void Awake()
    {
        Debug.LogFormat( "{0}.{1}.{2}", name, GetType().Name, MethodBase.GetCurrentMethod().Name );
    }

    private void OnDestroy()
    {
        Debug.LogFormat( "{0}.{1}.{2}", name, GetType().Name, MethodBase.GetCurrentMethod().Name );

        if ( null != signalDetachChild ) {
            signalDetachChild();
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
}
