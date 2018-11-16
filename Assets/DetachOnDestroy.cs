
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[DisallowMultipleComponent]
public class DetachOnDestroy : MonoBehaviour
{
    public delegate void DetachSignal();
    public DetachSignal detachSignal;

    private void Awake()
    {
        Debug.LogFormat( "{0}.{1}.{2}", name, GetType().Name, MethodBase.GetCurrentMethod().Name );

        LinkSignalUpward( transform );
        LinkSignalDownward( transform, detachSignal );
    }

    private void OnDestroy()
    {
        Debug.LogFormat( "{0}.{1}.{2}", name, GetType().Name, MethodBase.GetCurrentMethod().Name );

        if ( null != detachSignal ) {
            detachSignal();
        }
    }

    public void DetachSignalFromParent()
    {
        Debug.LogFormat( "{0}.{1}.{2}", name, GetType().Name, MethodBase.GetCurrentMethod().Name );

        transform.SetParent( null );
    }

    void LinkSignalUpward( Transform trans )
    {
        if ( null == trans.parent ) {
            return;
        }

        DetachOnDestroy detachOnDestroy = trans.parent.GetComponent<DetachOnDestroy>();

        if ( null != detachOnDestroy ) {
            detachOnDestroy.detachSignal += DetachSignalFromParent;
            return;
        }

        LinkSignalUpward( trans.parent );
    }

    void LinkSignalDownward( Transform trans, DetachSignal signal )
    {
        foreach( Transform child in trans ) {

            DetachOnDestroy detachOnDestroy = child.GetComponent<DetachOnDestroy>();

            if ( null != detachOnDestroy ) {
                signal += detachOnDestroy.DetachSignalFromParent;
                continue;
            }

            LinkSignalDownward( child, signal );
        }
    }
}
