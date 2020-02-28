using TacitusLogger.Builders;

namespace TacitusLogger.Contributors.MachineInfo.Examples
{
    class ConfiguringWithBuilders
    {
        public void Adding_Machine_Info_Contributor_To_The_Logger()
        {
            Logger logger = LoggerBuilder.Logger()
                                         .Contributors()
                                             .MachineInfo()
                                         .BuildContributors()
                                         .ForAllLogs()
                                             .Console().Add()
                                         .BuildLogger();
        }
        public void Explicitly_Specifying_Name_And_Status_Of_Machine_Info_Contributor()
        {
            Logger logger = LoggerBuilder.Logger()
                                         .Contributors()
                                             .MachineInfo(true, "Source machine")
                                         .BuildContributors()
                                         .ForAllLogs()
                                             .Console().Add()
                                         .BuildLogger();
        }
        //public void Explicitly_Specifying_Mutable_Status_Of_Machine_Info_Contributor()
        //{
        //    MutableSetting<bool> status = Setting<bool>.From.Variable(true);

        //    Logger logger = LoggerBuilder.Logger()
        //                                 .Contributors()
        //                                     .MachineInfo(status)
        //                                 .BuildContributors()
        //                                 .ForAllLogs()
        //                                     .Console().Add()
        //                                 .BuildLogger();
        //}
    }
}
