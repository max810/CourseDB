//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseDB
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class Ticket
    {
        public int id { get; set; }
        public string user_login { get; set; }
        public System.DateTime date_of_visit { get; set; }
        public System.TimeSpan time_of_visit { get; set; }
        public bool with_guide { get; set; }
    
        public virtual User_profile User_profile { get; set; }
    }
}