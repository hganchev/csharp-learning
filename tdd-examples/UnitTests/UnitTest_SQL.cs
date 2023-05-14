using System;
using Xunit;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Moq;
using Newtonsoft.Json;
using System.Diagnostics;
namespace UnitTest
{
    public class UnitTest_SQL
    {

        Mock<IDataAdapter> dataAdapterMock = new Mock<IDataAdapter>();
        Mock<IDbCommand> commandMock = new Mock<IDbCommand>();
        Mock<IDbConnection> connectionMock = new Mock<IDbConnection>();
        Mock<IDataReader> sqlReaderMock = new Mock<IDataReader>();


        [Fact]
        public void TestCheckNameExist()
        {
            //Arrange
            sqlReaderMock.SetupSequence(_ => _.Read())
                .Returns(true) // when first read to return True
                .Returns(false); // when second read to return False
            sqlReaderMock.Setup(reader => reader[0]).Returns(1); // when reads from reader to return 1 
            commandMock.Setup(m => m.ExecuteReader()).Returns(sqlReaderMock.Object).Verifiable();   // return reader when ExecuteReader and mark as verifiable
            connectionMock.Setup(m => m.CreateCommand()).Returns(commandMock.Object);               // set reference to CreateCommand function

            //Act
            Classes.SQLQueries.dbConnection = new Func<IDbConnection>(()=>connectionMock.Object);   // set reference to the mock object
            bool NameExist = Classes.SQLQueries.CheckNameExist("John");                             // execute function

            //Assert 
            Assert.True(NameExist); // Assert
            commandMock.Verify(); //since it was marked verifiable.
        }
    }
}