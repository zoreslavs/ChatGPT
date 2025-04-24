using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DiscussionBubble : MonoBehaviour
{
    [Header("Elements:")]
    [SerializeField] private TextMeshProUGUI _messageText;
    [SerializeField] private Image _bubbleImage;
    [SerializeField] private Sprite _userBubbleSprite;

    [Header("Settings:")]
    [SerializeField] private Color _userBubbleColor;

    public void Configure(string message, bool isUserMessage)
    {
        if (isUserMessage)
        {
            _bubbleImage.sprite = _userBubbleSprite;
            _bubbleImage.color = _userBubbleColor;
            _messageText.color = Color.white;
        }

        _messageText.text = message;
        _messageText.ForceMeshUpdate();
    }
}