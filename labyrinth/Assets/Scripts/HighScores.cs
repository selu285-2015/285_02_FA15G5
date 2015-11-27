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
    string timeString;
    string timeInMinsAndSecs;
    GUIText highScores;
    GUIStyle style = new GUIStyle();
    public Font myFont;
    IDbCommand dbcmd;
    IDataReader reader;
    string sql;
    string[] deathArray;
    string[] totalTime;
    public Text Score1;
    public Text Score2;
    public Text Score3;
    public Text Score4;
    public Text Score5;
    public Text Score6;
    public Text Score7;
    public Text Score8;
    public Text Score9;
    public Text Score10;
    bool isUserHighScore;

	// Use this for initialization
	void Start () {
        deaths = RoundEnd.deathCount;
        deathsString = deaths.ToString();
        time = RoundEnd.totalTime + GameEnd.totalTime;
        timeString = TimeToString(time);
        style.fontSize = 25;
        style.normal.textColor = Color.white;
        style.font = myFont;
        deathArray = new string[10];
        totalTime = new string[10];
        Score1.text = "";
        Score2.text = "";
        Score3.text = "";
        Score4.text = "";
        Score5.text = "";
        Score6.text = "";
        Score7.text = "";
        Score8.text = "";
        Score9.text = "";
        Score10.text = "";
        isUserHighScore = false;
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
            Application.LoadLevel(4);
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
        if (deathArray[0] == deathsString && totalTime[0] == timeString && isUserHighScore == false)
        {
            Score1.color = Color.red;
            isUserHighScore = true;
        }
        if (deathArray[1] == deathsString && totalTime[1] == timeString && isUserHighScore == false)
        {
            Score2.color = Color.red;
            isUserHighScore = true;
        }
        if (deathArray[2] == deathsString && totalTime[2] == timeString && isUserHighScore == false)
        {
            Score3.color = Color.red;
            isUserHighScore = true;
        }
        if (deathArray[3] == deathsString && totalTime[3] == timeString && isUserHighScore == false)
        {
            Score4.color = Color.red;
            isUserHighScore = true;
        }
        if (deathArray[4] == deathsString && totalTime[4] == timeString && isUserHighScore == false)
        {
            Score5.color = Color.red;
            isUserHighScore = true;
        }
        if (deathArray[5] == deathsString && totalTime[5] == timeString && isUserHighScore == false)
        {
            Score6.color = Color.red;
            isUserHighScore = true;
        }
        if (deathArray[6] == deathsString && totalTime[6] == timeString && isUserHighScore == false)
        {
            Score7.color = Color.red;
            isUserHighScore = true;
        }
        if (deathArray[7] == deathsString && totalTime[7] == timeString && isUserHighScore == false)
        {
            Score8.color = Color.red;
            isUserHighScore = true;
        }
        if (deathArray[8] == deathsString && totalTime[8] == timeString && isUserHighScore == false)
        {
            Score9.color = Color.red;
            isUserHighScore = true;
        }
        if (deathArray[9] == deathsString && totalTime[9] == timeString && isUserHighScore == false)
        {
            Score10.color = Color.red;
            isUserHighScore = true;
        }

        Score1.text = deathArray[0] + "\t" + "\t" + "\t" + totalTime[0] + "\n";
        Score2.text = deathArray[1] + "\t" + "\t" + "\t" + totalTime[1] + "\n";
        Score3.text = deathArray[2] + "\t" + "\t" + "\t" + totalTime[2] + "\n";
        Score4.text = deathArray[3] + "\t" + "\t" + "\t" + totalTime[3] + "\n";
        Score5.text = deathArray[4] + "\t" + "\t" + "\t" + totalTime[4] + "\n";
        Score6.text = deathArray[5] + "\t" + "\t" + "\t" + totalTime[5] + "\n";
        Score7.text = deathArray[6] + "\t" + "\t" + "\t" + totalTime[6] + "\n";
        Score8.text = deathArray[7] + "\t" + "\t" + "\t" + totalTime[7] + "\n";
        Score9.text = deathArray[8] + "\t" + "\t" + "\t" + totalTime[8] + "\n";
        Score10.text = deathArray[9] + "\t" + "\t" + "\t" + totalTime[9] + "\n";            
        
    }

}
