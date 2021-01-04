FROM microsoft/mssql-server-windows-express
 
# create directory within SQL container for database files
RUN mkdir C:\\SQLServer
 
#copy the database files from host to container
COPY C:\\Users\\Z\\test.mdf C:\\SQLServer
COPY C:\\Users\\Z\\test_log.ldf C:\\SQLServer

# set environment variables
ENV sa_password=Testing11@@
 
ENV ACCEPT_EULA=Y
 
ENV attach_dbs="[{'dbName':'test','dbFiles':['C:\\Users\\Z\\test.mdf','C:\\Users\\Z\\_log.ldf']}]"