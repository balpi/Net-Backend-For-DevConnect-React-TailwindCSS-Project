

using AutoMapper;

public class BloqServices : IBloqService<Bloq>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Bloq> _repository;

    public BloqServices(IRepository<Bloq> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<BloqDto> AddBloqAsync(BloqDto bloq)
    {
        var bloqEntity = _mapper.Map<Bloq>(bloq);
        var response = await _repository.AddAsync(bloqEntity);
        return _mapper.Map<BloqDto>(response);
    }

    public async Task<int> BloqsCount(FilterDto filter)
    {
        var spec = new BloqSpec(filter);
        var count = await _repository.Count(spec);
        return count;
    }



    public async Task<BloqDto> GetBloq(int id)
    {
        var bloq = await _repository.GetById(id);
        return _mapper.Map<BloqDto>(bloq);
    }

    public async Task<IReadOnlyList<BloqDto>> GetBloqsAsync(FilterDto filter)
    {
        var spec = new BloqSpec(filter);
        var bloqs = await _repository.GetByFilter(spec);
        return _mapper.Map<IReadOnlyList<BloqDto>>(bloqs);
    }

    public async Task<BloqDto> HardDelete(BloqDto bloqDto)
    {
        var bloq = _mapper.Map<Bloq>(bloqDto);
        return _mapper.Map<BloqDto>(await _repository.HardDelete(bloq));
    }

    public async Task<BloqDto> RemoveBloq(BloqDto bloq)
    {
        var removed = await _repository.RemoveAsync(_mapper.Map<Bloq>(bloq));
        return _mapper.Map<BloqDto>(removed);
    }
}
