using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private PlayerInteract _playerInteract;

    private void Show()
    {
        _gameObject.SetActive(true);
    }

    private void Hide()
    {
        _gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerInteract.GetInteractableCoin() != null)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
}
