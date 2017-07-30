using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace jiudiandashaojilv
{
    class accesscon
    {
        static string strPath = "D:\\3.mdb";
        public static int selroominfo(int rom)
        {
            int res = -1;
            string oleCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strPath + ";Persist Security Info=True;Jet OLEDB:Database Password=rxzzp";
            OleDbConnection conn = new OleDbConnection(oleCon);
            conn.Open();
            string sql1 = "SELECT Status FROM RoomInfo WHERE (RomNo LIKE '"+rom+"')";
            OleDbCommand cmd1 = new OleDbCommand(sql1, conn);
            res = int.Parse(cmd1.ExecuteScalar() != null ? cmd1.ExecuteScalar().ToString() : "-1");
            conn.Close();
            return res;
        }
    }
}
