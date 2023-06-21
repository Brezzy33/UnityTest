using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 2f;
            Collider[] colliders = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider1 in colliders)
            {
                if (collider1.TryGetComponent(out CoinInteract coinInteract))
                {
                    coinInteract.Interact();
                }
            }
        }
    }

    public CoinInteract GetInteractableCoin()
    {
        float interactRange = 2f;
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider1 in colliders)
        {
            if (collider1.TryGetComponent(out CoinInteract coinInteract))
            {
                return coinInteract;
            }
        }

        return null;
    }
}
