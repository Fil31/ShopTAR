using Shop.Core.Dto.NorrisDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ServiceInterface
{
    public interface IChuckNorrisService
    {
        Task<NorrisResponseRootDto> GetRandomJokeAsync();
    }
}
