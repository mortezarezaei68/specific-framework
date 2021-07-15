using MediatR;

namespace Framework.Queries
{
    public interface IQueryHandlerMediatR<in TQueryRequest, TQueryResponse> :IRequestHandler<TQueryRequest, TQueryResponse> 
        where TQueryRequest:IRequest<TQueryResponse> where TQueryResponse:BaseResponseQuery
    {
        
    }
}