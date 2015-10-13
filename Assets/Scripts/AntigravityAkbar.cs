using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AntigravityAkbar : MonoBehaviour {

    public AudioClip explosion;
    List<GameObject> affectedObjects = new List<GameObject>();

	public void OnCollisionEnter()
    {
        AudioSource.PlayClipAtPoint(explosion, gameObject.transform.position);
        Collider[] affectedColliders = Physics.OverlapSphere(gameObject.transform.position, 50);
        foreach(Collider collider in affectedColliders)
        {
            if(collider.gameObject.GetComponent<Rigidbody>())
            {
                Rigidbody affectedRigidbody = collider.gameObject.GetComponent<Rigidbody>();
                if(affectedRigidbody.useGravity)
                {
                    affectedRigidbody.useGravity = false;
                    affectedRigidbody.AddForce(new Vector3(0, 5, 0), ForceMode.VelocityChange);
                    affectedObjects.Add(collider.gameObject);
                    collider.gameObject.AddComponent<InvokeAfter>().Initialize((GO) => GO.GetComponent<Rigidbody>().useGravity = true, 5);
                }
            }
        }
        GameObject.Destroy(gameObject);
    }
}
