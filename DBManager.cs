using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.IO;
using TwinCAT.Ads;
using Npgsql;
using NpgsqlTypes;
using System.Collections.Generic;
using log4net;


[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]


namespace DBManager
{	
	/// <summary>
	/// Summary description for DBManager.
	/// </summary>
    /// 
        
	public class DBManager : System.Windows.Forms.Form
	{

        private System.Windows.Forms.TreeView treeViewSymbols;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbDatatype;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbIndexGroup;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbIndexOffset;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbDatatypeId;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbValue;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tbSize;
		private System.Windows.Forms.Button btnWrite;		
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox cbFlat;
	
		private TcAdsSymbolInfoLoader symbolLoader;
		private TcAdsClient adsClient;
        private GroupBox groupBox3;
        private ListBox listBoxDBLog;
        private Button GetSqlTag;
		private ITcAdsSymbol currentSymbol = null;
        private Button TestCreateFile;
        private PictureBox LogoHeader;



        //Here is the once-per-class call to initialize the log object
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        public DBManager()
        {
            InitializeComponent();

        }
     

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.treeViewSymbols = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbFlat = new System.Windows.Forms.CheckBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDatatype = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbIndexGroup = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbIndexOffset = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDatatypeId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBoxDBLog = new System.Windows.Forms.ListBox();
            this.GetSqlTag = new System.Windows.Forms.Button();
            this.TestCreateFile = new System.Windows.Forms.Button();
            this.LogoHeader = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // treeViewSymbols
            // 
            this.treeViewSymbols.Location = new System.Drawing.Point(8, 16);
            this.treeViewSymbols.Name = "treeViewSymbols";
            this.treeViewSymbols.Size = new System.Drawing.Size(280, 280);
            this.treeViewSymbols.TabIndex = 0;
            this.treeViewSymbols.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSymbols_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbFlat);
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this.treeViewSymbols);
            this.groupBox1.Location = new System.Drawing.Point(570, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 336);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Symbols";
            // 
            // cbFlat
            // 
            this.cbFlat.Location = new System.Drawing.Point(120, 304);
            this.cbFlat.Name = "cbFlat";
            this.cbFlat.Size = new System.Drawing.Size(72, 24);
            this.cbFlat.TabIndex = 2;
            this.cbFlat.Text = "Flat";
            this.cbFlat.UseMnemonic = false;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(8, 304);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(104, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load Symbols";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(874, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 17;
            this.label3.Text = "Datatype:";
            // 
            // tbDatatype
            // 
            this.tbDatatype.Location = new System.Drawing.Point(954, 336);
            this.tbDatatype.Name = "tbDatatype";
            this.tbDatatype.ReadOnly = true;
            this.tbDatatype.Size = new System.Drawing.Size(144, 20);
            this.tbDatatype.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(874, 304);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 23);
            this.label9.TabIndex = 15;
            this.label9.Text = "Size:";
            // 
            // tbSize
            // 
            this.tbSize.Location = new System.Drawing.Point(954, 304);
            this.tbSize.Name = "tbSize";
            this.tbSize.ReadOnly = true;
            this.tbSize.Size = new System.Drawing.Size(144, 20);
            this.tbSize.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(874, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Index Group:";
            // 
            // tbIndexGroup
            // 
            this.tbIndexGroup.Location = new System.Drawing.Point(954, 240);
            this.tbIndexGroup.Name = "tbIndexGroup";
            this.tbIndexGroup.ReadOnly = true;
            this.tbIndexGroup.Size = new System.Drawing.Size(144, 20);
            this.tbIndexGroup.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(874, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Index Offset:";
            // 
            // tbIndexOffset
            // 
            this.tbIndexOffset.Location = new System.Drawing.Point(954, 272);
            this.tbIndexOffset.Name = "tbIndexOffset";
            this.tbIndexOffset.ReadOnly = true;
            this.tbIndexOffset.Size = new System.Drawing.Size(144, 20);
            this.tbIndexOffset.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(874, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 23);
            this.label5.TabIndex = 23;
            this.label5.Text = "Datatype Id:";
            // 
            // tbDatatypeId
            // 
            this.tbDatatypeId.Location = new System.Drawing.Point(954, 368);
            this.tbDatatypeId.Name = "tbDatatypeId";
            this.tbDatatypeId.ReadOnly = true;
            this.tbDatatypeId.Size = new System.Drawing.Size(144, 20);
            this.tbDatatypeId.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(874, 400);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 23);
            this.label6.TabIndex = 25;
            this.label6.Text = "Value:";
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(954, 400);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(144, 20);
            this.tbValue.TabIndex = 24;
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(874, 440);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(80, 23);
            this.btnWrite.TabIndex = 26;
            this.btnWrite.Text = "Write Value";
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(954, 208);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(144, 20);
            this.tbName.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(874, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 23);
            this.label7.TabIndex = 28;
            this.label7.Text = "Name:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBoxDBLog);
            this.groupBox3.Location = new System.Drawing.Point(17, 200);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(515, 328);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Database Log";
            // 
            // listBoxDBLog
            // 
            this.listBoxDBLog.FormattingEnabled = true;
            this.listBoxDBLog.Location = new System.Drawing.Point(16, 20);
            this.listBoxDBLog.Name = "listBoxDBLog";
            this.listBoxDBLog.Size = new System.Drawing.Size(493, 303);
            this.listBoxDBLog.TabIndex = 0;
            // 
            // GetSqlTag
            // 
            this.GetSqlTag.Location = new System.Drawing.Point(33, 544);
            this.GetSqlTag.Name = "GetSqlTag";
            this.GetSqlTag.Size = new System.Drawing.Size(91, 23);
            this.GetSqlTag.TabIndex = 29;
            this.GetSqlTag.Text = "Get SQL tags";
            this.GetSqlTag.UseVisualStyleBackColor = true;
            this.GetSqlTag.Click += new System.EventHandler(this.GetSqlTag_Click);
            // 
            // TestCreateFile
            // 
            this.TestCreateFile.Location = new System.Drawing.Point(141, 544);
            this.TestCreateFile.Name = "TestCreateFile";
            this.TestCreateFile.Size = new System.Drawing.Size(91, 23);
            this.TestCreateFile.TabIndex = 30;
            this.TestCreateFile.Text = "TestCreateFile";
            this.TestCreateFile.UseVisualStyleBackColor = true;
            this.TestCreateFile.Click += new System.EventHandler(this.TestCreateFile_Click);
            // 
            // LogoHeader
            // 
            this.LogoHeader.Image = global::DBManager.Properties.Resources.iautoLogo;
            this.LogoHeader.ImageLocation = "";
            this.LogoHeader.Location = new System.Drawing.Point(33, 23);
            this.LogoHeader.Name = "LogoHeader";
            this.LogoHeader.Size = new System.Drawing.Size(244, 128);
            this.LogoHeader.TabIndex = 31;
            this.LogoHeader.TabStop = false;
            // 
            // DBManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1218, 595);
            this.Controls.Add(this.LogoHeader);
            this.Controls.Add(this.TestCreateFile);
            this.Controls.Add(this.GetSqlTag);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.tbDatatypeId);
            this.Controls.Add(this.tbDatatype);
            this.Controls.Add(this.tbSize);
            this.Controls.Add(this.tbIndexGroup);
            this.Controls.Add(this.tbIndexOffset);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "DBManager";
            this.Text = "DBManager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogoHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        //SQL server parameters
        //Connection Npgsql
        public string constr = "Server=127.0.0.1;Port=5432;Database=DB;User Id=postgres;Password=1;";
        public string SchemaName = "stb";
        public string TableRT = "\"LiveData\"";
        public string TableACCU = "\"TableACCU\"";

        //ManageTime
        public string ActualDay = DateTime.Now.ToString("yyyy-MM-dd");

        //PLC address
        public string netidplc = "192.168.202.134.1.1";

        private Timer timer1;

        [STAThread]
		static void Main() 
		{
            log4net.Config.XmlConfigurator.Configure();
            Application.Run(new DBManager());
		}

        public class PLCvar
        {
            public PLCvar(string name, string type)
            {
                PLCname = name;
                PLCtype = type;
            }

            public string PLCname { get; set; }
            public string PLCtype { get; set; }
        }

		private void Form1_Load(object sender, System.EventArgs e)
		{
			try
			{
                log.Debug("Start app debugging");
                log.Info("Start timer tick- 10sec ");
                InitTimer();

                //Connecto ADS Server
                log.Info("Connecting to PLC via ADS ");
                adsClient = new TcAdsClient();
				adsClient.Connect(netidplc,851);

                symbolLoader = adsClient.CreateSymbolInfoLoader();

                //Open connection 
                log.Info("Connecting to PostgreSQL Server ");
                TestconnOpen();

                //Open connection 
                log.Info("Connecting to PostgreSQL Server ");

                PrepareLiveTable();
                PrepareAccuTable();
            }
			catch(Exception err)
			{
                log.Debug(err.Message);   
            }
		}

        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 10000; // in miliseconds
            //Initialization Timer
            var date = DateTime.Now;

            int ActSec = date.Second;
            System.Threading.Thread.Sleep((60-ActSec)*1000);
                timer1.Start();

            
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                SQLLiveDataDump();
                SQLAccuDataDump();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            
          
            if (DateTime.Now.Hour == 23 && DateTime.Now.Minute == 59 )
            {
                if (!File.Exists("C:/hst_data/livedata_" + ActualDay + ".csv"))
                {
                    try
                    { 
                    SQLLiveStoreDay();

                    if (DateTime.Now.Day == 01 && DateTime.Now.Hour == 00 && DateTime.Now.Minute == 00 && DateTime.Now.Second == 00) { TruncateTableLive(); }
                   
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }
                }
                
            }
        }

		private void btnLoad_Click(object sender, System.EventArgs e)
		{						
			treeViewSymbols.Nodes.Clear();
			try
			{
				if( !cbFlat.Checked ) 
				{
					TcAdsSymbolInfo symbol = symbolLoader.GetFirstSymbol(true);
					while( symbol != null )
					{
                        treeViewSymbols.Nodes.Add(CreateNewNode(symbol));
                        symbol = symbol.NextSymbol;
					}	
				}
				else
				{
					foreach( TcAdsSymbolInfo symbol in symbolLoader )
					{
						TreeNode node = new TreeNode(symbol.Name);
						node.Tag = symbol;
						treeViewSymbols.Nodes.Add(node);
					}
				}
			}
			catch(Exception err)
			{
                log.Debug(err.Message);
			}
		}

        public List<string> ReadSQLTypes()
        {
            var listSQLTags = new List<string>();
            TcAdsSymbolInfoLoader symbolLoader;
            symbolLoader = adsClient.CreateSymbolInfoLoader();

            foreach (TcAdsSymbolInfo symbol in symbolLoader)
            {
                if (symbol.Type.Contains("ST_SQL"))
                {
                    PLCvar plcVar = new PLCvar(symbol.Name, symbol.Type);
                    
                    listSQLTags.Add(symbol.Name);
                    System.Threading.Thread.Sleep(1);
                }
            }
              return new List<string>();
           
        }

        //List

        public List<PLCvar> GetPLCvars()
        {
            List<PLCvar> symbolsList = new List<PLCvar>();
            TcAdsSymbolInfoLoader symbolLoader;
            symbolLoader = adsClient.CreateSymbolInfoLoader();
            foreach (TcAdsSymbolInfo symbol in symbolLoader)
            {
                symbolsList.Add(new PLCvar(symbol.Name, symbol.Type));
            }
            return symbolsList;
        }

        //Symbols SQL Live data
        public int ReadNSqlTypes()
        {
            TcAdsSymbolInfoLoader symbolLoader;
            symbolLoader = adsClient.CreateSymbolInfoLoader();
            //parse now
            int NTagsSQL = 0;
            int Counter = 0;
            int Match = 0;
            foreach (TcAdsSymbolInfo symbol in symbolLoader)
            {
                //TODO OPTIONAL: Implement a configurable filter here
                if (symbol.Type.Contains("SQL_SND") && symbol.Name.Contains("Val"))
                {
                    PLCvar plcVar = new PLCvar(symbol.Name, symbol.Type);
                    // listBoxDBLog.Items.Add(symbol.Name); //Debug
                    Match++;
                    System.Threading.Thread.Sleep(1);
                }
                if (Counter > 1 | symbol.Name != null)
                {
                    NTagsSQL = Match;
                }
                Counter++;
            }
            //(sender as BackgroundWorker).ReportProgress(100, null);
            //listBoxDBLog.Items.Add(NTagsSQL);

            return NTagsSQL;
        }

        private void PrepareLiveTable()
        {
            string queryF = "";
            string query = null;
            
            //CREATE TABLE stb."LivedataFK"
            //    (
            //        recordtime timestamp without time zone,
            //        "SQL_SNDOUT1Val" bigint,
            //        "SQL_SNDOUT2Val" bigint,
            //        PRIMARY KEY (recordtime)
            //    )

            query = @"CREATE TABLE IF NOT EXISTS " + SchemaName + "." + TableRT + " ( recordtime timestamp without time zone ";

            var SQLList = GetPLCSymbolsLiveSQL();         

            foreach (string TagSQL in SQLList)
            {
                query += (", " + cleaner(TagSQL) + " bigint");
            }
            queryF = query + ", PRIMARY KEY(\"recordtime\"));";
            insertinsql(@queryF);
        }

        public List<string> GetPLCSymbolsLiveSQL()
        {
            List<string> symbolsList = new List<string>();
            TcAdsSymbolInfoLoader symbolLoader;
            symbolLoader = adsClient.CreateSymbolInfoLoader();
            foreach (TcAdsSymbolInfo symbol in symbolLoader)
            {
                if (symbol.Name.Contains("SQL_SND") & symbol.Name.Contains("OUT") & symbol.Name.Contains("Val"))
                {
                    symbolsList.Add(symbol.Name);
                }
            }
            return symbolsList;
        }

        public List<string> GetPLCSymbolsNameLiveSQL()
        {
            List<string> symbolsList = new List<string>();
            TcAdsSymbolInfoLoader symbolLoader;
            symbolLoader = adsClient.CreateSymbolInfoLoader();
            foreach (TcAdsSymbolInfo symbol in symbolLoader)
            {
                if (symbol.Name.Contains("SQL_SND") & symbol.Name.Contains("TagName") & symbol.Name.Contains("OUT"))
                {
                    symbolsList.Add(symbol.Name);
                }
            }
            return symbolsList;
        }

        private void SQLLiveDataDump()
        {
            int nVar = ReadNSqlTypes();
            string queryF;
            string query = "INSERT INTO " + SchemaName + "." + TableRT + " (";

            //ManageTime
            string date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

            string queryT = "'" + date + "'";
            var SQLList = GetPLCSymbolsLiveSQL();

            //Get columns Names
            string NameCol = string.Join(" , ", SQLList.ToArray());
            string NameColClean = "RecordTime ," + cleaner(NameCol);
            string queryN = NameColClean + ") VALUES ( ";

            query += queryN + queryT;

            foreach (string TagSQL in SQLList)
            {
                string value = adsClient.ReadAny(adsClient.CreateVariableHandle(TagSQL.ToString()), typeof(int)).ToString();
                query += (", '" + value.ToString() + "' ");
            }
            queryF = query + ");";
            insertinsql(queryF);
            //listBoxDBLog.Items.Add("Row inserted with data from" +date);
        }

        private void SQLLiveStoreDay()
        {
            string query = "COPY (SELECT * FROM " + SchemaName + "." + TableRT + " WHERE(recordtime >= CURRENT_TIMESTAMP - INTERVAL '1 DAY'))";
            query += "TO 'C:/hst_data/livedata_" + ActualDay +".csv'";
            query += " WITH CSV HEADER ";
          

           // COPY (SELECT * FROM "stb"."LiveData" WHERE( recordtime >= CURRENT_TIMESTAMP - INTERVAL '1 DAY')) TO 'C:/hst_data/livedata_2016-12-14.csv'  WITH CSV HEADER

            //Insert query
            //Connection Npgsql 
            NpgsqlConnection conn = new NpgsqlConnection(constr);
            
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                log.Debug("Did Not Connect" + e.ToString());
                
            }

            //Npgsql server Command
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            
            cmd.Connection = conn;
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                log.Debug(e.ToString() + "\n\n" + query);
            }
            conn.Close();

                }

        private void TruncateTableLive()
        {

            string query = "truncate " + SchemaName + "." + TableRT;

            //Insert query
            //Connection Npgsql 
            NpgsqlConnection conn = new NpgsqlConnection(constr);

            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                log.Debug("Did Not Connect" + e.ToString());

            }

            //Npgsql server Command
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            cmd.Connection = conn;
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                log.Debug(e.ToString() + "\n\n" + query);

            }
            conn.Close();

            
        }

        //Symbols SQL Accu Data
        public List<string> GetPLCSymbolsAccuSQL()
        {
            List<string> symbolsList = new List<string>();
            TcAdsSymbolInfoLoader symbolLoader;
            symbolLoader = adsClient.CreateSymbolInfoLoader();
            foreach (TcAdsSymbolInfo symbol in symbolLoader)
            {
                if (symbol.Name.Contains("SQL_SND") & symbol.Name.Contains("ACCU") & symbol.Name.Contains("Val"))
                {
                    symbolsList.Add(symbol.Name);
                }
            }
            return symbolsList;
        }

        public List<string> GetPLCSymbolsNameAccuSQL()
        {
            List<string> symbolsList = new List<string>();
            TcAdsSymbolInfoLoader symbolLoader;
            symbolLoader = adsClient.CreateSymbolInfoLoader();
            foreach (TcAdsSymbolInfo symbol in symbolLoader)
            {
                if (symbol.Name.Contains("SQL_SND") & symbol.Name.Contains("TagName") & symbol.Name.Contains("ACCU"))
                {
                    symbolsList.Add(symbol.Name);
                }
            }
            return symbolsList;
        }

        private void SQLAccuDataDump()
        {
            int nVar = ReadNSqlTypes();
            string queryF;
            string query = "INSERT INTO " + SchemaName + "." + TableACCU + " (";
            string queryTrunc = "TRUNCATE " + SchemaName + "." + TableACCU;
           //Truncate table
            insertinsql(queryTrunc);
            //ManageTime
            string date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

            string queryT = "'" + date + "'";
            var SQLList = GetPLCSymbolsAccuSQL();

            //Get columns Names
            string NameCol = string.Join(" , ", SQLList.ToArray());
            string NameColClean = "RecordTime ," + cleaner(NameCol);
            string queryN = NameColClean + ") VALUES ( ";

            query += queryN + queryT;

            foreach (string TagSQL in SQLList)
            {
                string value = adsClient.ReadAny(adsClient.CreateVariableHandle(TagSQL.ToString()), typeof(int)).ToString();
                query += (", '" + value.ToString() + "' ");
            }
            queryF = query + ");";
            insertinsql(queryF);
        }

        private void PrepareAccuTable()
        {
            string queryF = "";
            string query = null;
            query = @"CREATE TABLE IF NOT EXISTS " + SchemaName + "." + TableACCU + " ( recordtime timestamp without time zone ";
          
            var SQLList = GetPLCSymbolsAccuSQL();       

            foreach (string TagSQL in SQLList)
            {
                query += (", " + cleaner(TagSQL) + " bigint");
            }
            queryF = query + ",PRIMARY KEY(\"recordtime\"));";
            insertinsql(@queryF);
        }

        //Symbols ALL (ADS)

        public List<string> GetPLCSymbols()
        {
            List<string> symbolsList = new List<string>();
            TcAdsSymbolInfoLoader symbolLoader;
            symbolLoader = adsClient.CreateSymbolInfoLoader();
            foreach (TcAdsSymbolInfo symbol in symbolLoader)
            {
             symbolsList.Add(symbol.Name);
            }
            return symbolsList;
        }

        //Ads Types

        public void GetPLCvarInfo(PLCvar pv)
        {
            ITcAdsSymbol symbol = adsClient.ReadSymbolInfo(pv.PLCname);
            pv.PLCtype = symbol.Type;
        }

		

		

		private void btnWrite_Click(object sender, System.EventArgs e)
		{	
			try
			{				
				if( currentSymbol != null )
					adsClient.WriteSymbol(currentSymbol, tbValue.Text);
			}
			catch(Exception err)
			{
				MessageBox.Show("Unable to write Value. " + err.Message);
			}
		}
		
		private void treeViewSymbols_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if( e.Node.Text.Length > 0 )
			{
				if( e.Node.Tag is TcAdsSymbolInfo )
				{
					SetSymbolInfo((ITcAdsSymbol)e.Node.Tag);
				}
			}
		}
		
		private TreeNode CreateNewNode(TcAdsSymbolInfo symbol)
		{
			TreeNode node = new TreeNode(symbol.Name);			
			node.Tag = symbol;

			TcAdsSymbolInfo subSymbol = symbol.FirstSubSymbol;

            //Create List to store PLC tags
           // List<PLC> lstPlc = new List<PLC>(); 

			while( subSymbol != null )
			{
				node.Nodes.Add(CreateNewNode(subSymbol));
				subSymbol = subSymbol.NextSymbol;
              
			}
			return node;
		}

        private void TestconnOpen()
        {
            //Connection Npgsql

            NpgsqlConnection conn = new NpgsqlConnection(constr);
            
            try
            {
                conn.Open();
                log.Debug("Successful connection with database");
                listBoxDBLog.Items.Add("Successful connection with database");
            }
            catch (Exception e)
            {
                log.Debug("Did Not Connect" + e.ToString());

            }
            conn.Close();
        }

        private int insertinsql(string query)
        {
           
            //Connection Npgsql 
            NpgsqlConnection conn = new NpgsqlConnection(constr);
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                 log.Debug("Did Not Connect" + e.ToString());
                return 0;
            }

            //Npgsql server Command
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            cmd.Connection = conn;
            try
            {    
                    cmd.ExecuteNonQuery();
           
            }
            catch (Exception e)
            {
                log.Debug(e.ToString() + "\n\n" + query);
                return 0;
            }
            conn.Close();
            return 1;
        }

        private void SetSymbolInfo(ITcAdsSymbol symbol)
		{
			currentSymbol = symbol;
			tbName.Text = symbol.Name.ToString();
			tbIndexGroup.Text = symbol.IndexGroup.ToString();
			tbIndexOffset.Text = symbol.IndexOffset.ToString();
			tbSize.Text = symbol.Size.ToString();
			tbDatatype.Text = symbol.Type;
			tbDatatypeId.Text = symbol.Datatype.ToString();
			try
			{
				tbValue.Text = adsClient.ReadSymbol(symbol).ToString();
			}
			catch( AdsDatatypeNotSupportedException err )
			{
				tbValue.Text = err.Message;
			}
			catch(Exception err)
			{
                log.Debug("Unable to read Symbol Info. " + err.Message); 
			}
		}

        private void SetSymbolValue(ITcAdsSymbol symbol)
        {
            currentSymbol = symbol;
            string Value = symbol.Name.ToString();
           
            try
            {
               Value = adsClient.ReadSymbol(symbol).ToString();
            }
            catch (AdsDatatypeNotSupportedException err)
            {
                log.Debug("Ads fault . " + err.Message);
            }
            catch (Exception err)
            {
                log.Debug("Unable to read Symbol Info. " + err.Message);
            }
        }

        private void GetSqlTag_Click(object sender, EventArgs e)
        {
            listBoxDBLog.DataSource = GetPLCSymbolsLiveSQL();
            listBoxDBLog.DataSource = GetPLCSymbolsAccuSQL();
        }

        private string cleaner(string query)
        {
            query = query.Replace("'", "");
            query = query.Replace("\\", "");
            query = query.Replace("/", "");
            query = query.Replace("\"", "");
            query = query.Replace(".", ""); 
            query = query.Replace(";", ",");
            query = query.Replace("[", "");
            query = query.Replace("]", ""); 


            return query;
        }

        private void CreateSchema(string nameSchema)
        {
            string query;
            query = "CREATE SCHEMA " + nameSchema;

            //Connection Npgsql 
            NpgsqlConnection conn = new NpgsqlConnection(constr);
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                log.Debug("Did Not Connect" + e.ToString());

            }

            //Npgsql server Command
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            cmd.Connection = conn;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Debug(e.ToString() + "\n\n" + query);
            }
            conn.Close();
        }

        private string CheckSchema(string nameSchema)
        {
            string query;
            query = " SELECT schema_name FROM information_schema.schemata WHERE schema_name = '" + nameSchema.ToLower() + "'";

            //Connection Npgsql 
            NpgsqlConnection conn = new NpgsqlConnection(constr);
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                log.Debug("Did Not Connect" + e.ToString());
                return "Not connect to SQL";
            }

            //Npgsql server Command
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            cmd.Connection = conn;
            try
            {
                cmd.ExecuteNonQuery();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string val = reader[0].ToString();
                    return val;
                }
            }
            catch (Exception e)
            {
                log.Debug(e.ToString() + "\n\n" + query);
                return "QueryError";
            }
            conn.Close();
            return "0";
        }

        private string GetReturnQuery(string query)
        {

            //Connection Npgsql 
            NpgsqlConnection conn = new NpgsqlConnection(constr);
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                log.Debug("Did Not Connect" + e.ToString());
                return "Not connect to SQL";
            }

            //Npgsql server Command
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            cmd.Connection = conn;
            try
            {
                cmd.ExecuteNonQuery();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string val = reader[0].ToString();
                    return val;
                }
            }
            catch (Exception e)
            {
                log.Debug(e.ToString() + "\n\n" + query);
                return "QueryError";
            }
            conn.Close();
            return "0";
        }

        private void TestCreateFile_Click(object sender, EventArgs e)
        {
            SQLLiveStoreDay();
            TruncateTableLive();
        }
    }
}
