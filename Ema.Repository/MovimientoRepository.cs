using Ema.Data;

namespace Ema.Repository
{
    public class MovimientoRepository : GenericRepo<Movimiento> , IMovimientoRepository
    {
        public MovimientoRepository(EmaContext context) : base(context) { }
    }
}
