namespace ControleFacil.Api.Domain.Services.Interfaces;

/// <summary>
/// Interface genérica para criação de serviços do tipo CRUD.
/// </summary>
/// <typeparam name="RQ">Contrato de request</typeparam>
/// <typeparam name="RS">COntrato de response</typeparam>
/// <typeparam name="I">Tipo do Id</typeparam>
public interface IService<RQ, RS, I> where RQ : class
{
    Task<IEnumerable<RS>> Obter(I idUsuario);
}