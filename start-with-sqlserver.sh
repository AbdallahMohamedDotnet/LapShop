!/bin/bash
set -e

 Start SQL Server in the background
/opt/mssql/bin/sqlservr &

 Wait for SQL Server to be available
for i in {1..30}; do
  /opt/mssql-tools/bin/sqlcmd -S abdallah -U sa -P "Your_password123" -Q "SELECT 1" && break
  echo "Waiting for SQL Server to start... ($i)"
  sleep 2
done

 Run the .NET app
exec dotnet LapShopv2.dll
