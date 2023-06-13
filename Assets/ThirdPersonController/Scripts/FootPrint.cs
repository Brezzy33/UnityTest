using System.Collections;
using UnityEngine;

public class FootPrint : MonoBehaviour
{
    int lifeTime = 10;
    public void Start()
    {
        StartCoroutine(WaitThenDie());
    }

    IEnumerator WaitThenDie()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
