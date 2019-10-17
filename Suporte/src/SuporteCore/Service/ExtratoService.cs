using SuporteCore.Entity;
using SuporteCore.Interfaces.Repository;
using SuporteCore.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuporteCore.Service
{
    
    public class ExtratoService : IExtratoService
    {
        private readonly IExtratoRepository _extratoRepository;
        private readonly IPosRepository _posRepository;
        public ExtratoService(IExtratoRepository extratoRepository, IPosRepository posRepository)
        {
            _posRepository = posRepository;
            _extratoRepository = extratoRepository;
        }

        public IEnumerable<Extrato> GetAll()
        {
            return _extratoRepository.GetAll();
        }

        public void ValidationAluguel(List<Pos> lstPos)
        {
            var usuarioId = _posRepository.GetUsuarioId();


            throw new NotImplementedException();
        }
    }
}
