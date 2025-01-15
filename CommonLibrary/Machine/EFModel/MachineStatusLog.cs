using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Machine
{
    public partial class MachineStatusLog
    {
        public Guid Id { get; set; }

        public Guid MachineID { get; set; }

        public int Status { get; set; }

        public DateTime LogTime { get; set; }
    }
}
