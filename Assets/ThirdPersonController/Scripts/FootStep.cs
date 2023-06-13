using UnityEngine;

public class FootPrints : MonoBehaviour
{
    public GameObject _leftFootPrint;
    public GameObject _rightFootPrint;

    public Transform _leftFootLocation;
    public Transform _rightFootLocation;

    [SerializeField]
    public float FootPrintOffset = 0.05f;

    private void CreateLeftFootPrint()
    {
        if (Physics.Raycast(_leftFootLocation.position, _leftFootLocation.forward, out RaycastHit hit))
        {
            Instantiate(_leftFootPrint, hit.point + hit.normal * FootPrintOffset,  Quaternion.AngleAxis(_leftFootLocation.transform.eulerAngles.y, Vector3.up));
        }
    }

    private void CreateRightFootPrint()
    {
        if (Physics.Raycast(_rightFootLocation.position, _rightFootLocation.forward, out RaycastHit hit))
        {
            Instantiate(_rightFootPrint, hit.point + hit.normal * FootPrintOffset, Quaternion.AngleAxis(_rightFootLocation.transform.eulerAngles.y, Vector3.up) /*Quaternion.LookRotation(hit.normal, _rightFootLocation.up)*/);
        }
    }
}
