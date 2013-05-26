using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Threading;
using System.Threading;
using System.Collections.ObjectModel;
using Rene;
using System;
using System.Data;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace ReneData.DataObject
{
    [Serializable]
    [DataContract]
    public class User : Rene.DataObject.DataObject
    {
        public User()
        {
        }

        public User(DataRow drc)
        {
			this.id = (int)drc["UserID"];
			this.FirstName = (string)drc["FirstName"];
			this.LastName = (string)drc["LastName"];
			this.Username = (string)drc["Username"];
			this.Password = (string)drc["Password"];
        }

        public User(XmlDataProvider xml)
        {
        }

        public SqlCommand ToDelete()
        {
            string sql = "Update [User] Set DeleteMark = 1 ";
            sql += " where UserID = @id";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", this.id);

            Console.WriteLine(sql);
            return cmd;
        }
        
        public SqlCommand ToSearch()
        {
            string sql = "SELECT * FROM [User] WHERE DeleteMark != @DeleteMark ";
            if (!this.FirstName.Equals(""))
            {
                sql += " and FirstName like '%' + @FirstName + '%'";
            }
            if (!this.LastName.Equals(""))
            {
                sql += " and LastName like '%' + @LastName + '%'";
            }
            if (!this.Username.Equals(""))
            {
                sql += " and Username like '%' + @Username + '%'";
            }
            if (!this.Password.Equals(""))
            {
                sql += " and Password like '%' + @Password + '%'";
            }
            Console.WriteLine(sql);
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@DeleteMark",1);
            cmd.Parameters.AddWithValue("@FirstName", this.FirstName);
            cmd.Parameters.AddWithValue("@LastName", this.LastName);
            cmd.Parameters.AddWithValue("@Username", this.Username);
            cmd.Parameters.AddWithValue("@Password", this.Password);

            return cmd;
        }

        [DataMember]
		private int _id = 0;
		public int id
		{
			get { return _id; }
			set { _id = value; OnPropertyChanged("id"); }
		}

        [DataMember]
        private string _FirstName = "";
        public string FirstName
        {
            get { return _FirstName;}
            set { 
                _FirstName = value; 
                OnPropertyChanged("FirstName");
                if (String.IsNullOrEmpty(value))
                {
                   //throw new ApplicationException("First name is mandatory.");
                }
            }
        }

        [DataMember]
        private string _LastName = "";
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; OnPropertyChanged("LastName"); }
        }

        [DataMember]
        private string _Username = "";
        public string Username
        {
            get { return _Username; }
            set { _Username = value; OnPropertyChanged("Username"); }
        }

        [DataMember]
        private string _Password = "";
        public string Password
        {
            get { return _Password; }
            set { _Password = value; OnPropertyChanged("Password"); }
        }

        [DataMember]
        private Guid _PublicKey;
        public Guid PublicKey
        {
            get { return _PublicKey; }
            set { _PublicKey = value; OnPropertyChanged("PublicKey"); }
        }

        [DataMember]
        private Guid _PrivateKey;
        public Guid PrivateKey
        {
            get { return _PrivateKey; }
            set { _PrivateKey = value; OnPropertyChanged("PrivateKey"); }
        }

        [DataMember]
        private Tank _Tank = new Tank();
        public Tank Tank
        {
            get { return _Tank; }
            set { _Tank = value; OnPropertyChanged("Tank"); }
        }
    }
}
