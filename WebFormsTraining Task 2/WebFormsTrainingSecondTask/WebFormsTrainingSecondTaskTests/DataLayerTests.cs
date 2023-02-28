using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebFormsTrainingSecondTask.Data;
using Moq;
using WebFormsTrainingSecondTask.Data.Core;
using System.Web.UI.WebControls;

namespace WebFormsTrainingSecondTaskTests
{
    [TestClass]
    public class DataLayerTests
    {
        private Mock<IDataLayer> _layerMock;

        [TestInitialize]
        public void Initialize()
        {
            _layerMock = new Mock<IDataLayer>();
        }

        [TestMethod]
        public void TestAllMethodsCalled()
        {
            _layerMock.Setup(x => x.Connect()).Returns(true).Verifiable();
            _layerMock.Setup(x => x.Disconnect()).Returns(true).Verifiable();
            _layerMock.Setup(x => x.TaskCRUD(It.IsAny<string>())).Returns(string.Empty).Verifiable();
            _layerMock.Setup(x => x.FillGridView(It.IsAny<string>(), It.IsAny<GridView>(), It.IsAny<string>())).Verifiable();

            _layerMock.Setup(x => x.ConnectionString).Returns("ConnectionString");

            _layerMock.Object.Connect();
            _layerMock.Object.Disconnect();
            _layerMock.Object.TaskCRUD(It.IsAny<string>());
            _layerMock.Object.FillGridView(It.IsAny<string>(), It.IsAny<GridView>(), It.IsAny<string>());
            
            _layerMock.Verify(x => x.Connect(), Times.Once());
            _layerMock.Verify(x => x.TaskCRUD(It.IsAny<string>()), Times.Once());
            _layerMock.Verify(x => x.FillGridView(It.IsAny<string>(), It.IsAny<GridView>(), It.IsAny<string>()), Times.Once());
            _layerMock.Verify(x => x.Disconnect(), Times.Once());
        }

        public DataLayer GetService()
        {
            return new DataLayer();
        }
    }
}
