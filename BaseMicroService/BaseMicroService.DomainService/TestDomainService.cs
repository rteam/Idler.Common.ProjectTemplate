using BaseMicroService.Abstractions;
using BaseMicroService.Abstractions.Models;
using BaseMicroService.Domain;
using Idler.Common.AutoMapper;
using Idler.Common.Core;

namespace BaseMicroService.DomainService;

internal class TestDomainService : BaseDomainService, ITestDomainService
{
    public TestDomainService(
        IRepository<Test, Guid> TestRepository,
#if (Cache)
        ISimpleCacheManager<TestValue> TestSimpleCacheManager,
#endif
        IUnitOfWork unitOfWork
    )
        : base(unitOfWork)
    {
        this.TestRepository = TestRepository;
#if (Cache)
        this.TestSimpleCacheManager = TestSimpleCacheManager;
#endif
    }
#if (Cache)
    private readonly ISimpleCacheManager<TestValue> TestSimpleCacheManager;
#endif
    private readonly IRepository<Test, Guid> TestRepository;

    /// <summary>
    /// 创建测试信息
    /// </summary>
    /// <param name="modelInfo">要创建的内容</param>
    /// <returns></returns>
    public APIReturnInfo<TestValue> CreateTest(CreateTestModel modelInfo)
    {
        modelInfo.ThrowIfNull(nameof(modelInfo));

        Test test = this.TestRepository.Add(modelInfo.Map<CreateTestModel, Test>());

        this.SaveChange();

        return APIReturnInfo<TestValue>.Success(test.Map<Test, TestValue>());
    }

    /// <summary>
    /// 编辑测试信息
    /// </summary>
    /// <param name="id">要编辑的信息Id</param>
    /// <param name="modelInfo">要编辑的信息内容</param>
    /// <returns></returns>
    public APIReturnInfo<TestValue> EditTest(Guid id, EditTestModel modelInfo)
    {
        id.ThrowIfNull(nameof(id));
        modelInfo.ThrowIfNull(nameof(modelInfo));

        Test test = this.TestRepository.Single(id);
        if (test == null)
            return APIReturnInfo<TestValue>.Error("要编辑的信息不存在");

        modelInfo.Map(test);

        this.TestRepository.Update(test);
        this.SaveChange();

        return APIReturnInfo<TestValue>.Success(test.Map<Test, TestValue>());
    }

    /// <summary>
    /// 删除测试信息
    /// </summary>
    /// <param name="id">要删除信息Id</param>
    /// <returns></returns>
    public APIReturnInfo<TestValue> RemoveTest(Guid id)
    {
        id.ThrowIfNull(nameof(id));

        Test test = this.TestRepository.Remove(id);
        this.SaveChange();

        return APIReturnInfo<TestValue>.Success(test.Map<Test, TestValue>());
    }

    /// <summary>
    /// 获取指定测试信息
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns></returns>
    public APIReturnInfo<TestValue> SingleTest(Guid id)
    {
        id.ThrowIfNull(nameof(id));

        string CacheKey = string.Concat("Test_", id);

#if (Cache)
        if (!this.TestSimpleCacheManager.TryGetOrAdd(CacheKey,
                t => this.TestRepository.Single(id).Map<Test, TestValue>(), out TestValue cacheItem))
        {
            return APIReturnInfo<TestValue>.Error("信息不存在");
        }

        return APIReturnInfo<TestValue>.Success(cacheItem);
#else
        return APIReturnInfo<TestValue>.Success(this.TestRepository.Single(id).Map<Test, TestValue>());
#endif
    }

    /// <summary>
    /// 返回所有测试信息
    /// </summary>
    /// <returns></returns>
    public APIReturnInfo<IList<TestValue>> AllTest()
    {
        return APIReturnInfo<IList<TestValue>>.Success(this.TestRepository.All().ProjectTo<TestValue>().ToList());
    }

    /// <summary>
    /// 分页显示测试信息数据
    /// </summary>
    /// <param name="pageNum">第几页</param>
    /// <param name="pageSize">每页显示几条信息</param>
    /// <returns></returns>
    public APIReturnInfo<ReturnPaging<TestValue>> TestPaging(int pageNum = 1, int pageSize = 20)
    {
        ReturnPaging<TestValue> paging = new ReturnPaging<TestValue>()
        {
            PageNum = pageNum,
            PageSize = pageSize,
            Total = this.TestRepository.Count()
        };

        paging.Compute();

        paging.PageListInfos = this.TestRepository.All().Skip(paging.Skip).Take(paging.Take).ProjectTo<TestValue>()
            .ToList();

        return APIReturnInfo<ReturnPaging<TestValue>>.Success(paging);
    }
}