namespace ipog.bureaucrats.Mapping
{
    public interface IMapping
    {
        Task<T> CreateMap<T, U>(U entity);
    }
}
