//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CricketEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class BowlingDetail
    {
        public int Id { get; set; }
        public int MatchNumber { get; set; }
        public int PlayerId { get; set; }
        public int CountryId { get; set; }
        public int Innings { get; set; }
        public int Opponents { get; set; }
        public int Balls { get; set; }
        public int Maidens { get; set; }
        public int Runs { get; set; }
        public int Wickets { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual Match Match { get; set; }
        public virtual Player Player { get; set; }
        public virtual BowlingDetail BowlingDetails1 { get; set; }
        public virtual BowlingDetail BowlingDetail1 { get; set; }
    }
}
