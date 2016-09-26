using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace HKOWebMVC4.Util {
    public class DB {
        public static DataSet PozoviSP(string naziv, List<SqlParameter> parametri) {
            var ds = new DataSet();

            //using (var conn = new SqlConnection("data source=193.198.206.227\\Projekti,22221;initial catalog=hko;user id=hkoweb;password=hko_web17#;MultipleActiveResultSets=True")) {
            using (var conn = new SqlConnection("data source=192.168.41.227\\Projekti,22221;initial catalog=hko;user id=hkoweb;password=hko_web17#;MultipleActiveResultSets=True")) {
                using (var cmd = new SqlCommand(naziv, conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (SqlParameter param in parametri) {
                        //cmd.Parameters.Add(new SqlParameter("StudijskiProgramID", studijskiProgramId));
                        cmd.Parameters.Add(param);
                    }

                    using (var adapter = new SqlDataAdapter(cmd)) {
                        adapter.Fill(ds);
                    }
                }
            }

            return ds;
        }
    }
}