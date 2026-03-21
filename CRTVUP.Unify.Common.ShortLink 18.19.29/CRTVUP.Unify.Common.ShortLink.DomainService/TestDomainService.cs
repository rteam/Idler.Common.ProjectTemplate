using CRTVUP.Unify.Common.ShortLink.Abstractions;
using CRTVUP.Unify.Common.ShortLink.Abstractions.Models;
using Idler.Common.AutoMapper;
using Idler.Common.Cache;
using Idler.Common.Core;
using Microsoft.EntityFrameworkCore;
using CRTVUP.Unify.Common.ShortLink.DomainService.Domains;

namespace CRTVUP.Unify.Common.ShortLink.DomainService;

internal class TestDomainService : BaseDomainService, ITestDomainService
{
    public TestDomainService(
        IRepository<Test, Guid> testRepository,
        ISimpleCacheManager<TestValue> testSimpleCacheManager,
        IUnitOfWork unitOfWork
    )
        : base(unitOfWork)
    {
        this.TestRepository = testRepository;
        this.TestSimpleCacheManager = testSimpleCacheManager;
    }

    private readonly ISimpleCacheManager<TestValue> TestSimpleCacheManager;
    private readonly IRepository<Test, Guid> TestRepository;

    /// <summary>
    /// 创建测试信息
    /// </summary>
    /// <param name="modelInfo">要创建的内容</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public async Task<APIReturnInfo<TestValue>> CreateTestAsync(CreateTestModel modelInfo, CancellationToken cancellationToken = default)
    {
        modelInfo.ThrowIfNull(nameof(modelInfo));

        Test test = await this.TestRepository.AddAsync(modelInfo.Map<CreateTestModel, Test>(), cancellationToken);

        await this.SaveChangeAsync();

        return APIReturnInfo<TestValue>.Success(test.Map<Test, TestValue>());
    }

    /// <summary>
    /// 编辑测试信息
    /// </summary>
    /// <param name="id">要编辑的信息Id</param>
    /// <param name="modelInfo">要编辑的信息内容</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public async Task<APIReturnInfo<TestValue>> EditTestAsync(Guid id, EditTestModel modelInfo, CancellationToken cancellationToken = default)
    {
        id.ThrowIfNull(nameof(id));
        modelInfo.ThrowIfNull(nameof(modelInfo));

        Test? test = await this.TestRepository.SingleAsync(id, cancellationToken);
        if (test == null)
            return APIReturnInfo<TestValue>.Error("要编辑的信息不存在");

        modelInfo.Map(test);

        await this.TestRepository.UpdateAsync(test, cancellationToken);
        await this.SaveChangeAsync();

        return APIReturnInfo<TestValue>.Success(test.Map<Test, TestValue>());
    }

    /// <summary>
    /// 删除测试信息
    /// </summary>
    /// <param name="id">要删除信息Id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public async Task<APIReturnInfo<TestValue>> RemoveTestAsync(Guid id, CancellationToken cancellationToken = default)
    {
        id.ThrowIfNull(nameof(id));

        Test? test = this.TestRepository.Remove(id);
        if (test == null)
            return APIReturnInfo<TestValue>.Error("要删除的信息不存在");

        await this.SaveChangeAsync();

        return APIReturnInfo<TestValue>.Success(test.Map<Test, TestValue>());
    }

    /// <summary>
    /// 获取指定测试信息
    /// </summary>
    /// <param name="id">Id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public async Task<APIReturnInfo<TestValue>> SingleTestAsync(Guid id, CancellationToken cancellationToken = default)
    {
        id.ThrowIfNull(nameof(id));

        string cacheKey = string.Concat("Test_", id);

        if (this.TestSimpleCacheManager.TryGet(cacheKey, out TestValue cacheItem))
        {
            return APIReturnInfo<TestValue>.Success(cacheItem);
        }

        Test? testWithCache = await this.TestRepository.SingleAsync(id, cancellationToken);
        if (testWithCache == null)
            return APIReturnInfo<TestValue>.Error("信息不存在");

        TestValue testValueWithCache = testWithCache.Map<Test, TestValue>();
        await this.TestSimpleCacheManager.SetAsync(cacheKey, _ => Task.FromResult(testValueWithCache));
        return APIReturnInfo<TestValue>.Success(testValueWithCache);
    }

    /// <summary>
    /// 返回所有测试信息
    /// </summary>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public async Task<APIReturnInfo<IList<TestValue>>> AllTestAsync(CancellationToken cancellationToken = default)
    {
        IList<TestValue> tests = await this.TestRepository.AllAsNoTracking()
            .ProjectTo<TestValue>()
            .ToListAsync(cancellationToken);

        return APIReturnInfo<IList<TestValue>>.Success(tests);
    }

    /// <summary>
    /// 分页显示测试信息数据
    /// </summary>
    /// <param name="pageNum">第几页</param>
    /// <param name="pageSize">每页显示几条信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public async Task<APIReturnInfo<ReturnPaging<TestValue>>> TestPagingAsync(int pageNum = 1, int pageSize = 20,
        CancellationToken cancellationToken = default)
    {
        ReturnPaging<TestValue> paging = new ReturnPaging<TestValue>()
        {
            PageNum = pageNum,
            PageSize = pageSize,
            Total = await this.TestRepository.CountAsync(cancellationToken)
        };

        paging.Compute();

        paging.PageListInfos = await this.TestRepository.AllAsNoTracking()
            .Skip(paging.Skip)
            .Take(paging.Take)
            .ProjectTo<TestValue>()
            .ToListAsync(cancellationToken);

        return APIReturnInfo<ReturnPaging<TestValue>>.Success(paging);
    }
}
