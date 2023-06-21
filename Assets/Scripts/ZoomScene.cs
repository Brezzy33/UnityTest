using UnityEngine;
using UnityEngine.UI;

public class ZoomScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<RawImage>().texture = ShareImage.RawImage.texture;
    }
}
