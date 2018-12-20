# MongoDB appender for log4net
----------------------------

## Appender configuration sample
-----------------------------

```
	<appender name="MongoDBAppender" type="Log4Mongo.MongoDBAppender, Log4Mongo">
		<!-- 
		MongoDB database connection in the format:
		mongodb://[username:password@]host1[:port1][,host2[:port2],...[,hostN[:portN]]][/[database][?options]]
		See http://www.mongodb.org/display/DOCS/Connections for connectionstring options 
		If no database specified, default to "log4net"
		-->
		<connectionString value="mongodb://localhost" />
		<!-- 
		Name of connectionString defined in web/app.config connectionStrings group, the format is the same as connectionString value.
		Optional, If not provided will use connectionString value
		-->
		<connectionStringName value="mongo-log4net" />
		<!-- 
		The Friendly Name of the certificate. This value will be used if SSL is set to true
		The default StoreLocation is LocalMachine and StoreName is My
		-->	
		<certificateFriendlyName value="Certificate Friendly Name"/>	
		<!-- 
		If set, a TTL (Time To Live) index will be created on the Timestamp field.  
		Records older than this value will be deleted.
		-->	
		<expireAfterSeconds value="3600" />
		<!-- 
		Name of the collection in database
		Optional, Defaults to "logs"
		-->
		<collectionName value="logs" />
		<!--Maximum size of newly created collection. Optional, Defaults to creating uncapped collections-->
		<newCollectionMaxSize value='65536' />
		<newCollectionMaxDocs value='5000' />
		<field>
			<!-- Note: this needs to be "timestamp" and NOT "Timestamp"  for the TTL index to work -->
			<name value="timestamp" />
			<layout type="log4net.Layout.RawTimeStampLayout" />
		</field>
		<field>
			<name value="level" />
			<layout type="log4net.Layout.PatternLayout" value="%level" />
		</field>
		<field>
			<name value="thread" />
			<layout type="log4net.Layout.PatternLayout" value="%thread" />
		</field>
		<field>
			<name value="logger" />
			<layout type="log4net.Layout.PatternLayout" value="%logger" />
		</field>
		<field>
			<name value="message" />
			<layout type="log4net.Layout.PatternLayout" value="%message" />
		</field>
		<field>
			<name value="mycustomproperty" />
			<layout type="log4net.Layout.RawPropertyLayout">
				<key value="mycustomproperty" />
			</layout>
		</field>
	</appender>
```

## NetFrameWork
			LogLog.InternalDebugging = true;
			XmlConfigurator.Configure();//app.config default 

			ILog log = LogManager.GetLogger(typeof(Program));
			log.Info("Starting");
			
## NETCORE
```
        public static ILoggerRepository Repository;
```

```
            Repository = log4net.LogManager.CreateRepository("netcorerepository");
            XmlConfigurator.Configure(Repository, new FileInfo("log4net.config"));


            ILog log = LogManager.GetLogger(Repository.Name,typeof(Program));
            log.Info("Starting");
```


License
-------

[BSD 3](https://raw.github.com/log4mongo/log4mongo-net/master/LICENSE)