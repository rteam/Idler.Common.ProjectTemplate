using BaseMicroService.Abstractions;
using BaseMicroService.Abstractions.Models;
using Idler.Common.Core;

namespace BaseMicroService.DomainService;

public interface ITestDomainService : IDomainService
{
    /// <summary>
    /// 创建测试信息
    /// </summary>
    /// <param name="modelInfo">要创建的内容</param>
    /// <returns></returns>
    APIReturnInfo<TestValue> CreateTest(CreateTestModel modelInfo);

    /// <summary>
    /// 编辑测试信息
    /// </summary>
    /// <param name="id">要编辑的信息Id</param>
    /// <param name="modelInfo">要编辑的信息内容</param>
    /// <returns></returns>
    APIReturnInfo<TestValue> EditTest(Guid id, EditTestModel modelInfo);

    /// <summary>
    /// 删除测试信息
    /// </summary>
    /// <param name="id">要删除信息Id</param>
    /// <returns></returns>
    APIReturnInfo<TestValue> RemoveTest(Guid id);
    
    /// <summary>
    /// 获取指定测试信息
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns></returns>
    APIReturnInfo<TestValue> SingleTest(Guid id);

    /// <summary>
    /// 返回所有测试信息
    /// </summary>
    /// <returns></returns>
    APIReturnInfo<IList<TestValue>> AllTest();

    /// <summary>
    /// 分页显示测试信息数据
    /// </summary>
    /// <param name="pageNum">第几页</param>
    /// <param name="pageSize">每页显示几条信息</param>
    /// <returns></returns>
    APIReturnInfo<ReturnPaging<TestValue>> TestPaging(int pageNum = 1, int pageSize = 20);
}