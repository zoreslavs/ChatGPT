using Meta.WitAi.Requests;
using Meta.WitAi.Json;
using Oculus.Voice;
using UnityEngine;
using TMPro;

public class STTBridge : MonoBehaviour
{
    [Header("Elements:")]
    [SerializeField] private TMP_InputField _inputField;

    [Header("Listen Settings:")]
    [SerializeField] private AppVoiceExperience _appVoiceExperience;

    private void Start()
    {
        _appVoiceExperience.UsePlatformIntegrations = false;
        _appVoiceExperience.VoiceEvents.OnStartListening.AddListener(OnStartListening);
        _appVoiceExperience.VoiceEvents.OnStoppedListening.AddListener(OnStopListening);
        _appVoiceExperience.VoiceEvents.OnError.AddListener(OnError);
        _appVoiceExperience.VoiceEvents.OnResponse.AddListener(OnResponse);
        _appVoiceExperience.VoiceEvents.OnComplete.AddListener(OnComplete);
        _appVoiceExperience.VoiceEvents.OnPartialTranscription.AddListener(OnTranscriptionChange);
        _appVoiceExperience.VoiceEvents.OnFullTranscription.AddListener(OnTranscriptionChange);
    }

    private void OnDestroy()
    {
        _appVoiceExperience.VoiceEvents.OnStartListening.RemoveListener(OnStartListening);
        _appVoiceExperience.VoiceEvents.OnStoppedListening.RemoveListener(OnStopListening);
        _appVoiceExperience.VoiceEvents.OnError.RemoveListener(OnError);
        _appVoiceExperience.VoiceEvents.OnResponse.RemoveListener(OnResponse);
        _appVoiceExperience.VoiceEvents.OnComplete.RemoveListener(OnComplete);
        _appVoiceExperience.VoiceEvents.OnPartialTranscription.RemoveListener(OnTranscriptionChange);
        _appVoiceExperience.VoiceEvents.OnFullTranscription.RemoveListener(OnTranscriptionChange);
    }

    public void Activate(bool value)
    {
        if (value)
            _appVoiceExperience.Activate();
        else
            _appVoiceExperience.Deactivate();
    }

    private void OnStartListening()
    {
        Debug.Log("VoiceEvent - OnStartListening!");
    }

    private void OnStopListening()
    {
        Debug.Log("VoiceEvent - OnStopListening!");
    }

    private void OnResponse(WitResponseNode response)
    {
        Debug.Log("VoiceEvent - OnResponse: " + response.ToString());
    }

    private void OnError(string status, string error)
    {
        Debug.Log("VoiceEvent - OnError: " + status + " " + error);
    }

    public void OnComplete(VoiceServiceRequest request)
    {
        Debug.Log("VoiceEvent - OnComplete: " + (request.ResponseData != null ? request.ResponseData.Value : "ResponseData is empty."));
    }

    public void OnTranscriptionChange(string text)
    {
        Debug.Log("VoiceEvent - OnTranscriptionChange: " + text);
        SetText(text);
    }

    private void SetText(string text)
    {
        _inputField.text = text;
    }
}