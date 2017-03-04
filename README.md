DBManager 0.1.0 (Alternative to TS6420 | TwinCAT Database Server)

Fuctions APP
############

Read all tag from Twincat PLC 

Send query to PLC every 10 sec

Data structure detect and filter tag to dump Database

Create table when don´t exist

Implementation log debug with log4net

Requirements
###########

PostgreSQL Database server
Net 2.0 Framentwork (Run in PLC CX51XX and CX21XX) windows based (not wince 6.0)
Twincat XAE rutime 

Usage
###########
Database with DB(Database) stb(schema) 
Download ADS librarie fron Beckhoff
SET DATABASE IN:

        //SQL server parameters
        //Connection Npgsql
        public string constr = "Server=127.0.0.1;Port=5432;Database=DB;User Id=postgres;Password=1;";
        public string SchemaName = "stb";
        public string TableRT = "\"LiveData\"";
        public string TableACCU = "\"TableACCU\"";

SET ADS NET ID:

        //PLC address
        public string netidplc = "192.168.202.134.1.1";

Start App in PLC 



