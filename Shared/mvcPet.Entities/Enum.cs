using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Entities
{
    public enum TipoSala
    {
        Recuperación,
        Vacunatorio,
        Quirófano
    }

    public enum TipoMatricula
    {
        MP,
        MN
    }

    public enum Estado
    {
        Cancelado,
        Realizado,
        Confirmado,
        Reservado
    }
}
