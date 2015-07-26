using System;
using System.Net;
using MediaLogue.Domain.Contracts;
using MediaLogue.Domain.Contracts.Services;
using MediaLogue.Domain.Exceptions;
using MediaLogue.Domain.Model;

namespace MediaLogue.Domain.Services
{
    public class TvdbService : ITvdbService
    {
        private readonly ITvdbGateway _gateway;
        private readonly ITvdbMapper _mapper;

        public TvdbService(ITvdbGateway gateway, ITvdbMapper mapper)
        {
            _gateway = gateway;
            _mapper = mapper;
        }

        public Show GetShow(int id)
        {
            var xml = _gateway.GetShow(id).Result;
            return xml == null ? null : _mapper.MapShowFrom(xml);
            //try
            //{
            //    xml = _gateway.GetShow(id).Result;
            //}
            //catch (AggregateException exception)
            //{
            //    if (exception.InnerException is BadResponseException)
            //    {
            //        if ((exception.InnerException as BadResponseException).StatusCode == HttpStatusCode.NotFound)
            //        {
            //            return null;        
            //        }
            //    }
            //    throw exception;
            //}

            //var show = _mapper.MapShowFrom(xml);
            
            //return show;
        }
    }
}
