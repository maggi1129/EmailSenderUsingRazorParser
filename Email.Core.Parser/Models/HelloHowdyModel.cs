using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Email.Core.Parser.Models
{
    public class HelloHowdyModel
    {
        public HelloHowdyModel(string _meetingLocation,
            string _guestGeneralName, string _guestFirstName)
        {
            MeetingLocation = _meetingLocation;
            GuestFirstName = _guestFirstName;
            GuestGeneralName = _guestGeneralName;

        }
        public string MeetingLocation { get; set; }

        public string GuestGeneralName { get; set; }

        public string GuestFirstName { get; set; }

    }
}
