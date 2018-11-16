
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneObj : MonoBehaviour
{
    public GameObject parentObj;

    void Start()
    {
    }

    void Update()
    {
    }

    public void DestroyParentObj () 
    {
        if ( null == parentObj ) {
            Debug.LogError( "out of case" );
        }

        Destroy( parentObj );
    }
}
