using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
                                                    //tek parametre yani success gönderilen class'ı çalıştır. yanı 15. satır
        public Result(bool success, string message):this(success)
        {
            Message = message;
        }
                                               //bu yapıyla bir methoda istersek sadece success döndürebiliriz. İstersek success ve message döndürebiliriz.
        public Result(bool success)
        {
            
            Success = success;
        }

        public bool Success{ get; }

        public string Message { get; }
    }
}
