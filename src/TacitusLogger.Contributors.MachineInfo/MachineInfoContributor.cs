using System;
using System.Collections.Generic;

namespace TacitusLogger.Contributors.MachineInfo
{
    public class MachineInfoContributor : SynchronousLogContributorBase
    {
        public MachineInfoContributor(string name = "Machine info")
            : base(name)
        {

        }

        protected override Object GenerateLogItemData()
        {
            return new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("Operating system bitness", (Environment.Is64BitOperatingSystem) ? "64" : "32"),
                new KeyValuePair<string, string>("Process bitness", (Environment.Is64BitProcess) ? "64" : "32"),
                new KeyValuePair<string, string>("Machine name", Environment.MachineName),
                new KeyValuePair<string, string>("Operating system", Environment.OSVersion.VersionString),
                new KeyValuePair<string, string>("Processor count", Environment.ProcessorCount.ToString()),
                new KeyValuePair<string, string>("System page size", Environment.SystemPageSize.ToString("##,#")),
                new KeyValuePair<string, string>("Working set", Environment.WorkingSet.ToString("##,#"))
            };
        }
    } 
}
