using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutting : MonoBehaviour
{
    Vector3 randomAngle;
    GameObject parent;
    public GameObject prefab;

    private void OnTriggerEnter(Collider other)
    {
        // If the knife collides with one of the slices
        if (other.gameObject.layer == 9)
        {
            //Let the pieces move, add a little force to them 
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            other.gameObject.GetComponent<Rigidbody>().AddTorque(-Vector3.up * 1f, ForceMode.Impulse);
            randomAngle = new Vector3(Random.Range(-.8f, -2f),
                                      Random.Range(.2f, .3f), 
                                      Random.Range(-2f, 2f));

            other.gameObject.GetComponent<Rigidbody>().AddForce(randomAngle * Random.Range(.3f, .6f), ForceMode.Impulse);
        }
    }
}
