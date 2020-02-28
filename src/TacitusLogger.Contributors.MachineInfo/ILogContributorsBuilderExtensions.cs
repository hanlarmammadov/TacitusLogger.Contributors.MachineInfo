using System.ComponentModel; 
using TacitusLogger.Builders;

namespace TacitusLogger.Contributors.MachineInfo
{ 
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ILogContributorsBuilderExtensions
    {
        public static ILogContributorsBuilder MachineInfo(this ILogContributorsBuilder self, Setting<bool> isActive, string name = "Machine info")
        {
            return self.Custom(new MachineInfoContributor(name), isActive);
        }
        public static ILogContributorsBuilder MachineInfo(this ILogContributorsBuilder self, string name = "Machine info")
        {
            return self.Custom(new MachineInfoContributor(name), true);
        }
    }
}
