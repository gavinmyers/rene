using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using ReneData.DataObject;
using System.Data.Common;
using System.Reflection;
using System.Collections.ObjectModel;

namespace ReneData.Data
{
    public static class DatabaseReceiver
    {
        static String cns = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "Data\\Database.mdf;Integrated Security=True;User Instance=True";
        static SqlConnection cn = new SqlConnection(cns);

        /**************/
        /*		User   */
        /**************/
        public static List<User> spUsers(DataObject.User User)
        {
            ArrayList al = spSearch(User, User.ToSearch());
            List<User> lu = new List<User>();
            foreach (User u in al)
            {
                lu.Add(u);
            }
            return lu;
        }
        public static void spDeleteUser(DataObject.User User)
        {
            spDelete(User.ToDelete());
        }
        /*
        public static User spUser(DataObject.User User)
        {
            return spSelect(User, User.ToSelect()) as User;
        }
        public static User spAddUser(DataObject.User User)
        {
            User.id = spInsert(User.ToInsert());
            return user;
        }

        public static void spUpdateUser(DataObject.User User)
        {
            spUpdate(User.ToUpdate());
        }
        */


        /* ********************************** */
        /* GENERICS */
        /* ********************************** */
        public static Object spSelect(object obj, SqlCommand sql)
        {
            Type type = obj.GetType();
            DataSet ds = spQuery(sql);
            foreach (DataRow drc in ds.Tables["UserInfo"].Rows)
            {
                object[] args = new object[1];
                args[0] = drc;
                return Activator.CreateInstance(type, args);
            }
            return null;
        }

        public static ArrayList spSearch(object obj, SqlCommand sql)
        {
            Type type = obj.GetType();
            ArrayList al = new ArrayList();
            DataSet ds = spQuery(sql);
            foreach (DataRow drc in ds.Tables["UserInfo"].Rows)
            {
                object[] args = new object[1];
                args[0] = drc;
                al.Add(Activator.CreateInstance(type, args));
            }
            return al;
        }


        private static DataSet spQuery(SqlCommand command)
        {
            //SqlCommand command = new SqlCommand(sql.CommandText, cn);
            command.CommandType = CommandType.Text;
            command.Connection = cn;

            //SqlCommand command 

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet("UserInfo");
            da.Fill(ds, "UserInfo");
            return ds;
        }

        public static void spUpdate(SqlCommand command)
        {
            //SqlCommand command = new SqlCommand(sql, cn);

            cn.Open();
            command.Connection = cn;
            command.ExecuteNonQuery();
            cn.Close();
        }

        public static int spInsert(SqlCommand command)
        {
            //all inserts should return an id
            command.CommandText = command.CommandText += " select scope_identity() as scope_identity";


            DataSet ds = spQuery(command);
            int i = 0;
            foreach (DataRow drc in ds.Tables["UserInfo"].Rows)
            {
                i = int.Parse(drc["scope_identity"].ToString());
                break;
            }
            return i;

        }

        public static DataSet spSpreadsheet(Spreadsheet spreadsheet, string sql)
        {

            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + spreadsheet.uri.LocalPath + ";Extended Properties='Excel 8.0;HDR=YES;'";

            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");

            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand command = connection.CreateCommand())
                {
                    // Cities$ comes from the name of the worksheet
                    command.CommandText = sql;

                    connection.Open();


                    using (DbDataReader dr = command.ExecuteReader())
                    {
                        return convertDataReaderToDataSet(dr);
                    }
                }
            }


            return null;
        }

        public static DataSet convertDataReaderToDataSet(DbDataReader reader)
        {
            DataSet dataSet = new DataSet("UserInfo");
            do
            {
                // Create new data table

                DataTable schemaTable = reader.GetSchemaTable();
                DataTable dataTable = new DataTable();

                if (schemaTable != null)
                {
                    // A query returning records was executed

                    for (int i = 0; i < schemaTable.Rows.Count; i++)
                    {
                        DataRow dataRow = schemaTable.Rows[i];
                        // Create a column name that is unique in the data table
                        string columnName = (string)dataRow["ColumnName"]; //+ "<C" + i + "/>";
                        // Add the column definition to the data table
                        DataColumn column = new DataColumn(columnName, (Type)dataRow["DataType"]);
                        dataTable.Columns.Add(column);
                    }

                    dataSet.Tables.Add(dataTable);

                    // Fill the data table we just created

                    while (reader.Read())
                    {
                        DataRow dataRow = dataTable.NewRow();

                        for (int i = 0; i < reader.FieldCount; i++)
                            dataRow[i] = reader.GetValue(i);

                        dataTable.Rows.Add(dataRow);
                    }
                }
                else
                {
                    // No records were returned

                    DataColumn column = new DataColumn("RowsAffected");
                    dataTable.Columns.Add(column);
                    dataSet.Tables.Add(dataTable);
                    DataRow dataRow = dataTable.NewRow();
                    dataRow[0] = reader.RecordsAffected;
                    dataTable.Rows.Add(dataRow);
                }
            }
            while (reader.NextResult());
            return dataSet;
        }

        private static void spDelete(SqlCommand sql)
        {
            //same as update for now... 
            //maybe more security checks or something
            spUpdate(sql);
        }



    }
}
