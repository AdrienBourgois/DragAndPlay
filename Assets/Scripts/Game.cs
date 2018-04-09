using System;
using Audio;
using UnityEngine;

[RequireComponent(typeof(MusicManager), typeof(SoundManager))]
public class Game : MonoBehaviour
{
    public enum GameState
    {
        Menu,
        Game,
        Pause,
        Resume
    }

    private GameState currentGameState = GameState.Menu;

    public delegate void ChangeStateDelegate();

    public event ChangeStateDelegate OnMenuEvent;
    public event ChangeStateDelegate OnGameEvent;
    public event ChangeStateDelegate OnPauseEvent;
    public event ChangeStateDelegate OnResumeEvent;

    public void ChangeState(GameState _game_state)
    {
        currentGameState = _game_state;

        switch (_game_state)
        {
            case GameState.Menu:
                if (OnMenuEvent != null)
                    OnMenuEvent();
                break;
            case GameState.Game:
                if (OnGameEvent != null)
                    OnGameEvent();
                break;
            case GameState.Pause:
                if (OnPauseEvent != null)
                    OnPauseEvent();
                break;
            case GameState.Resume:
                if (OnResumeEvent != null)
                    OnResumeEvent();
                currentGameState = GameState.Game;
                break;
            default:
                throw new ArgumentOutOfRangeException("_game_state", _game_state, null);
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
