using System
using UnityEngine;

[CreateAssetMenu(filename = "Cell", menuName = "Game/Cell")]
public class Cell
{
    public int Id;      // Unique identifier for each cell
    public int Value;   // 0 = empty, 1 = X, 2 = O
    public bool isInteractive { get; private set }  // Controls whether the cell is clickable
    public event Action<int, int> OnValueChanged;   // Notify when the cell's value changes
    public event Action<bool> OnGameFinished;       // Notify when the game ends
    
    // Updates the cell value (X, O or empty)
    // Trigger OnValueChanged event
    public void SetValue(int newValue)
    {
        Value = newValue;
        OnValueChanged?.Invoke(Id, Value);
    }
    
    // Set the game results
    // Disables interactivity
    // Triggers OnGameFinished event
    public void SetResult(bool isWin)
    {
        OnGameFinished?.Invoke(isWin);
        IsInteractive = false;
    }

    // Resets the cell to its initial state
    // Re-enable interactivity
    public void Reset()
    {
        IsInteractive = true;
        SetValue(0)
    }
}
