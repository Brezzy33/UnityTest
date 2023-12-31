using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody bulletRigidBody;

    private void Awake()
    {
        bulletRigidBody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        float speed = 40f;
        bulletRigidBody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
