using UnityEngine;
using System.IO;

public class LogToFile : MonoBehaviour
{
    private string logFilePath;

    void Start()
    {
        // 로그 파일 경로 설정
        string logsFolderPath = "D:/.DEV/Yuhan_Game_Data_Analysis/CoinGame/Log"; // 로그 파일을 저장할 폴더 경로
        if (!Directory.Exists(logsFolderPath))
        {
            Directory.CreateDirectory(logsFolderPath); // 폴더가 없으면 생성
        }
        logFilePath = Path.Combine(logsFolderPath, "log.txt");

        // 파일이 이미 존재하면 삭제
        if (File.Exists(logFilePath))
        {
            File.Delete(logFilePath);
        }

        // 로그 메시지를 파일에 추가하는 함수를 로그 메시지 이벤트에 연결
        Application.logMessageReceived += LogToFileCallback;
    }

    void LogToFileCallback(string logString, string stackTrace, LogType type)
    {
        // 로그를 파일에 추가
        using (StreamWriter writer = File.AppendText(logFilePath))
        {
            writer.WriteLine(logString);
            writer.WriteLine(stackTrace);
            writer.WriteLine(type);
            writer.WriteLine("-------------------------------------------");
        }
    }
}