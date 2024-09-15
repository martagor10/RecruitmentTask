using RecruitmentTask.TriangleAnalyser.Model;
using RecruitmentTask.TriangleAnalyser.Rule;
using Xunit;
using Xunit.Categories;

namespace RecruitmentTask.TriangleAnalyser.Tests;

[UnitTest]
public class RulesTests
{
    [Theory]
    [InlineData(2, 2, 2, true)]
    [InlineData(1, 2, 2, false)]
    public void EquilateralTriangleRuleTest(int sideA, int sideB, int sideC, bool expectedResult)
    {
        // arrange
        var equilateralRule = new EquilateralTriangleRule();
        
        // act
        var result = equilateralRule.FulfillsCriteria(new Triangle(sideA, sideB, sideC));
        
        // assert
        Assert.Equal(result, expectedResult);
    }

    [Theory]
    [InlineData(2, 2, 5, true)]
    [InlineData(1, 2, 2, false)]
    public void InvalidRuleTest(int sideA, int sideB, int sideC, bool expectedResult)
    {
        // arrange
        var invalidRule = new InvalidTriangleRule();
        
        // act
        var result = invalidRule.FulfillsCriteria(new Triangle(sideA, sideB, sideC));
        
        // assert
        Assert.Equal(result, expectedResult);
    }
    
    [Theory]
    [InlineData(2, 2, 1, true)]
    [InlineData(1, 3, 2, false)]
    public void IsoscelesRuleTest(int sideA, int sideB, int sideC, bool expectedResult)
    {
        // arrange
        var isoscelesRule = new IsoscelesTriangleRule();
        
        // act
        var result = isoscelesRule.FulfillsCriteria(new Triangle(sideA, sideB, sideC));
        
        // assert
        Assert.Equal(result, expectedResult);
    }
    
    [Theory]
    [InlineData(2, 3, 1, true)]
    [InlineData(2, 3, 2, false)]
    public void ScaleneRuleTest(int sideA, int sideB, int sideC, bool expectedResult)
    {
        // arrange
        var scaleneRule = new ScaleneTriangleRule();
        
        // act
        var result = scaleneRule.FulfillsCriteria(new Triangle(sideA, sideB, sideC));
        
        // assert
        Assert.Equal(result, expectedResult);
    }
}