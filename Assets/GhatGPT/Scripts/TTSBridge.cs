using Meta.WitAi.TTS.Utilities;
using UnityEngine;

public class TTSBridge : MonoBehaviour
{
    [Header("Elements:")]
    [SerializeField] private TTSSpeaker _speaker;

    private void OnEnable()
    {
        DiscussionBubble.OnVoiceButtonClicked += OnVoiceButtonClicked;
    }

    private void OnDisable()
    {
        DiscussionBubble.OnVoiceButtonClicked -= OnVoiceButtonClicked;
    }

    private void OnVoiceButtonClicked(string message)
    {
        if (_speaker.IsSpeaking)
        {
            _speaker.Stop();
        }
        else
        {
            TextToVoice(message);
        }
    }

    private void TextToVoice(string message)
    {
        var messages = message.Split(".");
        _speaker.StartCoroutine(_speaker.SpeakQueuedAsync(messages));
    }
}