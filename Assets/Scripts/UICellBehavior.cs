using UnityEngine;
using UnityEngine.UI;

namespace magicowl.tictactoe.script
{
    public class UICellBehavior: MonoBehaviour
    {
        [SerializeField] private Cell cell;
        [SerializeField] private Button button;
        [SerializeField] private Image image;
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color winColor;
        [SerializeField] private Color loseColor;

        private Sprite xSprite;
        private Sprite oSprite;
        private Sprite emptySprite;

        private void Awake()
        {
            xSprite = Resources.Load<Sprite>("x");
            oSprite = Resources.Load<Sprite>("o");
            emptySprite = Resources.Load<Sprite>("empty");
        }

        private void Start()
        {
            button.onClick.AddListener(OnButtonClick);
        }

        private void OnEnable()
        {
            cell.OnValueChanged += OnValueChanged;
            cell.OnGameFinished += OnGameFinished;
        }

        private void OnDisable()
        {
            cell.OnValueChanged -= OnValueChanged;
            cell.OnGameFinished -= OnGameFinished;
        }

        private void OnValueChanged(int cell, int newValue)
        {
            image.sprite = newValue == 1 ? xSprite : oSprite;

            if (newValue != 0) return; //game restart

            image.sprite = emptySprite;
            image.color = defaultColor;
        }

        private void OnGameFinished(bool isGameWin)
        {
            image.color = isGameWin ? winColor : loseColor;
        }

        private void OnButtonClick()
        {
            if (!cell.IsInteractive) return;

            if (cell.Value == 0)
            {
                bool isPlayerXTurn = TurnManager.Instance.GetTurn();
                int newValue = isPlayerXTurn ? 1 : 2;
                cell.SetValue(newValue);
            }
        }
    }
    
}
