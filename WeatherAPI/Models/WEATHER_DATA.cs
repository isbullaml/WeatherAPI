//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeatherAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Weather_Data
    {
        public int Id { get; set; }
        public int Device_Id { get; set; }
        public byte[] Time_Stamp { get; set; }
        public string Data { get; set; }
    }
}
