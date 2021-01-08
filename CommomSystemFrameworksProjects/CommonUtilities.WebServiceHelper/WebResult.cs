using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CommonUtilities.WebServiceHelper
{
    [DataContract]
    public class WebResult
    {
        [DataMember]
        public string messageField;
        [DataMember]
        public string totalField;
    }
}
