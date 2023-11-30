using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetPokeToFingerAttachPoint : MonoBehaviour
{
    public Transform PokeAttachPoint;

    private XRPokeInteractor _xrPokeInteractor;

    // Start is called before the first frame update
    void Start()
    {
        _xrPokeInteractor = transform.parent.parent.GetComponentInChildren<XRPokeInteractor>();

        SetPokeAttachPoint();
    }

    void SetPokeAttachPoint()
    {
        if (PokeAttachPoint == null || _xrPokeInteractor == null) return;
        
        _xrPokeInteractor.attachTransform = PokeAttachPoint;
    }
}
