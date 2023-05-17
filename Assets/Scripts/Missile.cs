using System.Collections;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public ParticleSystem missileTrail;

    public bool isLaunched = false;
    public float trackingDelay;
    public float maxMissileSpeed;


    private bool isTracking = false;
    private GameObject movingTarget;

    private void Start()
    {
        movingTarget = GameObject.FindWithTag("Target");
        //StartCoroutine(TrackTarget());
    }

    public IEnumerator TrackTarget()
    {
            yield return new WaitForSeconds(trackingDelay);
            isTracking = true;
            
    }

    private void Update()
    {
        if (isTracking)
        {
            transform.LookAt(movingTarget.transform);
            Rigidbody rb = GetComponent<Rigidbody>();
            float speed = Mathf.Lerp(rb.velocity.magnitude, maxMissileSpeed, Time.deltaTime);
            rb.velocity = transform.forward * speed;

            missileTrail.Play();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Target" || other.gameObject.tag == "Ground")
        {
            gameObject.SetActive(false);
        }
    }


    public void Launch(float launchingPower)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * launchingPower, ForceMode.Impulse);
        isLaunched = true;
    }
}
