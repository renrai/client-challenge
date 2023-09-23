using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectChallengeDomain.Models.Requests
{
    public class ClientRequestPut : ClientRequestPost
    {
        public Guid Id { get; set; }
    }
}
