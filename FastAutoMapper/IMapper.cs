namespace Moon.FastAutoMapper
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource from);
    }
}
