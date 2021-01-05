FROM microsoft/mssql-server-windows-express
 
# create directory within SQL container for database files
RUN mkdir C:\\SQLServer

#copy the database files from host to container
COPY test.mdf C:\\SQLServer
COPY test_log.ldf C:\\SQLServer

# set environment variables
ENV sa_password=Testing11@@
 
ENV ACCEPT_EULA=Y
 
ENV attach_dbs='[{"dbName":"test","dbFiles":["C:\\SQLServer\\test.mdf","C:\\SQLServer\\test_log.ldf"]}]'

#to run sql
#docker run -p 1433:1433 --name mssqldb mssqldb:latest