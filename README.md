# Unity ChatGPT

A full ChatGPT-powered chat system built in Unity.  
The project includes API communication, chat interface logic, message history handling and optional voice features.

## Unity version

Developed and tested with **Unity 2022.3.62f2 (LTS)**.  
Other 2022 LTS versions will likely work, but are not guaranteed.

## Features

- ChatGPT API integration (request/response handling)
- Full chat-style UI with scrolling message feed
- Message history saving & loading (two approaches)
- Optional Text-to-Speech and Speech-to-Text support (via Oculus SDK)
- Activity tracking system (e.g., limit messages before showing ads)
- Rewarded Ads integration using Unity’s Mediation system
- Clean architecture using:
  - ScriptableObjects  
  - Actions & Unity Events  
  - Singleton patterns where appropriate

## Setup

1. Create an OpenAI API key in your OpenAI account.
2. Open the project in Unity (**2022.3.62f2** or compatible).
3. Open the **ChatGPT** scene (located in the `Scenes` folder).
4. In the **Hierarchy**, select **`Discussion Manager`** under the `LOGIC` group.
5. In the **Inspector**, under the `DiscussionManager` component, fill in:
   - **Api Key** – your OpenAI API key (`sk-...`)
6. Press **Play** and start chatting.

> API keys are not included in this repository.  
> Make sure you keep your own keys private and do not commit them to version control.

A solid foundation for AI-driven gameplay systems, in-game assistants or chat-based mechanics in Unity.
