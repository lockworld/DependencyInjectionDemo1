using System.Collections.Generic;

namespace DI.Common.Enumerations
{
    public enum StatusCode
    {
        /*
            Tried to create some groups of StatusCodes similar to the way HTTP status codes are grouped into categories: http://www.web-cache.com/Writings/http-status-codes.html
        */
        // Default (unset) value should always be 0
        Null,

        // Info codes
        Information=100,
        Started,
        InProgress,

        // Success codes
        OK=200,
        Completed,
        Implemented,
        Success,
        
        // Warning codes
        Warning=300,
        NotImplemented,

        // Error codes
        Error=400,
        Failure
    }
    
    public class Status
    {
        public static bool Successful(StatusCode statuscode)
        {
            int codeval = (int)statuscode;
            if (codeval >= 100 && codeval < 200)
            {
                return true;
            }
            return false;
        }

        public static StatusCode StatusGroup(StatusCode statuscode)
        {
            int codeval = (int)statuscode;
            if (codeval >= 100 && codeval < 200)
            {
                return StatusCode.Information;
            }
            else if (codeval >= 200 && codeval < 300)
            {
                return StatusCode.Success;
            }
            else if (codeval >= 300 && codeval < 400)
            {
                return StatusCode.Warning;
            }
            else if (codeval >= 400 && codeval < 500)
            {
                return StatusCode.Error;
            }
            else
            {
                return StatusCode.Null;
            }
        }
    }

    public static class StatusExtensions
    {
        public static bool  Successful(this StatusCode statuscode)
        {
            int codeval = (int)statuscode;
            if (codeval >= 200 && codeval < 300)
            {
                return true;
            }
            return false;
        }

        public static StatusCode StatusGroup(this StatusCode statuscode)
        {
            int codeval = (int)statuscode;
            if (codeval >= 100 && codeval < 200)
            {
                return StatusCode.Information;
            }
            else if (codeval >= 200 && codeval < 300)
            {
                return StatusCode.Success;
            }
            else if (codeval >= 300 && codeval < 400)
            {
                return StatusCode.Warning;
            }
            else if (codeval >= 400 && codeval < 500)
            {
                return StatusCode.Error;
            }
            else
            {
                return StatusCode.Null;
            }
        }
    }
}
