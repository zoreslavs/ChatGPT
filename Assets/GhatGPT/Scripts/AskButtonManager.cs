using UnityEngine;
using TMPro;

public class AskButtonManager : MonoBehaviour
{
    [Header("Elements:")]
    [SerializeField] private DiscussionManager _discussionManager;
    [SerializeField] private STTBridge _sttBridge;
    [SerializeField] private TMP_InputField _inputField;

    [Header("Graphics:")]
    [SerializeField] private GameObject _micImage;
    [SerializeField] private GameObject _askTextField;

    private bool _isRecording;

    private void Start()
    {
        ShowMicrophone(true);
        _inputField.onValueChanged.AddListener(OnInputFieldValueChangedCallback);
    }

    public void PointerDownCallback()
    {
        if (_inputField.text.Length > 0)
        {
            _discussionManager.AskButtonCallback();
        }
        else
        {
            _isRecording = true;
            _sttBridge.Activate(true);
        }
    }

    public void PointerUpCallback()
    {
        if (_isRecording)
        {
            _isRecording = false;
            _sttBridge.Activate(false);
        }

        OnInputFieldValueChangedCallback(_inputField.text);
    }

    private void OnInputFieldValueChangedCallback(string text)
    {
        if (_isRecording)
            return;

        ShowMicrophone(text.Length <= 0);
    }

    private void ShowMicrophone(bool value)
    {
        _micImage.SetActive(value);
        _askTextField.SetActive(!value);
    }
}