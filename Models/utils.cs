using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace College.Models
{
    public class utils
    {
        public static string GetSesId()
        {
            CollegeWS.College  ws = new CollegeWS.College ();
            return ws.GetSessionId(1573, "college", "", 1, false);

        }
    }
}