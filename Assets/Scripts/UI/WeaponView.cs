using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;

    public event UnityAction<Weapon, WeaponView> SellButtonClick;

    private Weapon _weapon;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
        _sellButton.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
        _sellButton.onClick.RemoveListener(TryLockItem);
    }

    public void Render(Weapon weapon)
    {
        _weapon = weapon;
        _label.text = weapon.Label;
        _price.text = weapon.Price.ToString();
        _icon.sprite = weapon.Icon;
    }

    private void TryLockItem()
    {
        if (_weapon.IsBuyed)
            _sellButton.interactable = false;
    }

    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_weapon, this);
    }
}