﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Notification.SMS
{
    public class ResponseCodes
    {
        public Dictionary<string, string> Codes { get; set; }

        public ResponseCodes()
        {
            Codes = new Dictionary<string, string>
            {
                { "000", "Operation is successfull"},
                { "001", "Processing, report is not ready"},
                { "002", "Duplicate <control_id> (it must be unique for each task)"},
                { "100", "Bad request"},
                { "101", "Operation type is empty"},
                { "102", "Invalid operation"},
                { "103", "Login is empty"},
                { "104", "Invalid authentification information"},
                { "105", "Invalid authentification information"},
                { "106", "Title is empty"},
                { "107", "Invalid title"},
                { "108", "Task id is empty"},
                { "109", "Invalid task id"},
                { "110", "Task with supplied id is canceled"},
                { "111", "Scheduled date is empty"},
                { "113", "Old scheduled date"},
                { "114", "isbulk is empty"},
                { "115", "Invalid isbulk value, must “true” or “false”"},
                { "116", "Invalid bulk message"},
                { "117", "Invalid body"},
                { "118", "Not enough units"},
                { "2XX", "System error, report to administrator"},
                { "300", "Internal server error, report to administrator"},
            };
        }
    }
}
