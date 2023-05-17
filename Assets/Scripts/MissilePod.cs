using System.Collections;
using UnityEngine;

public class MissilePod : MonoBehaviour
{
    public GameObject[] missiles;
    public float launchingPower;
    public float launchDelay;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(LaunchMissiles());
        }
    }

    private IEnumerator LaunchMissiles()
    {
        for (int i = 0; i < missiles.Length; i++)
        {
            yield return new WaitForSeconds(launchDelay);
            Rigidbody missileRigidBody = missiles[i].GetComponent<Rigidbody>();
            missileRigidBody.useGravity = true;
            missileRigidBody.AddForce(transform.forward * launchingPower, ForceMode.Impulse);

            missiles[i].GetComponent<Missile>().isLaunched = true;
            StartCoroutine(missiles[i].GetComponent<Missile>().TrackTarget());
        }
    }

}

