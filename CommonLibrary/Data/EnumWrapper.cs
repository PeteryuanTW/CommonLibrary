using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Data
{
    public class EnumWrapper
    {
        protected int index { get; init; }
        public int Index => index;

        protected string displayName { get; init; } = null!;
        public string DisplayName => displayName;
    }
}
