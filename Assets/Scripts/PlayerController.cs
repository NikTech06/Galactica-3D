using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Transform  camera;

    
    [Header("REFERENCES")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Target _target;
    [SerializeField] private GameObject _explosionPrefab;

    [Header("MOVEMENT")]
    [Range(0, 30)]
    public float accelerateSpeed = 10f;
    [SerializeField] private float _rotateSpeed = 95;

    [Header("PREDICTION")]
    [SerializeField] private float _maxDistancePredict = 100;
    [SerializeField] private float _minDistancePredict = 5;
    [SerializeField] private float _maxTimePrediction = 5;
    private Vector3 _standardPrediction, _deviatedPrediction;

    [Header("DEVIATION")]
    [SerializeField] private float _deviationAmount = 50;
    [SerializeField] private float _deviationSpeed = 2;

    public float defaultAngularDrag = 0.05f;
    public float gravityZoneAngularDrag = 10f;

    

    void Update()
    {
        Accelerate();

    }

    private void OnTriggerEnter(Collider other)
    {
        rb.useGravity = true;
        rb.angularDrag = gravityZoneAngularDrag;
    }

    private void OnTriggerExit(Collider other)
    {
        rb.useGravity = false;
        rb.angularDrag = defaultAngularDrag;
    }

    void Accelerate()
    {
        if (Input.GetButton("Accelerate"))
        {
            rb.AddForce(Vector3.back * accelerateSpeed * Time.deltaTime * 100);
        }
    }

    private void FixedUpdate()
    {
        var leadTimePercentage = Mathf.InverseLerp(_minDistancePredict, _maxDistancePredict, Vector3.Distance(transform.position, _target.transform.position));

        PredictMovement(leadTimePercentage);

        RotateRocket();
    }

    private void PredictMovement(float leadTimePercentage)
    {
        var predictionTime = Mathf.Lerp(0, _maxTimePrediction, leadTimePercentage);

        _standardPrediction = _target.Rb.position + _target.Rb.velocity * predictionTime;
    }

    private void RotateRocket()
    {
        var heading = _deviatedPrediction - transform.position;


        var rotation = Quaternion.LookRotation(heading);
        _rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, _rotateSpeed * Time.deltaTime));
    }
}

