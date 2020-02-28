
namespace TacitusLogger.Contributors.MachineInfo.Examples
{
    class Configuring
    {
        public void Adding_Machine_Info_Contributor_To_The_Logger()
        {
            MachineInfoContributor machineInfo = new MachineInfoContributor(); 

            Logger logger = new Logger();
            logger.AddLogContributor(machineInfo); 
        }
        public void Explicitly_Specifying_Name_And_Status_Of_Machine_Info_Contributor()
        {
            MachineInfoContributor machineInfo = new MachineInfoContributor("Source machine");
            machineInfo.SetActive(true);

            Logger logger = new Logger();
            logger.AddLogContributor(machineInfo);
        }
        public void Explicitly_Specifying_Mutable_Status_Of_Machine_Info_Contributor()
        {
            MutableSetting<bool> status = Setting<bool>.From.Variable(true); 
            MachineInfoContributor machineInfo = new MachineInfoContributor("Source machine");
            machineInfo.SetActive(status);

            Logger logger = new Logger();
            logger.AddLogContributor(machineInfo); 
        }
    }
}
