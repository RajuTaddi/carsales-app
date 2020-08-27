using System;
using System.Collections.Generic;
using System.Text;

namespace carsales.common
{
    public class Constants
    {
        public static class Header
        {
            public static string ExceptionContentType = "application/problem+json";
            public static string ContentType = "application/json";
        }

        public static class Error
        {
            public static string BaseMessage = "An error occured: ";
        }
    }
}
