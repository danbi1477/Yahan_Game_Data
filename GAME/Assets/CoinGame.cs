using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinGame : MonoBehaviour
{
    public TextMeshProUGUI capitalText;
    public Button throwButton;
    public Button headsButton; // �ո� ���� ��ư
    public Button tailsButton; // �޸� ���� ��ư
    public Button upgradeButton; // ��ȭ ��ư
    public Button restartButton; // ����� ��ư
    public Image coinImage;

    public Sprite frontSprite; // ������ �ո� �̹���
    public Sprite backSprite;  // ������ �޸� �̹���

    public int capital = 1000;
    public int betAmount = 100;
    public int winAmount = 200;
    public int upgradeCost = 500;
    public int upgradeCount = 0; // ��ȭ Ƚ��
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        capitalText.text = "Capital: " + capital.ToString();
        throwButton.onClick.AddListener(ThrowCoin);
        headsButton.onClick.AddListener(() => SelectSide(true));
        tailsButton.onClick.AddListener(() => SelectSide(false));
        upgradeButton.onClick.AddListener(UpgradeCoin);
        restartButton.onClick.AddListener(RestartGame);
        restartButton.gameObject.SetActive(false); // ���� ���� �� ����� ��ư ��Ȱ��ȭ
    }

   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Input.GetKeyDown(KeyCode.W) &&
            Input.GetKeyDown(KeyCode.E) && Input.GetKeyDown(KeyCode.R))
        {
            PayEmployee();
        }
    }

    

    void ThrowCoin()
    {
        if (gameOver) return; // ���� ���� �� ���� ������ ����

        // ������ ������ ����� ���� (50:50 Ȯ��)
        bool result = Random.Range(0, 2) == 0 ? false : true;

        // ���� �ݾ� ����
        capital -= betAmount;
        capitalText.text = "Capital: " + capital.ToString();

        // ����� ���� �ں� ��ȭ
        if (result)
        {
            capital += winAmount;
            Debug.Log("You win! Capital: " + capital);
        }
        else
        {
            Debug.Log("You lose! Capital: " + capital);
        }

        // ���� �̹��� ����
        coinImage.sprite = result ? frontSprite : backSprite;

        // �յ� ���߱� �Ǵ�
        CheckGuess(result);

        // ���� ���� Ȯ��
        CheckGameStatus();
    }

    void SelectSide(bool isHeads)
    {
        if (gameOver) return; // ���� ���� �� ���� ����

        Debug.Log(isHeads ? "You selected Heads" : "You selected Tails");
        ThrowCoin();
    }

    void UpgradeCoin()
    {
        if (gameOver) return; // ���� ���� �� ��ȭ ����

        if (upgradeCount < 10 && capital >= upgradeCost * (upgradeCount + 1))
        {
            capital -= upgradeCost * (upgradeCount + 1); // ��ȭ Ƚ���� ���� ��� ����
            capitalText.text = "Capital: " + capital.ToString();
            upgradeCount++;
            Debug.Log("Coin upgraded! Upgrade Count: " + upgradeCount);

            // ��ȭ ��뿡 ���� �� ����
            int upgradeAmount = 50 * upgradeCount;
            capital += upgradeAmount;
            Debug.Log("Capital increased by " + upgradeAmount + "! Capital: " + capital);
        }
        else
        {
            Debug.Log("Upgrade failed! Upgrade Count: " + upgradeCount);
        }

        // ���� ���� Ȯ��
        CheckGameStatus();
    }

    void PayEmployee()
    {
        if (gameOver) return; // ���� ���� �� �˹ٺ� ���� ����

        for (int i = 0; i < 4; i++)
        {
            capital -= Random.Range(50, 201); // �˹ٺ�� 50���� 200 ������ ������ �ݾ�
        }
        capitalText.text = "Capital: " + capital.ToString();
        Debug.Log("Employee paid! Capital: " + capital);

        // ���� ���� Ȯ��
        CheckGameStatus();
    }

    void CheckGuess(bool result)
    {
        // ����� ���� �Ǵ�
        if (result)
        {
            Debug.Log("You guessed correctly!");

            // ��ȭ�� ��ŭ �� ����
            int upgradeAmount = 50 * upgradeCount;
            capital += upgradeAmount;
            Debug.Log("Capital increased by " + upgradeAmount + "! Capital: " + capital);
        }
        else
        {
            Debug.Log("You guessed wrong!");
        }
    }

    void CheckGameStatus()
    {
        if (capital <= 0)
        {
            Debug.Log("Game over! Capital: " + capital);
            gameOver = true;
            restartButton.gameObject.SetActive(true); // ���� ���� �� ����� ��ư Ȱ��ȭ
        }
    }
    void RestartGame()
    {
        capital = 1000;
        upgradeCount = 0;
        capitalText.text = "Capital: " + capital.ToString();
        Debug.Log("Game restarted! Capital: " + capital);

        gameOver = false;
        restartButton.gameObject.SetActive(false); // ���� ����� �� ����� ��ư ��Ȱ��ȭ
    }

}