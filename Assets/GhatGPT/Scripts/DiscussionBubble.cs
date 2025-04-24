using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

public class DiscussionBubble : MonoBehaviour
{
    [Header("Elements:")]
    [SerializeField] private TextMeshProUGUI _messageText;
    [SerializeField] private Image _bubbleImage;
    [SerializeField] private Sprite _userBubbleSprite;
    [SerializeField] private GameObject _voiceButton;
    [SerializeField] private Image _voiceButtonIcon;
    [SerializeField] private Sprite[] _voiceButtonSprites;

    [Header("Settings:")]
    [SerializeField] private Color _userBubbleColor;

    [Header("Events:")]
    [SerializeField] public static Action<string> OnVoiceButtonClicked;

    public void Configure(string message, bool isUserMessage)
    {
        if (isUserMessage)
        {
            _bubbleImage.sprite = _userBubbleSprite;
            _bubbleImage.color = _userBubbleColor;
            _messageText.color = Color.white;
            _voiceButton.SetActive(false);
        }

        _messageText.text = message;
        _messageText.ForceMeshUpdate();
    }

    public void VoiceButtonCallback()
    {
        _voiceButtonIcon.sprite = (_voiceButtonIcon.sprite == _voiceButtonSprites[0]) ? _voiceButtonSprites[1] : _voiceButtonSprites[0];
        OnVoiceButtonClicked?.Invoke(_messageText.text);
    }

    public void CopyButtonCallback()
    {
        GUIUtility.systemCopyBuffer = _messageText.text;
    }
}