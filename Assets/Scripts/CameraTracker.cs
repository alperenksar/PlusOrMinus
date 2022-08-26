using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField] private Transform _ballTransform;

    private Vector3 _offSet;

    [SerializeField] private float _lerpTime;

    // Start is called before the first frame update
    void Start()
    {
        _offSet = transform.position - _ballTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 _newPos = Vector3.Lerp(transform.position, _ballTransform.position + _offSet, _lerpTime * Time.deltaTime);
        transform.position = _newPos;
    }
}
