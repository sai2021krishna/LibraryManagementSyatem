using System;
using System.Collections.Generic;

namespace JwtAuthenticationApi
{
    public partial class Staff
    {
        public int StaffId { get; set; }
        public string StaffUsername { get; set; }
        public string StaffPasscode { get; set; }
    }
}
