using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceDisplayer : MonoBehaviour
{
    [SerializeField] private Resource _resource;
    [SerializeField] private Image _iconComponent;
    [SerializeField] private TMP_Text _textComponent;

    private void Start()
    {
        _iconComponent.sprite = _resource.Icon;

        _textComponent.text = _resource.Amount.ToString();

        _resource.AmountChanged += UpdateAmount;
    }

    private void OnDestroy()
    {
        _resource.AmountChanged -= UpdateAmount;
    }

    private void UpdateAmount()
    {
        _textComponent.text = _resource.Amount.ToString();
    }
}
