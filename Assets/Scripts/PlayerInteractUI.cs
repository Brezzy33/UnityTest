using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        
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
