using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.IO;
using Model;

namespace ViewModel
{
    public abstract class BaseDB
    {
        private string connectionString;
        private OleDbConnection connection;
        protected OleDbCommand command;
        protected OleDbDataReader reader;

        protected List<BaseEntity> list;

        protected List<BaseEntity> Added = new List<BaseEntity>();//רשימת המתנה להוספה
        protected List<BaseEntity> Changed = new List<BaseEntity>();//לעדכון
        protected List<BaseEntity> Deleted = new List<BaseEntity>();//למחיקה

        public BaseDB()
        {
            string path = GetCurrentPath() + "Data\\CakesBoutique.accdb";
            //בדומה למספר טלפון - מיקום מסד נתונים להתחברות
            connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path;
            //בדומה לטלפון - מבצע את ההתקשרות
            connection = new OleDbConnection(connectionString);
            //מה המידע הנדרש - יקבל מחרוזת שונה בכל התחברות בהתאם לטבלה הנדרשת 
            command = new OleDbCommand();
            list = new List<BaseEntity>();

        }

        protected void Select(string tableName)
        {
            command.CommandText = "Select * From " + tableName;
            command.Connection = connection;
            list = new List<BaseEntity>();
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(CreateModel());
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (connection.State == ConnectionState.Open)//בדיקה אם החיבור פתוח
                    connection.Close();
            }
            //שינוי
        }

        public void Add(BaseEntity entity)
        {
            if (entity != null)
            {
                Added.Add(entity);
                list.Add(entity);
            }
        }

        public void Update(BaseEntity entity)
        {
            Changed.Add(entity);
        }

        public void Delete(BaseEntity entity)
        {
            Deleted.Add(entity);
        }
        /// <summary>
        /// פעולה המבצעת עדכון לאקסס
        /// </summary>
        public void SaveChanges()
        {
            try
            {
                command.Connection = connection;
                connection.Open();
                foreach (var item in Added)
                {
                    command.CommandText = SQLBuilder.InsertSQL(item);
                    command.ExecuteNonQuery();
                }
                Added.Clear();

                foreach (var item in Changed)
                {
                    command.CommandText = SQLBuilder.UpdateSQL(item);
                    command.ExecuteNonQuery();
                }
                Changed.Clear();

                foreach (var item in Deleted)
                {
                    command.CommandText = SQLBuilder.UpdateSQL(item);
                    command.ExecuteNonQuery();
                    list.Remove(item);//הסרת הפריט מהרשימה המקורית
                }
                Deleted.Clear();
            }
            catch (Exception ex) { }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        public static string GetCurrentPath()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            string[] arr = path.Split('\\');
            path = "";
            for (int i = 0; i < arr.Length - 3; i++)
            {
                path += arr[i] + "\\";
            }
            return path;
        }
        protected abstract BaseEntity CreateModel();
        public virtual int GetNextKey()
        {
            return 1;
        }
    }
}
