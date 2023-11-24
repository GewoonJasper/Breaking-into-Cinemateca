using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    public List<GameObject> PointOfInterests = new List<GameObject>();
    public bool RunInOrder = true;

    public NavMeshAgent Agent;

    private bool _enabled = true;
    private int _target;

    // Start is called before the first frame update
    void Start()
    {
        if (PointOfInterests.Count == 0 || Agent == null) _enabled = false;
        else _target = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_enabled) return;

        SetTarget();
        MoveToTarget();
    }

    private void SetTarget()
    {
        if (!IsAtLocation()) return;

        if (!RunInOrder) _target = Random.Range(0, PointOfInterests.Count);
        else _target++;

        if (_target >= PointOfInterests.Count) _target = 0;
    }

    private bool IsAtLocation()
    {
        var targetLocation = PointOfInterests[_target].transform.position;
        var currentLocation = transform.position;

        return Vector3.Distance(targetLocation, currentLocation) < 0.1f;
    }

    private void MoveToTarget()
    {
        var targetLocation = PointOfInterests[_target].transform.position;

        Agent.SetDestination(targetLocation);
    }
}
