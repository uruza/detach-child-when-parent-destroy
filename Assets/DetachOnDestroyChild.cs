
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[DisallowMultipleComponent]
public class DetachOnDestroyChild : MonoBehaviour
{
    private void Awake()
    {
        Debug.LogFormat( "{0}.{1}.{2}", name, GetType().Name, MethodBase.GetCurrentMethod().Name );

        if ( null != transform.parent ) {
            transform.parent.GetComponent<DetachOnDestroyParent>().signalDetachChild += DetachFromParent;
        }
    }

    private void OnDestroy()
    {
        Debug.LogFormat( "{0}.{1}.{2}", name, GetType().Name, MethodBase.GetCurrentMethod().Name );
    }

    void Start()
    {

    }

    void Update()
    {
    }

    public void DetachFromParent()
    {
        Debug.LogFormat( "{0}.{1}.{2}", name, GetType().Name, MethodBase.GetCurrentMethod().Name );

        transform.SetParent( null );
    }
}
