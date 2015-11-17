using UnityEngine;
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

	// Use this for initialization
	void Start () {
        string conn = "URI=file:" + Application.dataPath + "/Plugins" + "/HighScores.s3db";
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        dbcmd = dbconn.CreateCommand();


        deaths = RoundEnd.deathCount;
        time = RoundEnd.totalTime + GameEnd.totalTime;
        mins = time / 60;
        secs = time % 60;
        timeInMinsAndSecs = string.Format("{0:0}:{1:00}", mins, secs);
        style.fontSize = 25;
        style.normal.textColor = Color.white;
        style.font = myFont;
        WriteToDB();
        ReadFromDB();
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

        while (reader.Read())
        {
            int dbDeaths = reader.GetInt32(1);
            int dbTime = reader.GetInt32(2);
        }
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
    /*void OnGUI()
    {
        GUI.Box(new Rect((Screen.width) / 2 - (Screen.width) / 8,
                                (Screen.height) / 2 - (Screen.height) / 8,
                                (Screen.width) / 4, (Screen.height) / 4),
                                "Number of deaths: " + deaths + "\n" + "Total time: " + timeInMinsAndSecs,
                                style);
    }*/

}
