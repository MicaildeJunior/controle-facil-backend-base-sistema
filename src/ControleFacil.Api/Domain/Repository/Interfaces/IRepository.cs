namespace ControleFacil.Api.Domain.Repository.Interfaces;

// T tipo genérico, I tipo de identificador genérico que irá retornar
public interface IRepository<T, I> where T : class
{
    // Obter todos
    Task<IEnumerable<T>> Obter();
    // Obter pelo Id    
    Task<T?> Obter(I id);
    Task<T> Adicionar(T entidade);
    Task<T> Atualizar(T entidade);
    Task Deletar(T entidade);
}