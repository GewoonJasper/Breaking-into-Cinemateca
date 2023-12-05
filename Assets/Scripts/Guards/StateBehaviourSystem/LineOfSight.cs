using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    [SerializeField] 
    private GameObject _objectToFind;

    private Transform _transformObject;
    private bool _seenObject = false;

    private const float _fieldOfView = 45f * Mathf.Deg2Rad;

    // Start is called before the first frame update
    void Start()
    {
        _transformObject = _objectToFind.transform; //GameObject.Find(_objectToFind).transform;
    }

    // Update is called once per frame
    void Update()
    {
        // check if the object is in the field of view
        Vector3 forward = transform.forward;
        Vector3 directionToObject = (_transformObject.position - transform.position).normalized;

        float dotProduct = Vector3.Dot(forward, directionToObject);

        // if the object is not in the field of view, then the guard cannot see it
        if (dotProduct < _fieldOfView)
        {
            _seenObject = false;
            return;
        }

        // check if there is a wall between the guard and the player
        RaycastHit hit;
        if (Physics.Raycast(transform.position, directionToObject, out hit))
        {
            if (hit.transform != _transformObject)
            {
                _seenObject = false;
                return;
            }
        }

        _seenObject = true;
    }

    public bool SeenObject()
    {
        return _seenObject;
    }
}
