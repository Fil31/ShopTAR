using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Core.Dto.ChuckNorrisDtos;

namespace Shop.Core.ServiceInterface
{
    public interface IChuckNorrisServices
    {
        Task<ChuckNorrisResultDto> ChuckNorrisResult(ChuckNorrisResultDto dto);
    }
}
