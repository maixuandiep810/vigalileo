using System;
using System.Collections.Generic;
using System.Text;

namespace  vigalileo.Data.Entities
{
    public class AppConfig : IBaseEntity<string>
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }
}
