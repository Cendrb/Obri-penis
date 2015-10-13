using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterThrowScript : MonoBehaviour {

    public GameObject fire1Prefab;
    public GameObject fire2Prefab;

    private bool shots1Fired;
    private bool shots2Fired;
    private Camera camera;
    private Transform transform;

    void Start()
    {
        camera = gameObject.GetComponentInChildren<Camera>();
        transform = gameObject.GetComponent<Transform>();
    }

	void Update () 
    {
        if(!shots1Fired && CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            shots1Fired = true;
            GameObject allahuAkbar = Instantiate<GameObject>(fire1Prefab);
            Transform allahuTransform = allahuAkbar.GetComponent<Transform>();
            Rigidbody allahuRigidbody = allahuAkbar.GetComponent<Rigidbody>();
            
            allahuTransform.position = transform.position + new Vector3(0, 3, 0);

            allahuRigidbody.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }

        if (CrossPlatformInputManager.GetButtonUp("Fire1"))
            shots1Fired = false;

        if (!shots2Fired && CrossPlatformInputManager.GetButtonDown("Fire2"))
        {
            shots2Fired = true;
            GameObject allahuAkbar = Instantiate<GameObject>(fire2Prefab);
            Transform allahuTransform = allahuAkbar.GetComponent<Transform>();
            Rigidbody allahuRigidbody = allahuAkbar.GetComponent<Rigidbody>();

            allahuTransform.position = transform.position + new Vector3(0, 3, 0);

            allahuRigidbody.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }

        if (CrossPlatformInputManager.GetButtonUp("Fire2"))
            shots2Fired = false;
	}
}
