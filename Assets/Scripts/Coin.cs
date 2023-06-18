using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] public float RotationSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(gameObject.transform.position, Vector3.up, 20 * Time.deltaTime * RotationSpeed);
    }
}
