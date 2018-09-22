using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cassandra;

namespace HotelsWebApp.Models
{
    public class Logger
    {
        public class LogManager
        {
            public static LogManager _instance;

            public static LogManager Instance
            {
                get
                {
                    if (_instance == null)
                        _instance = new LogManager();

                    return _instance;
                }
            }




            public void WriteLog(string message)
            {
                Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
                ISession session = cluster.Connect("hotels");
                string query = "Insert into hotels.logdetails(logid,comments,time) values(uuid(),'" + message + "',dateof(now()))";
                session.Execute(query);
            }


        }
    }
}