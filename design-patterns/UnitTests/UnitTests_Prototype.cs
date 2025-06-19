using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPatterns.Prototype;

[TestClass]
public class PrototypeTests
{
    [TestMethod]
    public void TestDocumentCloning()
    {
        // Arrange
        var originalReport = new Report("Annual Report", "John Doe", "Finance");
        originalReport.Content = "Financial data for 2024";
        originalReport.Sections.Add("Executive Summary");
        originalReport.Sections.Add("Financial Overview");

        // Act
        var clonedReport = (Report)originalReport.Clone();

        // Assert
        Assert.AreNotSame(originalReport, clonedReport);
        Assert.AreEqual(originalReport.Title, clonedReport.Title);
        Assert.AreEqual(originalReport.Content, clonedReport.Content);
        Assert.AreEqual(originalReport.Department, clonedReport.Department);
        Assert.AreEqual(originalReport.Sections.Count, clonedReport.Sections.Count);
        
        // Verify deep copy - sections should be different objects
        Assert.AreNotSame(originalReport.Sections, clonedReport.Sections);
        
        // Modify cloned report to verify independence
        clonedReport.Title = "Modified Report";
        clonedReport.Sections.Add("New Section");
        
        Assert.AreNotEqual(originalReport.Title, clonedReport.Title);
        Assert.AreNotEqual(originalReport.Sections.Count, clonedReport.Sections.Count);
    }    [TestMethod]
    public void TestPrototypeRegistry()
    {
        // Arrange
        var registry = new DocumentRegistry();
        
        // Create and register prototypes
        var reportPrototype = new Report("Monthly Report Template", "System", "Finance");
        var proposalPrototype = new Proposal("Project Proposal Template", "System", 50000m, DateTime.Now.AddDays(30));
        var contractPrototype = new Contract("Service Contract Template", "System", 100000m, DateTime.Now, DateTime.Now.AddMonths(12));
        
        registry.RegisterPrototype("monthly-report", reportPrototype);
        registry.RegisterPrototype("project-proposal", proposalPrototype);
        registry.RegisterPrototype("service-contract", contractPrototype);

        // Act
        var clonedReport = registry.GetPrototype("monthly-report");
        var clonedProposal = registry.GetPrototype("project-proposal");
        var clonedContract = registry.GetPrototype("service-contract");

        // Assert
        Assert.IsNotNull(clonedReport);
        Assert.IsNotNull(clonedProposal);
        Assert.IsNotNull(clonedContract);
        
        Assert.IsInstanceOfType(clonedReport, typeof(Report));
        Assert.IsInstanceOfType(clonedProposal, typeof(Proposal));
        Assert.IsInstanceOfType(clonedContract, typeof(Contract));
        
        // Verify they are clones, not the same instances
        Assert.AreNotSame(reportPrototype, clonedReport);
        Assert.AreNotSame(proposalPrototype, clonedProposal);
        Assert.AreNotSame(contractPrototype, clonedContract);
    }

    [TestMethod]
    public void TestCustomDocumentCloning()
    {
        // Arrange
        var originalProposal = new Proposal("Project Proposal", "Jane Smith", 75000m, DateTime.Now.AddDays(60));
        originalProposal.Content = "Software development proposal";
        originalProposal.Requirements.Add("Requirement 1");
        originalProposal.Requirements.Add("Requirement 2");

        // Act
        var clonedProposal = (Proposal)originalProposal.Clone();
        clonedProposal.Author = "John Doe";
        clonedProposal.Budget = 100000m;

        // Assert
        Assert.AreNotSame(originalProposal, clonedProposal);
        Assert.AreEqual("Jane Smith", originalProposal.Author);
        Assert.AreEqual("John Doe", clonedProposal.Author);
        Assert.AreEqual(75000m, originalProposal.Budget);
        Assert.AreEqual(100000m, clonedProposal.Budget);
        Assert.AreEqual(originalProposal.Requirements.Count, clonedProposal.Requirements.Count);
        
        // Verify deep copy of requirements list
        Assert.AreNotSame(originalProposal.Requirements, clonedProposal.Requirements);
    }

    [TestMethod]
    public void TestRegistryInvalidPrototype()
    {
        // Arrange
        var registry = new DocumentRegistry();
        
        // Act
        var result = registry.GetPrototype("InvalidType");

        // Assert
        Assert.IsNull(result);
    }
}
