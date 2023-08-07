
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Reflection;
using Zone_Obje.ObjeCommands;
using System.Reflection;
using System.Reflection.Emit;
using System.Linq.Expressions;

namespace SqlWorker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Program.InstanceForm1 = this;
        }
        static string ServerName = "";
        object getvalue()
        {
            ServerName = txtServerName.Text;
            return ServerName;
        }
        string GetConnectionString()
        {
            getvalue();
            string ss = GetConstr();
            return ss;
        }
        string GetConstrWithUser(string UserName, string Password)
        {
            getvalue();
            string ss = GetConstrmY(UserName, Password);
            return ss;
        }
        static string GetConstrmY(string username, string password)
        {

            string ConnectionString = "Data Source=" + ServerName + ";   User ID=" + username + ";Password=" + password + " Integrated Security=true";
            return ConnectionString;
        }
        static string GetConstr()
        {

            string ConnectionString = "Data Source=" + ServerName + ";   Integrated Security=true";
            return ConnectionString;
        }

        string ReGetConStr(string Constr)
        {
            string ConnectionString = "Data Source=" + ServerName + ";  Initial Catalog =" + Constr + ";  Integrated Security=true";
            return ConnectionString;
        }


        SqlConnection SqlCon = new SqlConnection();

        List<string> _TableList = new List<string>();
        List<string> _DatabaseList = new List<string>();
        Dictionary<string, string> _ColumnList = new Dictionary<string, string>();
        string _database = "";
        string _Table = "";
        DbCommands db;

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                sqlLogin1.Show();
              
                txtServerName.Visible = false;
                label4.Visible = false;
            }
            else
            {
                sqlLogin1.Hide();
                txtServerName.Visible = true;
                label4.Visible = true;
            }
        }
        void GetTable()
        {
            LBTable.Text = "";
            DbCommands DbCommand = new DbCommands(false, ReGetConStr(_database));
            db = DbCommand;
            LBTable.Items.Clear();
            string cmd = "SELECT * FROM SYS.TABLES";
            _TableList = DbCommand.ExecuteReader(cmd, System.Data.CommandType.Text);
            foreach (var item in _TableList)
            {
                LBTable.Items.Add(item.ToString());
            }
        }
        string CreateProperty(string columnName, string dataType)
        {
            string csharpType = "";
            switch (dataType)
            {
                case "bigint":
                    csharpType = "long";
                    break;
                case "binary":
                case "varbinary":
                case "image":
                    csharpType = "byte[]";
                    break;
                case "bit":
                    csharpType = "bool";
                    break;
                case "char":
                case "varchar":
                case "text":
                    csharpType = "string";
                    break;
                case "date":
                case "datetime":
                case "datetime2":
                case "smalldatetime":
                    csharpType = "DateTime";
                    break;
                case "datetimeoffset":
                    csharpType = "DateTimeOffset";
                    break;
                case "decimal":
                case "numeric":
                case "money":
                case "smallmoney":
                    csharpType = "decimal";
                    break;
                case "float":
                    csharpType = "double";
                    break;
                case "int":
                    csharpType = "int";
                    break;
                case "nchar":
                case "nvarchar":
                case "ntext":
                    csharpType = "string";
                    break;
                case "real":
                    csharpType = "float";
                    break;
                case "rowversion":
                case "timestamp":
                    csharpType = "byte[]";
                    break;
                case "smallint":
                    csharpType = "short";
                    break;
                case "time":
                    csharpType = "TimeSpan";
                    break;
                case "tinyint":
                    csharpType = "byte";
                    break;
                case "uniqueidentifier":
                    csharpType = "Guid";
                    break;
                default:
                    csharpType = "object";
                    break;
            }

            string property = "";
            property += "public " + csharpType + " " + columnName + " { get; set; }" + Environment.NewLine + " ";
            return property;
        }


        public delegate object ObjectActivator(params object[] args);
        public static void CreateHelloClass()
        {


            var ao = new { ID = 10000, FName = "Sample", SName = "Name" };
            var t = ao.GetType();
            var info = t.GetConstructor(new[] { typeof(int), typeof(string), typeof(string) });
            if (info == null)
            {
                throw new Exception("Info is null");
            }

            // This uses System.Linq.Expressions to create the delegate
            var activator = GetActivator(info);
            var newObj1 = activator(4, "Foo", "Bar");

            // This invokes the ConstructorInfo directly
            var newObj2 = info.Invoke(new object[] { 4, "Foo", "Bar" });

            // This uses System.Activator to dynamically create the instance
            var newObj3 = Activator.CreateInstance(t, 4, "Foo", "Bar");

        }
        // This uses System.Linq.Expressions to generate a delegate
        public static ObjectActivator GetActivator(ConstructorInfo ctor)
        {
            var args = Expression.Parameter(typeof(object[]), "args");
            var parameters = ctor.GetParameters().Select((parameter, index) => Expression.Convert(Expression.ArrayIndex(args, Expression.Constant(index)), parameter.ParameterType));
            return Expression.Lambda<ObjectActivator>(Expression.New(ctor, parameters), args).Compile();
        }

        void GetColumn(string TableName)
        {
            LBColumn.Items.Clear();
            string cmd = "SELECT COLUMN_NAME,DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + TableName + "'";
            _ColumnList = db.ExecuteReaderDictionary(cmd, System.Data.CommandType.Text);
            TxtProperty.Text = "";
            foreach (var item in _ColumnList)
            {
                string columnName = item.Key.ToString();
                string dataType = item.Value.ToString();
                LBColumn.Items.Add("" + columnName + "," + dataType + "");

                TxtProperty.Text += CreateProperty(columnName, dataType);

                CreateHelloClass();

            }
        }
        public bool PullProvider(string UserName = "", string Password = "")
        {
            lBDatabase.Items.Clear();
            bool rvalue = false;
            if (UserName == "" || Password == "")
            {
                DbCommands DbCommand = new DbCommands(false, GetConnectionString());
                SqlCon.ConnectionString = GetConnectionString();

                string s = "SELECT * FROM SYS.sysdatabases";
                _DatabaseList = DbCommand.ExecuteReader(s, System.Data.CommandType.Text);
                foreach (var item in _DatabaseList)
                {
                    lBDatabase.Items.Add(item.ToString());
                }
                rvalue = true;
            }
            else
            {
                DbCommands DbCommand = new DbCommands(false, GetConstrWithUser(UserName, Password));
                SqlCon.ConnectionString = GetConnectionString();

                string s = "SELECT * FROM SYS.sysdatabases";
                _DatabaseList = DbCommand.ExecuteReader(s, System.Data.CommandType.Text);
                foreach (var item in _DatabaseList)
                {
                    lBDatabase.Items.Add(item.ToString());
                }
                rvalue = true;
            }
            return rvalue;
        }
        private void btnGetDatabase_Click(object sender, EventArgs e)
        {
            PullProvider();
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            _database = lBDatabase.SelectedItem.ToString();
            GetTable();
        }
        private void LBTable_DoubleClick(object sender, EventArgs e)
        {
            _Table = LBTable.SelectedItem.ToString();
            GetColumn(_Table);
        }

        private void txtServerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void sqlLogin1_Load(object sender, EventArgs e)
        {

        }
    }
}