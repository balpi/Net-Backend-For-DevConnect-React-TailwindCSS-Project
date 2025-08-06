public interface IBloqService<Bloq>
{
    Task<BloqDto> GetBloq(int id);
    Task<IReadOnlyList<BloqDto>> GetBloqsAsync(FilterDto filter);
    Task<int> BloqsCount(FilterDto filter);
    Task<BloqDto> AddBloqAsync(BloqDto bloq);
    Task<BloqDto> RemoveBloq(BloqDto bloq);
    Task<BloqDto> HardDelete(BloqDto bloq);
}