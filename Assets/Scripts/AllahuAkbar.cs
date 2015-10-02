using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AllahuAkbar : MonoBehaviour {

    public AudioClip explosion;
    List<GameObject> affectedObjects = new List<GameObject>();

    public void OnCollisionEnter()
    {
        AudioSource.PlayClipAtPoint(explosion, gameObject.transform.position);
        Collider[] affectedColliders = Physics.OverlapSphere(gameObject.transform.position, 50);
        foreach (Collider collider in affectedColliders)
        {
            if (collider.gameObject.GetComponent<Rigidbody>())
            {
                Rigidbody affectedRigidbody = collider.gameObject.GetComponent<Rigidbody>();
                affectedRigidbody.AddExplosionForce(69, gameObject.transform.position, 69);
            }
        }
        GameObject.Destroy(gameObject);
    }
}
