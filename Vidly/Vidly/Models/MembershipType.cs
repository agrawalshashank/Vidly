using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public string MembershipName { get; set; }
        public int DurationInMonths { get; set; }
        public int MemberShipFee { get; set; }
        public int Discount { get; set; }
    }
}