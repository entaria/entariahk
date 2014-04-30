using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Entaria.Models
{
    public class CardHolderDetail
    {
        [Key]
        public int CardHolderDetailId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public String EmailAddress { get; set; }
        public String PhoneNo { get; set; }
        public String PassWord { get; set; }
    }

}