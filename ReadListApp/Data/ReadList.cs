using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReadListApp
{
    [DataContract]
    public class ReadList
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string AuthorName { get; set; }
        [DataMember]
        public string BookTitle { get; set; }
        [DataMember]
        public DateTime ReadingDate { get; set; }
        [DataMember]
        public int Page { get; set; }
        [DataMember]
        public int Rating { get; set; }
    }
}
