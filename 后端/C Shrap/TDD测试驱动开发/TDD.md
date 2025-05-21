# 单元测试（Unit Test）
> 1、单元测试只专注于测试一个类或者方法
> 2、每个测试用例（TestCase）由Arrange（准备测试数据）、Act(执行被测试的方法)、Assert(断言)

## xUnit的基本使用
1、创建xUnit测试项目并引用被测试项目
2、命名规范：项目名/namespace/类名+Tests
3、TestCase名字规范：给定什么条件-期望结果
4、被测试的类的对应变量名一般叫sut(system under test)
5、没有参数的TestCase标注[Fact]；有参数的TestCase标注[Theory]，然后使用[InineData]等来提供测试数据

# 集成测试（Integration Test）

# E2E测试 （End2End）

