using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using OpenAI.Chat;
using OpenAI;
using System;
using TMPro;

public class DiscussionManager : MonoBehaviour
{
    [Header("Elements:")]
    [SerializeField] private DiscussionBubble _bubblePrefab;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Transform _bubbleContainer;

    [Header("Events:")]
    public static Action OnMessageReceived;

    [Header("Authentication:")]
    [SerializeField] private string _apiKey;
    [SerializeField] private string _organizationId;

    private OpenAIClient _openAIApi;
    private List<Message> _messages = new();

    private void Start()
    {
        Authenticate();
        Initialize();
        CreateBubble("Hey! How can I help you?", false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            AskButtonCallback();
        }
    }

    public async void AskButtonCallback()
    {
        CreateBubble(_inputField.text, true);

        var response = await GetChatResponseAsync();
        if (response != null)
        {
            AddMessage(Role.System, response.FirstChoice.ToString());
            CreateBubble(response.FirstChoice.ToString(), false);
        }

        _inputField.text = "";
    }

    private async Task<ChatResponse> GetChatResponseAsync()
    {
        try
        {
            return await _openAIApi.ChatEndpoint.GetCompletionAsync(AddMessage(Role.User, _inputField.text));
        }
        catch (Exception e)
        {
            Debug.Log("Send request error: " + e.Message);
        }
        Debug.Log("Empty response error!");
        return null;
    }

    private void Authenticate()
    {
        _openAIApi = new OpenAIClient(new OpenAIAuthentication(_apiKey, _organizationId));
    }

    private void Initialize()
    {
        AddMessage(Role.System, "You are a weather expert.");
    }

    private void CreateBubble(string message, bool isUserMessage)
    {
        DiscussionBubble bubble = Instantiate(_bubblePrefab, _bubbleContainer);
        bubble.Configure(message, isUserMessage);
        OnMessageReceived?.Invoke();
    }

    private ChatRequest AddMessage(Role role, string content, string model = "gpt-4o")
    {
        _messages.Add(new(role: role, content: content));
        return new(_messages, model);
    }
}