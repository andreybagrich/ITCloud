   internal List<T> ExecuteReportScript<T>(string connectionStringName, string query)
        {
            using (var db = new TestDataContext(connectionStringName))
            {
                var res = db.Database.SqlQuery<T>(query).ToList();

                return res;
            }
        }
