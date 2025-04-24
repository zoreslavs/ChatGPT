using UnityEngine;

public class ContentAutoScroll : MonoBehaviour
{
    private RectTransform _transform;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        DiscussionManager.OnMessageReceived += OnMessageReceived;
    }

    private void OnDestroy()
    {
        DiscussionManager.OnMessageReceived -= OnMessageReceived;
    }

    private void OnMessageReceived()
    {
        DelayedScrollDown();
    }

    private void DelayedScrollDown()
    {
        Invoke(nameof(ScrollDown), 0.3f);
    }

    private void ScrollDown()
    {
        Vector2 anchoredPos = _transform.anchoredPosition;
        anchoredPos.y = Mathf.Max(0, _transform.sizeDelta.y);
        _transform.anchoredPosition = anchoredPos;
    }
}