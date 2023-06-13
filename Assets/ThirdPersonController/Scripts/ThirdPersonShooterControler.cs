using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ThirdPersonShooterControler : MonoBehaviour
{
    [SerializeField] private Rig _aimRig;
    [SerializeField] private CinemachineVirtualCamera _aimVirtualCamera;
    [SerializeField] private float _normalSensitivity;
    [SerializeField] private float _aimSensitivity;
    [SerializeField] private LayerMask _aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform _debugTransform;
    [SerializeField] private Transform _bulletProjectile;
    [SerializeField] private Transform _spawnBulletPosition;

    private ThirdPersonController _thirdPersonController;
    private StarterAssetsInputs _starterAssetsInputs;
    private Animator _animator;

    private void Awake()
    {
        _starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        _thirdPersonController = GetComponent<ThirdPersonController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, _aimColliderLayerMask))
        {
            _debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }

        if (_starterAssetsInputs.aim)
        {
            //Actiavate aim camera
            _aimVirtualCamera.gameObject.SetActive(true);
            _thirdPersonController.SetSensitivity(_aimSensitivity);
            _thirdPersonController.SetRotateOnMove(false);
            //Show aiming animation layer
            _animator.SetLayerWeight(1, Mathf.Lerp(_animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

            //Aiming rig
            //_aimRig.weight = Mathf.Lerp(_aimRig.weight, 1f, Time.deltaTime * 20f);
        }
        else
        {
            //Diactivate aim camera
            _aimVirtualCamera.gameObject.SetActive(false);
            _thirdPersonController.SetSensitivity(_normalSensitivity);
            _thirdPersonController.SetRotateOnMove(true);
            //Switch to regular animation layer
            _animator.SetLayerWeight(1, Mathf.Lerp(_animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));

            //Aiming rig
            //_aimRig.weight = Mathf.Lerp(_aimRig.weight, 0f, Time.deltaTime * 20f);
        }

        if(_starterAssetsInputs.shoot)
        {
            Vector3 aimDirection = (mouseWorldPosition - _spawnBulletPosition.position).normalized;
            Instantiate(_bulletProjectile, _spawnBulletPosition.position, Quaternion.LookRotation(aimDirection, Vector3.up));
            _starterAssetsInputs.shoot = false;
        }
    }
}
