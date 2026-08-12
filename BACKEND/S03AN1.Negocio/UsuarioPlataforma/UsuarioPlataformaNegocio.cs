using S03AN1.Modelos.UsuarioPlataforma;
using S03AN1.Negocio.General;
using S03AN1.Repositorio.UsuarioPlataforma;

namespace S03AN1.Negocio.UsuarioPlataforma
{
    public class UsuarioPlataformaNegocio : GenericNegocio<UsuarioPlataformaRequest, UsuarioPlataformaResponse, long>, IUsuarioPlataformaNegocio
    {
        public UsuarioPlataformaNegocio(IUsuarioPlataformaRepositorio usuarioPlataformaRepositorio) 
            : base(usuarioPlataformaRepositorio)
        {
        }
    }
}
