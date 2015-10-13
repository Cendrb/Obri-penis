using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AllahuAkbar : MonoBehaviour {

    public AudioClip explosion;
    List<GameObject> affectedObjects = new List<GameObject>();

    public void OnCollisionEnter()
    {
        AudioSource.PlayClipAtPoint(explosion, gameObject.transform.position);
        Collider[] affectedColliders = Physics.OverlapSphere(gameObject.transform.position, 10);
        foreach (Collider collider in affectedColliders)
        {
            if (collider.gameObject.GetComponent<Rigidbody>())
            {
                Rigidbody affectedRigidbody = collider.gameObject.GetComponent<Rigidbody>();
                affectedRigidbody.useGravity = true;
                affectedRigidbody.AddExplosionForce(500, gameObject.transform.position, 10);
                affectedRigidbody.constraints = RigidbodyConstraints.None;
            }
        }
        GameObject.Destroy(gameObject);
    }
}
