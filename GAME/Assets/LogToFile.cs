using UnityEngine;
using System.IO;

public class LogToFile : MonoBehaviour
{
    private string logFilePath;

    void Start()
    {
        // �α� ���� ��� ����
        string logsFolderPath = "D:/.DEV/Yuhan_Game_Data_Analysis/CoinGame/Log"; // �α� ������ ������ ���� ���
        if (!Directory.Exists(logsFolderPath))
        {
            Directory.CreateDirectory(logsFolderPath); // ������ ������ ����
        }
        logFilePath = Path.Combine(logsFolderPath, "log.txt");

        // ������ �̹� �����ϸ� ����
        if (File.Exists(logFilePath))
        {
            File.Delete(logFilePath);
        }

        // �α� �޽����� ���Ͽ� �߰��ϴ� �Լ��� �α� �޽��� �̺�Ʈ�� ����
        Application.logMessageReceived += LogToFileCallback;
    }

    void LogToFileCallback(string logString, string stackTrace, LogType type)
    {
        // �α׸� ���Ͽ� �߰�
        using (StreamWriter writer = File.AppendText(logFilePath))
        {
            writer.WriteLine(logString);
            writer.WriteLine(stackTrace);
            writer.WriteLine(type);
            writer.WriteLine("-------------------------------------------");
        }
    }
}