using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShootButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private IShootable _iShootable;

    [Inject]
    public void Constructor(IShootable shootable)
    {
        _iShootable = shootable;
        _button.onClick.AddListener(_iShootable.Shoot);
    }

    private void Update()
    {
        if(_iShootable.CanShoot)
            _button.interactable = true;
        else
            _button.interactable = false;
    }

    private void OnDisable()
    {
        _button.onClick.AddListener(_iShootable.Shoot);
    }
}
