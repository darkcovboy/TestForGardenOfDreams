using UnityEngine;
using Zenject;

public class GameStateManager : MonoBehaviour
{
    private IGameEndHandler _gameEndHandler;
    private WinPanel _winPanel;
    private Inventory _inventory;

    [Inject]
    public void Constructor(IGameEndHandler gameEndHandler, WinPanel winPanel, Inventory inventory)
    {
        _gameEndHandler = gameEndHandler;
        _winPanel = winPanel;
        _gameEndHandler.OnGameEnd += EndGame;
        _inventory = inventory;
    }

    private void EndGame()
    {
        _inventory.SaveData();
        _winPanel.gameObject.SetActive(true);
    }
}
