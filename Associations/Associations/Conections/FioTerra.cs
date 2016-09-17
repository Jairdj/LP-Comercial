using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Associations.Conections {
    public class FioTerra {
        MySqlCommand cnm;
        MySqlConnection conn;
        MySqlDataReader dr;

        public FioTerra() {
            conn = new MySqlConnection(Strconnection());
        }

        private string Strconnection() {
            return "Server = localhost" +
                    ";Port = 3306" +
                    ";Database = associationdb" +
                    ";Uid = root" +
                    ";Pwd = ";
         }

        private void Connect() {
            if(conn.State != System.Data.ConnectionState.Open ) {
                conn.Open();
            }
        }

        private void Close() {
            if( conn.State != System.Data.ConnectionState.Closed)
                conn.Close();
        }

        public void ExecuteCommand(MySqlCommand pCmd ) {
            Connect();
            pCmd.Connection = conn;
            pCmd.ExecuteNonQuery();
            Close();
        }

        public MySqlDataReader GetDataReader( MySqlCommand pCmd) {
            Connect();
            pCmd.Connection = conn;
            dr = pCmd.ExecuteReader();

            return dr;

        }
    }
}