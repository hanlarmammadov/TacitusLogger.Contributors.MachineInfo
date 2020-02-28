using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TacitusLogger.Contributors.MachineInfo.UnitTests
{
    [TestFixture]
    public class MachineInfoContributorTests
    {
        #region Ctor tests

        [Test]
        public void Ctor_When_Called_Sets_IsActive_As_True()
        {
            //Act
            MachineInfoContributor machineInfoContributor = new MachineInfoContributor();

            //Assert 
            Assert.IsTrue(machineInfoContributor.IsActive);
        }

        [Test]
        public void Ctor_When_Called_Without_Name_Sets_Default()
        {
            //Act
            MachineInfoContributor machineInfoContributor = new MachineInfoContributor();

            //Assert
            Assert.AreEqual("Machine info", machineInfoContributor.Name);
        }

        [Test]
        public void Ctor_When_Called_With_Custom_Name_Sets_Default()
        {
            //Act
            MachineInfoContributor machineInfoContributor = new MachineInfoContributor("Custom name");

            //Assert
            Assert.AreEqual("Custom name", machineInfoContributor.Name);
        }

        #endregion

        #region Tests for ProduceLogItem method

        [Test]
        public void ProduceLogItem_When_Called_Returns_Log_Item_With_Data_In_It()
        {
            //Arrange
            MachineInfoContributor machineInfoContributor = new MachineInfoContributor();

            //Act
            LogItem logItem = machineInfoContributor.ProduceLogItem();

            //Assert
            Assert.NotNull(logItem);
            Assert.AreEqual("Machine info", logItem.Name);
            Assert.NotNull(logItem.Value);
            Assert.IsInstanceOf<KeyValuePair<string, string>[]>(logItem.Value);
            Assert.AreEqual(7, (logItem.Value as KeyValuePair<string, string>[]).Length);
        }

        #endregion

        #region Tests for ProduceLogItemAsync method

        [Test]
        public async Task ProduceLogItemAsync_When_Called_Asynchronously_Returns_Log_Item_With_Data_In_It()
        {
            //Arrange
            MachineInfoContributor machineInfoContributor = new MachineInfoContributor();

            //Act
            LogItem logItem = await machineInfoContributor.ProduceLogItemAsync();

            //Assert
            Assert.NotNull(logItem);
            Assert.AreEqual("Machine info", logItem.Name);
            Assert.NotNull(logItem.Value);
            Assert.IsInstanceOf<KeyValuePair<string, string>[]>(logItem.Value);
            Assert.AreEqual(7, (logItem.Value as KeyValuePair<string, string>[]).Length);
        }
        [Test]
        public void ProduceLogItemAsync_When_Called_With_Cancelled_Token_Returns_Cancelled_Task()
        {
            //Arrange
            MachineInfoContributor machineInfoContributor = new MachineInfoContributor();
            CancellationToken cancellationToken = new CancellationToken(canceled: true);

            //Act
            var resultTask = machineInfoContributor.ProduceLogItemAsync(cancellationToken);

            //Assert
            Assert.NotNull(resultTask);
            Assert.IsTrue(resultTask.IsCanceled);
        }

        #endregion
    }
}
