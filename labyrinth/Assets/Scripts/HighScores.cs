using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class HighScores : MonoBehaviour {

    
    IDbConnection dbconn;

    int deaths;
    int time;
    int mins;
    int secs;
    string deathsString;
    string timeInMinsAndSecs;
    GUIText highScores;
    GUIStyle style = new GUIStyle();
    public Font myFont;
    IDbCommand dbcmd;
    IDataReader reader;
    string sql;
    string[] deathArray;
    string[] totalTime;
    public Text allScores;

	// Use this for initialization
	void Start () {
        deaths = RoundEnd.deathCount;
        time = RoundEnd.totalTime + GameEnd.totalTime;
        style.fontSize = 25;
        style.normal.textColor = Color.white;
        style.font = myFont;
        allScores.color = Color.white;
        deathArray = new string[10];
        totalTime = new string[10];
        allScores.text = "";
        string conn = "URI=file:" + Application.streamingAssetsPath + "/HighScores.s3db";
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open();
        dbcmd = dbconn.CreateCommand();
        WriteToDB();
        ReadFromDB();
        DisplayHighScores();
        CloseDB();
	}

	void WriteToDB() {
        sql = "INSERT INTO HighScoresTable (Deaths, Time) VALUES ("+deaths+","+time+")";
        dbcmd.CommandText = sql;
        dbcmd.ExecuteNonQuery();
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel(3);
        }
    }

    void ReadFromDB()
    {
        sql = "SELECT * FROM HighScoresTable ORDER BY Deaths, Time ASC LIMIT 10";
        dbcmd.CommandText = sql;
        reader = dbcmd.ExecuteReader();

        int i = 0;
        while (reader.Read())
        {
            int dbDeaths = reader.GetInt32(1);
            int dbTime = reader.GetInt32(2);
            string stringTime = TimeToString(dbTime);
            deathArray[i] = dbDeaths.ToString();
            totalTime[i] = stringTime;
            i++;
        }
    }

    string TimeToString(int time)
    {
        mins = time / 60;
        secs = time % 60;
        timeInMinsAndSecs = string.Format("{0:0}:{1:00}", mins, secs);
        return timeInMinsAndSecs;
    }

    void CloseDB()
    {
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    void DisplayHighScores()
    {

        for (int i = 0; i < 10; i++)
        {
            allScores.text += deathArray[i] + "\t" + "\t" + "\t" +totalTime[i] + "\n";
        }
    }

}
