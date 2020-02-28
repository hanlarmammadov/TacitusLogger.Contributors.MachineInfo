# TacitusLogger.Contributors.MachineInfo

> Extension contributor for TacitusLogger that generates additional info related to the machine on which the log was produced.
 
Dependencies:  
* .Net Standard >= 2.0  
* TacitusLogger >= 0.1.3 
  
> Attention: `TacitusLogger.Contributors.MachineInfo` is currently in **Alpha phase**. This means you should not use it in any production code.

## Installation

The NuGet <a href="http://example.com/" target="_blank">package</a>:

```powershell
PM> Install-Package TacitusLogger.Contributors.MachineInfo
```

## Examples

### Adding machine info contributor to the logger
With builders:
```cs
Logger logger = LoggerBuilder.Logger()
                             .Contributors()
                                 .MachineInfo()
                             .BuildContributors()
                             .ForAllLogs()
                                 .Console().Add()
                             .BuildLogger();
```
Directly:
```cs
MachineInfoContributor machineInfo = new MachineInfoContributor(); 

Logger logger = new Logger();
logger.AddLogContributor(machineInfo); 
```
### Explicitly specifying name and status of machine info contributor
With builders:
```cs
Logger logger = LoggerBuilder.Logger()
                             .Contributors()
                                 .MachineInfo(true, "Source machine")
                             .BuildContributors()
                             .ForAllLogs()
                                 .Console().Add()
                             .BuildLogger();
```
Directly:
```cs
MachineInfoContributor machineInfo = new MachineInfoContributor("Source machine");
machineInfo.SetActive(true);

Logger logger = new Logger();
logger.AddLogContributor(machineInfo);
``` 
### Explicitly specifying mutable status of machine info contributor
With builders:
```cs
MutableSetting<bool> status = Setting<bool>.From.Variable(true);

Logger logger = LoggerBuilder.Logger()
                             .Contributors()
                                 .MachineInfo(status)
                             .BuildContributors()
                             .ForAllLogs()
                                 .Console().Add()
                             .BuildLogger();
```
Directly:
```cs
MutableSetting<bool> status = Setting<bool>.From.Variable(true); 
MachineInfoContributor machineInfo = new MachineInfoContributor("Source machine");
machineInfo.SetActive(status);

Logger logger = new Logger();
logger.AddLogContributor(machineInfo); 
``` 